using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderController : MonoBehaviour
{
    [Header("Hit Target")]
    [SerializeField] private LayerMask targetLayer; // Obstacle 레이어만 체크해두기 추천

    [Header("Invincible")]
    [SerializeField] private float invincibleTime = 1.0f;
    [SerializeField] private float blinkInterval = 0.1f;
    [SerializeField] private string invincibleLayerName = "PlayerInvincible";

    [Header("Refs")]
    [SerializeField] private lifeChecker lifeChecker; // 인스펙터에 드래그 추천

    private SpriteRenderer sr;
    private bool invincible;
    private int normalLayer;
    private int invLayer;

    // (선택) 같은 오브젝트 1회만 처리하고 싶으면 유지
    private readonly HashSet<int> hitIds = new HashSet<int>();

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        normalLayer = gameObject.layer;
        invLayer = LayerMask.NameToLayer(invincibleLayerName);

        // 혹시 인스펙터에 안 넣었으면 마지막 보험
        if (!lifeChecker)
            lifeChecker = GameObject.Find("lifeChecker")?.GetComponent<lifeChecker>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (invincible) return;

        if (((1 << other.gameObject.layer) & targetLayer) == 0) return;

        // (선택) 같은 장애물 1번만 데미지
        int id = other.gameObject.GetInstanceID();
        if (hitIds.Contains(id)) return;
        hitIds.Add(id);

        // 데미지
        if (lifeChecker.life > 1)
        {
            lifeChecker.minusLife();
            StartCoroutine(InvincibleRoutine());
        }
        else
        {
            // game over
        }
    }

    private IEnumerator InvincibleRoutine()
    {
        invincible = true;

        // 🔥 충돌 무시 시작: 레이어 변경
        gameObject.layer = invLayer;

        float t = 0f;
        while (t < invincibleTime)
        {
            if (sr) sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(blinkInterval);
            t += blinkInterval;
        }

        // 원복
        if (sr) sr.enabled = true;
        gameObject.layer = normalLayer;

        invincible = false;
    }
}
