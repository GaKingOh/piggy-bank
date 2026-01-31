using UnityEngine;

public class timeManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float obstacle_speed = 2.5f;
    float time = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(obstacle_speed < 15 && Time.time - time > 5)
        {
            obstacle_speed += 0.5f;
            time = Time.time;
        }
    }
}
