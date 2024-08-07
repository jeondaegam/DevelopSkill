using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCamera : MonoBehaviour
{
    public GameObject MainCamera;
    public float distance = 3f;

    Vector3 startScale;

    // Start is called before the first frame update
    void Start()
    {
        // 오브젝트의 초기 scale
        startScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Camera까지의 거리
        float distanceToCam = Vector3.Distance(MainCamera.transform.position, transform.position);
        Vector3 newScale = startScale * distanceToCam / distance;
        // 거리에 따라 scale을 newScale로 변경 
        transform.localScale = newScale;

        transform.rotation = MainCamera.transform.rotation;
    }
}
