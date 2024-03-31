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
public class ArrayDataWrapper2
{
    public BallHandlerData[] array;
}
[System.Serializable]
public class FrameData
{
    public int frameID;
    public int playerID;
    public float x;
    public float y;
    public int team;
    public bool handleTF;
}

[System.Serializable]
public class BallHandlerData
{
    public int frameID;
    public int ballHandlerID;
}
[System.Serializable]
public class PlayerTransform
{
    public Transform transform;
    public OPlayerController opc;
    public TPlayerController tpc;
    public int id;
    public bool isOffensive;
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
    private static int _FPS=24;
    private float _startTime=0;
    [SerializeField]public PlayerTransform[] players;
    #region
    public TextAsset[] dataTextAssets;

    private string[] tempData= new string[0];
    #endregion
    public int usedDataIndex;
    private int currentUsedDataIndex;
    public int[] ballHandlerIndex=new int[1000];
    private void Awake()
    {
        instance = this;
        tempData = new string[dataTextAssets.Length];
        for (int i = 0; i < dataTextAssets.Length; i++) { tempData[i] = dataTextAssets[i].text; }
        for(int i = 0; i < ballHandlerIndex.Length; i++) { ballHandlerIndex[i] = -1; }
        for(int i = 0; i < players.Length; i++)
        {
            if(players[i].transform.TryGetComponent<OPlayerController>(out OPlayerController opc))
            {
                players[i].opc = opc;
            }

            if (players[i].transform.TryGetComponent(out TPlayerController tpc))
            {
                players[i].tpc = tpc;
            }
        }
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
        UpdatePlayerPositionData();
    }
    private void Update()
    {
        if (currentUsedDataIndex != usedDataIndex)
        {
            UpdatePlayerPositionData();
            currentUsedDataIndex = usedDataIndex;
        }
    }
    public void UpdatePlayerPositionData()
    {
        ArrayDataWrapper wrapper = JsonUtility.FromJson(tempData[usedDataIndex], typeof(ArrayDataWrapper)) as ArrayDataWrapper;
        int i = 0;
        for (int j = 0; j < players.Length; j++)
        {
            players[j].framePositions.Clear();
        }
        foreach (FrameData s in wrapper.array)
        {
            // playerFrameData[i] = s;
            for (int j = 0; j < players.Length; j++)
            {
                if (s.playerID == players[j].id)
                {
                    players[j].framePositions.Add(s);
                    if (s.handleTF) { ballHandlerIndex[s.frameID] = j;}
                    else if(ballHandlerIndex[s.frameID]==j){ ballHandlerIndex[s.frameID] = -1; }
                    break;
                }
            }
            i++;
        }
        currentUsedDataIndex = usedDataIndex;

    }
    // Update is called once per frame
    public void UpdatePosition()
        
    {
        Vector3 offset = new Vector3(5, 0, 15);
        bool hasBallHandler = false;
        foreach(PlayerTransform pt in players)
        {
            if (pt.framePositions.Count <= pt.currentFrameIndex) { continue; }
            Vector3 currentFramePlayer = new Vector3(pt.framePositions[pt.currentFrameIndex].y,0, pt.framePositions[pt.currentFrameIndex].x);
            Vector3 nextFramePlayer=currentFramePlayer;
            if (pt.currentFrameIndex < pt.framePositions.Count - 1) {
                nextFramePlayer = new Vector3(pt.framePositions[pt.currentFrameIndex + 1].y, 0,pt.framePositions[pt.currentFrameIndex + 1].x); 
            }

            if (pt.framePositions[pt.currentFrameIndex + 1].frameID <= frameCount)
            {
                pt.currentFrameIndex++;
                pt.transform.position = nextFramePlayer / 50 * 1.5f - offset;
                if (pt.framePositions[pt.currentFrameIndex].handleTF) { Debug.Log("Found ball handler at frame " + pt.currentFrameIndex + " for " + pt.id); }
                if (pt.opc != null) { 
                    pt.opc.isHoldingBall = pt.framePositions[pt.currentFrameIndex].handleTF;
                    if (pt.framePositions[pt.currentFrameIndex].handleTF) hasBallHandler = true; 
                }
                if (pt.tpc != null)
                {
                    pt.tpc.isHoldingBall = pt.framePositions[pt.currentFrameIndex].handleTF;
                    if (pt.framePositions[pt.currentFrameIndex].handleTF) hasBallHandler = true;
                }
            }
            else if(pt.currentFrameIndex==pt.framePositions.Count-1)
            {
                pt.transform.position = currentFramePlayer/50 * 1.5f - offset;
                if (pt.framePositions[pt.currentFrameIndex].handleTF) { Debug.Log("Found ball handler at frame " + pt.currentFrameIndex + " for " + pt.id); }

                if (pt.opc != null) {
                    pt.opc.isHoldingBall = pt.framePositions[pt.currentFrameIndex].handleTF;
                    if (pt.framePositions[pt.currentFrameIndex].handleTF) hasBallHandler = true;
                }
                if (pt.tpc != null)
                {
                    pt.tpc.isHoldingBall = pt.framePositions[pt.currentFrameIndex].handleTF;
                    if (pt.framePositions[pt.currentFrameIndex].handleTF) hasBallHandler = true;
                }

            }
            else
            {
                if (pt.framePositions[pt.currentFrameIndex].handleTF) { Debug.Log("Found ball handler at frame " + pt.currentFrameIndex + " for " + pt.id); }

                pt.transform.position=Vector3.MoveTowards(currentFramePlayer,nextFramePlayer,
                    (frameCount-pt.currentFrameIndex)/(pt.framePositions[pt.currentFrameIndex+1].frameID-pt.currentFrameIndex))/50 * 1.5f - offset;
                if (pt.opc != null){
                    pt.opc.isHoldingBall = pt.framePositions[pt.currentFrameIndex].handleTF;
                    if (pt.framePositions[pt.currentFrameIndex].handleTF) hasBallHandler = true;
                }
                if (pt.tpc != null)
                {
                    pt.tpc.isHoldingBall = pt.framePositions[pt.currentFrameIndex].handleTF;
                    if (pt.framePositions[pt.currentFrameIndex].handleTF) hasBallHandler = true;
                }

            }

            if (!hasBallHandler) { Debug.Log("No ball handler"); }
        }
    }
    private void LateUpdate()
    {
        frameCount = Mathf.FloorToInt((Time.time - _startTime) * _FPS);
    }
    public PlayerTransform GetClosestDefender(Transform pos, out float retDist)
    {
        float minDist = Mathf.Infinity;
        PlayerTransform closest = null;
        foreach(PlayerTransform pt in players)
        {
            if (pt.isOffensive) continue;
            float dist = Vector3.Distance(pt.transform.position, pos.position);
            if (dist < minDist)
            {
                closest = pt;
                minDist = dist;
            }
        }
        retDist = minDist;
        return closest;
    }
    public PlayerTransform GetClosestOffense(Transform pos, out float retDist)
    {
        float minDist = Mathf.Infinity;
        PlayerTransform closest = null;
        foreach (PlayerTransform pt in players)
        {

            if (!pt.isOffensive) continue;
            float dist = Vector3.Distance(pt.transform.position, pos.position);
            if (dist < minDist)
            {
                closest = pt;
                minDist = dist;
            }
        }
        retDist = minDist;
        return closest;
    }
}
