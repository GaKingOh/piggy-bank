using UnityEngine;

public class coinMonController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameObject coinManager;
    GameObject playerAudio;
    GameObject player;
    void Start()
    {
        coinManager = GameObject.Find("coinChecker");
        playerAudio = GameObject.Find("playerAudio");
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player")) // 플래이어와 trigger 충돌 했을 때
        {
            coinManager.GetComponent<coinChecker>().SetCoin(); // 코인 몇개인지 관리하는 오브젝트의 더하기 함수 호출
            playerAudio.GetComponent<audioController>().GetCoin(); // 플레이어 하위 사운드 오브젝트의 코인 소리 함수 호출
            player.GetComponent<playerHpController>().getDamage();
            Destroy(gameObject); // 코인 자신 삭제
        }
    }
}
