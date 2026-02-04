using UnityEngine;

public class timeManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /*
     * stage manager에서 값을 받을 것
     */
    public float obstacle_speed = 2.5f; 
    GameObject boss;
    public GameObject coinChecker;
    public GameObject bossManager;
    public GameObject stageManger;
    float time = 0;
    int boss_coin_limit = 50;

    bool bossexist = false;
    void Start()
    {
        
    }
    public void SetStageValue(GameObject bossPrefab, float obstacleSpeed, int coin_limit = 50)
    {
        this.obstacle_speed = obstacleSpeed;
        this.boss = bossPrefab;
        this.boss_coin_limit = coin_limit;
    }
    // Update is called once per frame
    void Update()
    {
        if(coinChecker.GetComponent<coinChecker>().GetCoin() >= boss_coin_limit && !bossexist)
        {
            bossexist = true;
            Instantiate(boss,bossManager.transform);
        }
        if(obstacle_speed < 15 && Time.time - time > 5)
        {
            obstacle_speed += 0.5f;
            time = Time.time;
        }

        if(coinChecker.GetComponent <coinChecker>().GetCoin() >=10)
        {
            stageManger.GetComponent<stageController>().nextStage();
        }
    }
}
