using UnityEngine;

public class coinSponerController : MonoBehaviour
{
    public GameObject[] obstacle_prefab;
    public GameObject parent;
    float timeLimit = 5;
    float time = 0;
    Vector3 spawn = new Vector3(10f, 3f, 0f);
    void Start()
    {
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time - time > timeLimit)
        {
            Instantiate(obstacle_prefab[0], spawn, Quaternion.identity, parent.transform);
            Debug.Log(Time.time - time);
            time = Time.time;
            timeLimit = Random.Range(2, 6);
        }
    }
}
