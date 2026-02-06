using UnityEngine;
using System.Collections;
public class bossRenderer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    SpriteRenderer sr;
    public GameObject disappearPrefab; // 보스 사라질 때 나는 연기 프리팹
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        StartCoroutine(waitOneFrame());
    }
    private void OnDisable()
    {
        disapper();
    }
    public void disapper()
    {
        GameObject tmp = Instantiate(disappearPrefab,gameObject.transform.position, Quaternion.identity);
        Destroy(tmp, 1f);
    }
    IEnumerator waitOneFrame()
    {
        sr.enabled = false;
        yield return null;
        sr.enabled = true;
    }
}
