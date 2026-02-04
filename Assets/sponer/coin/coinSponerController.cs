using UnityEngine;

public class coinSponerController : MonoBehaviour
{
    GameObject[] coin_prefab; // 스테이지마다 다른 코인을 받는 변수
    float timerange = 6; // 생성 주기

    public GameObject parent;
    float timeLimit = 5;
    float time = 0;
    Vector3 spawn = new Vector3(10f, 0f, 0f);
    void Start()
    {
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (coin_prefab == null) return;
        if (Time.time - time > timeLimit)
        {
            int idx = Random.Range(0, coin_prefab.Length);

            Instantiate(coin_prefab[idx], spawn, Quaternion.identity, parent.transform);
            time = Time.time;
            timeLimit = Random.Range(2, timerange);
        }
    }
    public void SetCoinPrefab(GameObject[] coinPrefab, int timeRange = 5)
    {
        this.coin_prefab = coinPrefab;
        this.timerange = timeRange;
    }
}
