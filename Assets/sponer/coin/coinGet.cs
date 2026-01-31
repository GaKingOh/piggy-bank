using UnityEngine;

public class coinGet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameObject coinManager;
    void Start()
    {
        coinManager = GameObject.Find("coinChecker");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("player"))
        {
            coinManager.GetComponent<coinChecker>().SetCoin();
            Destroy(gameObject);
        }
    }
}
