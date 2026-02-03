using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class loadController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(loading());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator loading()
    {

        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("play1");
    }
}
