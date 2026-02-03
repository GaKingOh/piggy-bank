using UnityEditor;
using UnityEngine;

public class RocksponerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] obstacle_prefab;
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

        if(Time.time-time>timeLimit)
        {
            int idx = Random.Range(0, obstacle_prefab.Length);
            Instantiate(obstacle_prefab[idx],spawn,Quaternion.identity,parent.transform);
            time = Time.time;
            timeLimit = Random.Range(2, 6);
        }
    }
}
