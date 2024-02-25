using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ArrayDataWrapper
{
    public FrameData[] array;
}
[System.Serializable]
public class FrameData
{
    public int frameID;
    public int playerID;
    public float x;
    public float y;
    public int team;
}
[System.Serializable]
public class PlayerTransform
{
    public Transform transform;
    public int id; 
    public List<FrameData> framePositions;
    public int currentFrameIndex = 0;
}
public class DataInterpreter : MonoBehaviour
{
    public const string pathName = "data/playerData.json";
    public static DataInterpreter instance;
    //public FrameData[] playerFrameData;
    //public FrameData[] jsonTestFrameData;
    public int frameCount = 0;
    private static int _FPS=12;
    private float _startTime=0;
    [SerializeField] PlayerTransform[] players;
    public string tempData;
    private void Awake()
    {
        instance = this;
       // ArrayDataWrapper testWrapper = new ArrayDataWrapper();
        //testWrapper.array = jsonTestFrameData;
        //testWrapper.array=new string[] { JsonUtility.ToJson(jsonTestFrameData[0],true), JsonUtility.ToJson(jsonTestFrameData[0], true) };
        //Debug.Log(JsonUtility.ToJson(testWrapper,true));
        //Debug.Log(JsonUtility.ToJson(jsonTestFrameData,true));

    }
    // Start is called before the first frame update
    void Start()
    {
        _startTime = Time.time;
        TextAsset data=Resources.Load<TextAsset>(pathName);
        Debug.Log("Found data: " + (data != null));
        //string contents = data.ToString();
        ArrayDataWrapper wrapper = JsonUtility.FromJson(tempData, typeof(ArrayDataWrapper)) as ArrayDataWrapper;
        int i = 0;
        foreach (FrameData s in wrapper.array) 
        {
           // playerFrameData[i] = s;
            for (int j = 0; j < players.Length; j++) {
                if (s.playerID == players[j].id)
                {
                    players[j].framePositions.Add(s);
                    break; 
                }
            }
            i++;
        }

    }

    // Update is called once per frame
    public void UpdatePosition()
    {
        foreach(PlayerTransform pt in players)
        {
            if (pt.framePositions.Count <= pt.currentFrameIndex) { continue; }
            Vector3 currentFramePlayer = new Vector3(pt.framePositions[pt.currentFrameIndex].x,0, pt.framePositions[pt.currentFrameIndex].y);
            Vector3 nextFramePlayer=currentFramePlayer;
            if (pt.currentFrameIndex < pt.framePositions.Count - 1) {
                nextFramePlayer = new Vector3(pt.framePositions[pt.currentFrameIndex + 1].x, 0,pt.framePositions[pt.currentFrameIndex + 1].y); 
            }

            if (pt.framePositions[pt.currentFrameIndex + 1].frameID <= frameCount)
            {
                pt.currentFrameIndex++;
                pt.transform.position = nextFramePlayer/50*1.5f-new Vector3(20,0,0);

            }
            else if(pt.currentFrameIndex==pt.framePositions.Count-1)
            {
                pt.transform.position = currentFramePlayer/50 * 1.5f - new Vector3(20, 0, 0);
            }
            else
            {
                pt.transform.position=Vector3.MoveTowards(currentFramePlayer,nextFramePlayer,
                    (frameCount-pt.currentFrameIndex)/(pt.framePositions[pt.currentFrameIndex+1].frameID-pt.currentFrameIndex))/50 * 1.5f - new Vector3(20, 0, 0);
            }
        }
    }
    private void LateUpdate()
    {
        frameCount = Mathf.FloorToInt((Time.time - _startTime) * _FPS);
    }
}
