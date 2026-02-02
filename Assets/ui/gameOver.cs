using UnityEngine;

public class gameOver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
    }

}
