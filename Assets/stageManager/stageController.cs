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

    [Header("stage2")]
    public GameObject[] stage3RockPrefabs;
    public GameObject[] stage3coinPrefabs;
    public GameObject[] stage3bossPrefabs;

    [SerializeField] private int now_stage = 1;

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
        // 함수 시그니처를 값으로 받는 map
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


        int coinlimit = 25; // 보스가 나오기 위한 코인의 개수
        float obstaclespeed = 2.5f; // 장애물 시작 속도
        float speedPlus = 0.5f;
        timeManager.GetComponent<timeManager>().SetStageValue(stage1bossPrefabs,obstaclespeed, speedPlus ,coinlimit); // 보스, 장애물 속도, 코인 먹어야하는 개수
    }
    void Stage2()
    {
        int cointimerange = 4;
        int rocktimerange = 3;
        coinSponer.GetComponent<coinSponerController>().SetCoinPrefab(stage2coinPrefabs, cointimerange); // 코인, 생성 주기
        obstacleSponer.GetComponent<RocksponerController>().SetRockPrefab(stage2RockPrefabs, rocktimerange); // 돌, 생성 주기


        int coinlimit = 25;
        float obstaclespeed = 3.5f;
        float speedPlus = 0.75f;
        timeManager.GetComponent<timeManager>().SetStageValue(stage2bossPrefabs, obstaclespeed, speedPlus, coinlimit); // 보스, 장애물 속도, 코인 먹어야하는 개수
    }
    void Stage3()
    {

    }
}
