using UnityEditor;
using UnityEngine;

public class RocksponerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameObject[] rock_prefab; // 스테이지마다 다른 돌들을 받는 배열
    float timerange = 6;

    public GameObject parent; 
    float timeLimit = 5;
    float time = 0;
    Vector3 spawn = new Vector3(10f, -3.1f, 0f);
    void Start()
    {
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rock_prefab.Length);
        if (rock_prefab == null) return;
        if(Time.time-time>timeLimit)
        {
            int idx = Random.Range(0, rock_prefab.Length);
            Instantiate(rock_prefab[idx],spawn,Quaternion.identity,parent.transform);
            time = Time.time;
            timeLimit = Random.Range(2, timerange);
        }
    }
    public void SetRockPrefab(GameObject[] rockPrefab, int timeRange = 5)
    {
        this.rock_prefab = rockPrefab;
        this.timerange = timeRange;
    }
}
