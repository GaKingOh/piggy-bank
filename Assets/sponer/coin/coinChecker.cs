using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class coinChecker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int total_coin = -1;
    [SerializeField] private TextMeshProUGUI coinText;
    void Start()
    {
        SetCoin();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetCoin()
    {
        this.total_coin++;
        coinText.text = $"¡¿ {this.total_coin}";
    }
}
