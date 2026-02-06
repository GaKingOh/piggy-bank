using Unity.VisualScripting;
using UnityEngine;

public class roketSponer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject rocketPrefab;
    GameObject player;
    [SerializeField] private GameObject airBallon;
    float time = 0;
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - time > 3)
        {
            time = Time.time;
            if (canShoot())
            {
                Instantiate(rocketPrefab,airBallon.transform.position,Quaternion.identity,gameObject.transform);
            }
        }
    }
    bool canShoot()
    {
        float dis = Mathf.Abs(player.transform.position.x -  airBallon.transform.position.x);
        return (dis >= 5f);
    }
}
