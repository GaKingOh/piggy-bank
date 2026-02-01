using UnityEngine;
using UnityEngine.UI;
public class lifeChecker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int life = 3;
    [SerializeField] private Image[] hearts;
    void Start()
    {
        
    }
    public void minusLife()
    {
        if (life > 0) life--;
    }
    // Update is called once per frame
    void Update()
    {
        if(life == 2) hearts[2].enabled = false;
        else if(life == 1) hearts[1].enabled = false;
        else if(life == 0) hearts[0].enabled = false;

    }
}
