using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
public class ArrayDataWrapper
{
    public string[] array;
}
public class FrameData
{
    public int frameID;
    public int playerID;
    public int x;
    public int y;
}
[System.Serializable]
public class PlayerTransform
{
    public Transform transform;
    public int id;
    [HideInInspector]   
    public List<FrameData> framePositions;
    [HideInInspector]
    public int currentFrameIndex = 0;
}
public class DataInterpreter : MonoBehaviour
{
    public const string pathName = "data/playerData.txt";
    public FrameData[] playerFrameData;
    public static int frameCount = 0;
    [SerializeField] PlayerTransform[] players;
    // Start is called before the first frame update
    void Start()
    {
        TextAsset data=Resources.Load<TextAsset>(pathName);
        string contents = data.text;
        ArrayDataWrapper wrapper = JsonUtility.FromJson(contents, typeof(ArrayDataWrapper)) as ArrayDataWrapper;
        int i = 0;
        foreach (string s in wrapper.array)
        {
            playerFrameData[i] = JsonUtility.FromJson(s, typeof(FrameData)) as FrameData;
            for (int j = 0; j < players.Length; j++) {
                if (playerFrameData[i].playerID == players[j].id)
                {
                    players[j].framePositions.Add(playerFrameData[i]);
                    break; 
                }
            }
            i++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        foreach(PlayerTransform pt in players)
        {
            if (pt.framePositions[pt.currentFrameIndex + 1].frameID == frameCount)
            {
                pt.currentFrameIndex++;
            }
            else
            {

            }
        }
    }
}
