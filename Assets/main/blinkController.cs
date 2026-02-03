using TMPro;
using UnityEngine;
using System.Collections;
public class blinkController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    TMP_Text text;
    float speed = 1f; // 깜빡 속도 (작을수록 느림)

    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        // 0 ~ 1 사이를 부드럽게 왕복
        float alpha = Mathf.PingPong(Time.time * speed, 1f);

        text.color = new Color(
            text.color.r,
            text.color.g,
            text.color.b,
            alpha
        );
    }
}
