using UnityEngine;

public class timeManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /*
     * stage manager에서 값을 받을 것
     */
    public float obstacle_speed = 2.5f;
    public float speedPlus = 0.5f;
    GameObject[] boss;
    public GameObject coinChecker;
    public GameObject bossManager;
    public GameObject stageManger;
    public GameObject gameOverPanel;
    public GameObject musicPlayer;
    float time = 0;
    int boss_coin_limit = 50;

    bool bossexist = false;
    int stageCoin = 0;
    void Start()
    {
        
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        musicPlayer.GetComponent<musicPlayerController>().GameOver();
    }
    public void SetStageValue(GameObject[] bossPrefab, float obstacleSpeed, float speedPlus, int coin_limit = 50)
    {
        this.obstacle_speed = obstacleSpeed;
        this.speedPlus = speedPlus;
        this.boss = bossPrefab;
        this.boss_coin_limit = coin_limit;
    }
    // Update is called once per frame
    void Update()
    {
        if(coinChecker.GetComponent<coinChecker>().GetCoin() - stageCoin >= boss_coin_limit && !bossexist)
        {
            bossexist = true; // 보스 있는지 확인 후 없으면 생성
            GameObject.Find("musicPlayer").GetComponent<AudioSource>().pitch = 1.25f;
            foreach(GameObject tmp in boss)
            {
                Instantiate(tmp,bossManager.transform);
            }
        }
        if (obstacle_speed < 15 && Time.time - time > 5)
        {
            obstacle_speed += speedPlus;
            time = Time.time;
        }

        if(coinChecker.GetComponent <coinChecker>().GetCoin() - stageCoin >=50) // 다음 스테이지로 넘어가는 루틴
        {
            bossexist = false; // 보스 flag 초기화 
            GameObject.Find("musicPlayer").GetComponent<AudioSource>().pitch = 1f;
            stageCoin = coinChecker.GetComponent<coinChecker>().GetCoin();
            stageManger.GetComponent<stageController>().nextStage();

            foreach (Transform child in bossManager.transform)
            {
                child.gameObject.GetComponent<bossDelete>().RemoveBoss();
            }
        }
    }
}
