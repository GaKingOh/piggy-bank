using UnityEngine;

public class obstacleMover : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    timeManager timekeeper;
    void Start()
    {
        timekeeper = GameObject.Find("timekeeper").GetComponent<timeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -15f) Destroy(gameObject);
        transform.position += Vector3.left * timekeeper.obstacle_speed * Time.deltaTime;
    }
}
