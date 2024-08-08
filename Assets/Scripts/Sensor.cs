using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Collider와 Collider의 충돌을 감지한다
        // Is Trigger가 체크된 콜라이더가 충돌하면 이를 감지한다

        //if(other.CompareTag("Good"))
        //{
        //    GameManager.Instance.GameOver();
        //}
        Destroy(other.gameObject);
    }
}
