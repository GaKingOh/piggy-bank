using UnityEngine;

public class coinSin : MonoBehaviour
{
    Vector3 startLocalPos;

    void Start()
    {
        startLocalPos = transform.localPosition;
    }

    void Update()
    {
        transform.localPosition = new Vector3(
            startLocalPos.x,
            startLocalPos.y + Mathf.Sin(Time.time + startLocalPos.x) * 1f,
            startLocalPos.z
        );
    }
}
