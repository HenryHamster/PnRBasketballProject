/*
 * Copyright (c) Meta Platforms, Inc. and affiliates.
 * All rights reserved.
 *
 * Licensed under the Oculus SDK License Agreement (the "License");
 * you may not use the Oculus SDK except in compliance with the License,
 * which is provided at the time of installation or download, or which
 * otherwise accompanies this software in either electronic or hard copy form.
 *
 * You may obtain a copy of the License at
 *
 * https://developer.oculus.com/licenses/oculussdk/
 *
 * Unless required by applicable law or agreed to in writing, the Oculus SDK
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Facebook.WitAi;
using Facebook.WitAi.Lib;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Oculus.Voice.Demo
{
    public class InteractionHandler : MonoBehaviour
    {
        [Header("Default States"), Multiline]
        [SerializeField] private string freshStateText = "Try pressing the Activate button and saying \"Make the cube red\"";

        [Header("UI")]
        [SerializeField] private Text textArea;
        [SerializeField] private bool showJson;

        [Header("Voice")]
        [SerializeField] private AppVoiceExperience appVoiceExperience;

        // Whether voice is activated
        public bool IsActive => _active;
        private bool _active = false;


        public int ResponseAns;



        // Add delegates
        private void OnEnable()
        {
            appVoiceExperience.events.OnRequestCreated.AddListener(OnRequestStarted);
            appVoiceExperience.events.OnPartialTranscription.AddListener(OnRequestTranscript);
            appVoiceExperience.events.OnFullTranscription.AddListener(OnRequestTranscript);
            appVoiceExperience.events.OnStartListening.AddListener(OnListenStart);
            appVoiceExperience.events.OnStoppedListening.AddListener(OnListenStop);
            appVoiceExperience.events.OnStoppedListeningDueToDeactivation.AddListener(OnListenForcedStop);
            appVoiceExperience.events.OnResponse.AddListener(OnRequestResponse);
            appVoiceExperience.events.OnError.AddListener(OnRequestError);
            
        }
        // Remove delegates
        private void OnDisable()
        {
            appVoiceExperience.events.OnRequestCreated.RemoveListener(OnRequestStarted);
            appVoiceExperience.events.OnPartialTranscription.RemoveListener(OnRequestTranscript);
            appVoiceExperience.events.OnFullTranscription.RemoveListener(OnRequestTranscript);
            appVoiceExperience.events.OnStartListening.RemoveListener(OnListenStart);
            appVoiceExperience.events.OnStoppedListening.RemoveListener(OnListenStop);
            appVoiceExperience.events.OnStoppedListeningDueToDeactivation.RemoveListener(OnListenForcedStop);
            appVoiceExperience.events.OnResponse.RemoveListener(OnRequestResponse);
            appVoiceExperience.events.OnError.RemoveListener(OnRequestError);
        }

        // Request began
        private void OnRequestStarted(WitRequest r)
        {
            // Store json on completion
            if (showJson) r.onRawResponse = (response) => textArea.text = response;
            // Begin
            _active = true;
        }
        // Request transcript
        private void OnRequestTranscript(string transcript)
        {
            textArea.text = transcript;
        }
        // Listen start
        private void OnListenStart()
        {
            textArea.text = "Waiting for your answer...";
        }
        // Listen stop
        private void OnListenStop()
        {
            textArea.text = "Processing...";
        }
        // Listen stop
        private void OnListenForcedStop()
        {
            if (!showJson)
            {
                // textArea.text = freshStateText;
            }
            OnRequestComplete();
        }
        // Request response
        private void OnRequestResponse(WitResponseNode response)
        {
            if (!showJson)
            {
                if (!string.IsNullOrEmpty(response["text"]))
                {
                    // textArea.text = "I heard: " + response["text"];
                    ResponseAns = ParseEnglish(response["text"]);
                    Debug.Log("============================" + ResponseAns);
                    textArea.text = "Your answer is: " + response["text"];
                }
                else
                {
                    // textArea.text = freshStateText;
                }
            }
            OnRequestComplete();
        }
        // Request error
        private void OnRequestError(string error, string message)
        {
            if (!showJson)
            {
                textArea.text = $"<color=\"red\">Error: {error}\n\n{message}</color>";
            }
            OnRequestComplete();
        }
        // Deactivate
        private void OnRequestComplete()
        {
            _active = false;
        }

        // Toggle activation
        public void ToggleActivation()
        {
            SetActivation(!_active);
        }
        // Set activation
        public void SetActivation(bool toActivated)
        {
            if (_active != toActivated)
            {
                _active = toActivated;
                if (_active)
                {
                    appVoiceExperience.Activate();
                }
                else
                {
                    appVoiceExperience.Deactivate();
                }
            }
        }

        public void Init_Speech()
        {
            textArea.text = "";
        }

        static int ParseEnglish(string number)
        {   


            number = number.Replace(".", "");

            string[] nums = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", 
                            "11", "12", "13", "14", "15", "16", "17", "18", "19", "20",
                            "21", "22", "23", "24", "25", "26", "27", "28", "29", "30",
                            "31", "32", "33", "34", "35", "36", "37", "38", "39", "40"};


            string[] ones = { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten" };

            for(int i = 0 ; i < nums.Length ; i++)
            {
                bool isNum = number.Contains(nums[i]);
                if(isNum)
                {
                    string s = number.Replace(nums[i], "");
                    if(s == "")
                        return int.Parse(number);
                }
            }

            for(int i = 0 ; i < ones.Length ; i++)
            {
                bool isOnes = number.Contains(ones[i]);
                if(isOnes)
                {
                    Debug.Log(i+1);
                    return (i+1);

                    // string s = number.Replace(ones[i], "");
                    // if(s == "")
                    //     return int.Parse(number);
                }
            }
            return -1;


            // string[] words = number.ToLower().Split(new char[] { ' ', '-', ',' }, StringSplitOptions.RemoveEmptyEntries);
            // string[] ones = { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            // string[] teens = { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            // string[] tens = { "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            // Dictionary<string, int> modifiers = new Dictionary<string, int>() {
            //     {"billion", 1000000000},
            //     {"million", 1000000},
            //     {"thousand", 1000},
            //     {"hundred", 100}
            // };

            // if (number == "eleventy billion")
            //     return int.MaxValue; // 110,000,000,000 is out of range for an int!

            // int result = 0;
            // int currentResult = 0;
            // int lastModifier = 1;


            // bool isOnes = false, isTeens = false, isTens = false;

            // // 先檢查是否包含這些 keyword，預防一些垃圾文字
            // for(int i = 0 ; i < ones.Length ; i++)
            // {
            //     isOnes = number.Contains(ones[i]);
            //     Debug
            //     if(isOnes)
            //         break;
            // }
            // for(int i = 0 ; i < teens.Length ; i++)
            // {
            //     isTeens = number.Contains(teens[i]);
            //     if(isTeens)
            //         break;
            // }
            // for(int i = 0 ; i < tens.Length ; i++)
            // {
            //     isTens = number.Contains(tens[i]);
            //     if(isTens)
            //         break;
            // }

            // if(!isOnes && !isTeens && !isTens)
            //     return -1;
            // else
            // {
            //     foreach (string word in words)
            //     {
            //         if (modifiers.ContainsKey(word))
            //             lastModifier *= modifiers[word];
            //         else
            //         {
            //             int n;

            //             if (lastModifier > 1)
            //             {
            //                 result += currentResult * lastModifier;
            //                 lastModifier = 1;
            //                 currentResult = 0;
            //             }

            //             if ((n = Array.IndexOf(ones, word) + 1) > 0)
            //                 currentResult += n;
            //             else if ((n = Array.IndexOf(teens, word) + 1) > 0)
            //                 currentResult += n + 10;
            //             else if ((n = Array.IndexOf(tens, word) + 1) > 0)
            //                 currentResult += n * 10;
            //             // else if (word != "and")
            //             //     throw new ApplicationException("Unrecognized word: " + word);
            //         }
            //     }

            //     Debug.Log(result);

            //     return result + currentResult * lastModifier;
            // }
        }
    }
}
