using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;


public class TrajectoryManager : MonoBehaviour
{

    public List<float[,]> Trajectory_Offend = new List<float[,]>();
    public List<float[,]> Trajectory_Defense = new List<float[,]>();

    public List<int> TrajectorySteps = new List<int>();
    public List<int> DefTrajectorySteps = new List<int>(); // Def 軌跡步數

    // private string folder = "/OffensiveTraj/";          // 軌跡資料夾
    // private string filetype = "*.txt";                  // 後贅檔案類型
    public int trajectoryN = 0;                         // 軌跡數量

    public int DefTrajectoryN = 0;                      // Def 軌跡數量

    private TextAsset[] DefTrajectorys;

    public string ds;

    private TextAsset[] trajectorys;
    public string s;

    void Start()
    {
        trajectorys = Resources.LoadAll<TextAsset>("Trajectory");
        trajectoryN = trajectorys.Length;

        foreach (var trajectory in trajectorys)
        {
            string[] content = trajectory.text.Split('\n');
            int _R = Int32.Parse(content[0]);           // row
            int _C = Int32.Parse(content[1]);           // column

            float[,] _trajectory = new float[_R, _C];


            int _r = 0, _c = 0;
            for (int i = 2; i < content.Length; i++)
            {

                if ((content[i]) != "")
                {
                    _trajectory[_r, _c] = float.Parse(content[i]);
                    _c = _c + 1;

                    if (_c == 12)
                    {
                        _c = 0;
                        _r = _r + 1;
                    }
                }
            }

            Trajectory_Offend.Add(_trajectory);
            TrajectorySteps.Add(_R - 1);
            // Debug.Log(_R - 1);

            s = trajectory.text;
        }

        DefTrajectorys = Resources.LoadAll<TextAsset>("D_Trajectory");
        DefTrajectoryN = DefTrajectorys.Length;

        foreach (var DEFtrajectory in DefTrajectorys)
        {
            string[] d_content = DEFtrajectory.text.Split('\n');
            int _dR = Int32.Parse(d_content[0]);           // row
            int _dC = Int32.Parse(d_content[1]);           // column

            float[,] d_trajectory = new float[_dR, _dC];


            int _dr = 0, _dc = 0;
            for (int i = 2; i < d_content.Length; i++)
            {

                if ((d_content[i]) != "")
                {
                    d_trajectory[_dr, _dc] = float.Parse(d_content[i]);
                    _dc = _dc + 1;

                    if (_dc == 12)
                    {
                        _dc = 0;
                        _dr = _dr + 1;
                    }
                }
            }

            Trajectory_Defense.Add(d_trajectory);
            DefTrajectorySteps.Add(_dR - 1);
            // Debug.Log(_dR - 1);

            ds = DEFtrajectory.text;
        }


        // Get_OffendTrajectoryForHMM();
    }


    // 取得防守方軌跡
    // public void Get_OffendTrajectoryForHMM()
    // {

    //     string s = "";

    //     for (int n = 0; n < trajectoryN; n++)
    //     {


    //         List<Vector2>[] Trajectory_Offend_forHMM = new List<Vector2>[5];
    //         List<Vector2> Trajectory_Ball_forHMM = new List<Vector2>();

    //         // 根據戰術 ID 取得完整軌跡
    //         float[,] _trajecotry = Trajectory_Offend[n];


    //         for (int i = 0; i < Trajectory_Offend_forHMM.Length; i++)
    //             Trajectory_Offend_forHMM[i] = new List<Vector2>();



    //         // 取得軌跡總步數 -> 整理軌跡 第 i 步
    //         for (int i = 0; i < TrajectorySteps[n]; i++)
    //         {
    //             Vector2 _ball = new Vector2(_trajecotry[i, 0], _trajecotry[i, 1]);
    //             Vector2 _player1 = new Vector2(_trajecotry[i, 2], _trajecotry[i, 3]);
    //             Vector2 _player2 = new Vector2(_trajecotry[i, 4], _trajecotry[i, 5]);
    //             Vector2 _player3 = new Vector2(_trajecotry[i, 6], _trajecotry[i, 7]);
    //             Vector2 _player4 = new Vector2(_trajecotry[i, 8], _trajecotry[i, 9]);
    //             Vector2 _player5 = new Vector2(_trajecotry[i, 10], _trajecotry[i, 11]);

    //             Trajectory_Ball_forHMM.Add(_ball);
    //             Trajectory_Offend_forHMM[0].Add(_player1);
    //             Trajectory_Offend_forHMM[1].Add(_player2);
    //             Trajectory_Offend_forHMM[2].Add(_player3);
    //             Trajectory_Offend_forHMM[3].Add(_player4);
    //             Trajectory_Offend_forHMM[4].Add(_player5);
    //         }

    //         float[,] _trajectory = new float[TrajectorySteps[n], 10];

    //         List<Vector2>[] Trajectory_Defense_forHMM = ParametricDefender(Trajectory_Offend_forHMM, Trajectory_Ball_forHMM, false, new Vector2(0.0f, 12.7f));

    //         for (int i = 0; i < Trajectory_Defense_forHMM.Length; i++)
    //         {
    //             for (int j = 0; j < Trajectory_Defense_forHMM[i].Count; j++)
    //             {
    //                 _trajectory[j, i * 2] = Trajectory_Defense_forHMM[i][j][0];
    //                 _trajectory[j, i * 2 + 1] = Trajectory_Defense_forHMM[i][j][1];
    //             }
    //         }

    //         Trajectory_Defense.Add(_trajectory);

    //     }
    // }

    // public List<Vector2>[] ParametricDefender(List<Vector2>[] offendPaths, List<Vector2> ballPath, bool ballHasUpdate, Vector2 hoopPosition)
    // {
    //     // 0.62 * defender + 0.11 * ball + 0.27 * hoop
    //     List<Vector2>[] defendPaths = new List<Vector2>[5];
    //     for (int i = 0; i < 5; i++)
    //     {
    //         defendPaths[i] = new List<Vector2>();
    //         if (offendPaths[i].Count <= 1 && !ballHasUpdate)
    //             continue;

    //         // 如果這一次戰術步驟中有進攻者移動
    //         if (offendPaths[i].Count > 1)
    //         {
    //             for (int j = 0; j < offendPaths[i].Count; j++)
    //             {
    //                 if (j < ballPath.Count)
    //                     defendPaths[i].Add(CalculateParametricPosition(offendPaths[i][j], ballPath[j], hoopPosition));
    //                 else
    //                     defendPaths[i].Add(CalculateParametricPosition(offendPaths[i][j], ballPath.Last(), hoopPosition));
    //             }
    //         }
    //         else
    //         {
    //             for (int j = 0; j < ballPath.Count; j++)
    //             {
    //                 if (j < ballPath.Count)
    //                     defendPaths[i].Add(CalculateParametricPosition(offendPaths[i][0], ballPath[j], hoopPosition));
    //             }
    //         }

    //     }

    //     return defendPaths;
    // }

    public Vector2 CalculateParametricPosition(Vector2 position, Vector2 ballPosition, Vector2 hoopPosition)
    {

        return 0.62f * (position) + 0.11f * (ballPosition) + 0.27f * hoopPosition;
    }


    public Vector2 GetPosition(int questionID, int stepID, int playerID)
    {
        // playerid = 0 --> ball, playerid = 1 --> user
        // Debug.Log(playerID);
        float x = Trajectory_Offend[questionID][stepID, playerID * 2];
        float z = Trajectory_Offend[questionID][stepID, playerID * 2 + 1];
        // Debug.Log(x);
        // Debug.Log(z);
        return new Vector2(x, z);
    }


    public Vector2 GetPosition_Defender(int questionID, int stepID, int playerID)
    {
        float x = Trajectory_Defense[questionID][stepID, playerID * 2];
        float z = Trajectory_Defense[questionID][stepID, playerID * 2 + 1];
        return new Vector2(x, z);
    }
}
