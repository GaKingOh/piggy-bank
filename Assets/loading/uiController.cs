using UnityEngine;
using TMPro;
public class uiController : MonoBehaviour
{
    float time;
    int idx = 0;
    public TMP_Text tmp;
    void Start()
    {
        
    }
    string[] text = {
        "Loading",
        "Loading .",
        "Loading ..",
        "Loading ..."
    };
    
    // Update is called once per frame
    void Update()
    {
        if(Time.time-time>=0.5f)
        {
            time = Time.time;
            tmp.text = text[(++idx)%text.Length];
        }
    }
}
