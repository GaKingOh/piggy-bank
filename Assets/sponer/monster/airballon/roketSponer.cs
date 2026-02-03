using Unity.VisualScripting;
using UnityEngine;

public class roketSponer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject airBallon;
    float time = 0;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - time > 5)
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
