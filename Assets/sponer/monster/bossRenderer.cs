using UnityEngine;
using System.Collections;
public class bossRenderer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        
    }
    IEnumerator waitOneFrame()
    {
        sr.enabled = false; 
        yield return null;
        sr.enabled = true;
    }
}
