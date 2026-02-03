using UnityEngine;

public class timeManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float obstacle_speed = 2.5f;
    public GameObject boss;
    public GameObject coinChecker;
    float time = 0;
    int boss_coint_limit = 50;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(coinChecker.GetComponent<coinChecker>().GetCoin() >= boss_coint_limit)
        {
            boss.SetActive(true);   
        }
        if(obstacle_speed < 15 && Time.time - time > 5)
        {
            obstacle_speed += 0.5f;
            time = Time.time;
        }
    }
}
