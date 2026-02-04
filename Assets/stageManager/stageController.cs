using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class stageController : MonoBehaviour
{
    [SerializeField] private GameObject coinSponer;
    [SerializeField] private GameObject obstacleSponer;
    [SerializeField] private GameObject timeManager;

    [Header("stage1")]
    public GameObject[] stage1RockPrefabs;
    public GameObject[] stage1coinPrefabs;
    public GameObject[] stage1bossPrefabs;

    [Header("stage2")]
    public GameObject[] stage2RockPrefabs;
    public GameObject[] stage2coinPrefabs;
    public GameObject[] stage2bossPrefabs;

    public int now_stage = 1;

    Dictionary<int, Action> stage_dic;
    public void SetEnvironment()
    {
        switch (now_stage)
        {
            case 1: 
                Stage1();
                break;

            case 2: Stage2();
                break;
        }
    }
    private void Awake()
    {
        stage_dic = new Dictionary<int, Action>();
        stage_dic[1] = Stage1;
        stage_dic[2] = Stage2;

        SetEnvironment();
    }
    private void Update()
    {  
    }
    public void runStage()
    {
        stage_dic[now_stage]();
    }
    public void nextStage()
    {
        now_stage++;
        if (now_stage >= 3) return;
        stage_dic[now_stage]();
    }
    public IEnumerator changeStage()
    {
        yield return new WaitForSeconds(3f);
    }
    /// <summary>
    /// ////////////////////////////////////////////
    /// 
    /// </summary>
    /// 


    void Stage1()
    {
        int cointimerange = 6;
        int rocktimerange = 5;
        coinSponer.GetComponent<coinSponerController>().SetCoinPrefab(stage1coinPrefabs,cointimerange); // 코인, 생성 주기
        obstacleSponer.GetComponent<RocksponerController>().SetRockPrefab(stage1RockPrefabs,rocktimerange); // 돌, 생성 주기


        int coinlimit = 5;
        float obstaclespeed = 2.5f;
        timeManager.GetComponent<timeManager>().SetStageValue(stage1bossPrefabs[0],obstaclespeed,coinlimit); // 보스, 장애물 속도, 코인 먹어야하는 개수
    }
    void Stage2()
    {
        int cointimerange = 4;
        int rocktimerange = 3;
        coinSponer.GetComponent<coinSponerController>().SetCoinPrefab(stage2coinPrefabs, cointimerange); // 코인, 생성 주기
        obstacleSponer.GetComponent<RocksponerController>().SetRockPrefab(stage2RockPrefabs, rocktimerange); // 돌, 생성 주기


        int coinlimit = 15;
        float obstaclespeed = 3.0f;
        timeManager.GetComponent<timeManager>().SetStageValue(stage1bossPrefabs[0], obstaclespeed, coinlimit); // 보스, 장애물 속도, 코인 먹어야하는 개수
    }
}
