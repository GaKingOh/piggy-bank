using UnityEngine;

public class block1Controller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Transform[] chunks;
    Vector3 end;
    [SerializeField]
    float chunkWidth = 4; // 청크 사이의 간격
    private void Awake()
    {
        int count = transform.childCount; // 자식의 수를 받는 방법
        chunks = new Transform[count]; // 자식의 수만큼 위치를 받는 배열을 할당

        for (int i = 0; i < count;i++)
        {
            chunks[i] = transform.GetChild(i); // 자식의 위치를 받기
        }

        end = new Vector3(-10, chunks[0].position.y, chunks[0].position.z);
        Debug.Log(count);
    }

    private void Update()
    {

        for(int i=0;i< chunks.Length;i++)
        {
            if (chunks[i] == null) continue;

            chunks[i].position += Vector3.left * Time.deltaTime * 2f; // 바닥의 이동 속도
            if (chunks[i].position.x < end.x)
            {
                Vector3 before = chunks[(i - 1 + chunks.Length) % chunks.Length].position;
                chunks[i].position = new Vector3(
                    before.x + chunkWidth,
                    before.y,
                    before.z
                    );
            }
        }
    }
}
