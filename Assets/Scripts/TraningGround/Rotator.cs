using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 100;
    private bool isDragging = false;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // 프레임 레이트에 따라 호출 빈도가 달라지므, 물리 연산의 결과가 일관되지 않을 수 있다 .
    // 물리 엔진과의 동기화가 깨질 수 있다 . 
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

    }

    // 프레임 레이트와 무관하게 일정한 시간 간격으로 호출된다
    // 따라서 물리 연산이 일정한 시간 간격으로 처리된다
    private void FixedUpdate()
    {
        if (isDragging)
        {
            float xDirection = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime; // phisics값도 같이 적용하는듯 ?
            float yDirection = Input.GetAxis("Mouse Y") * rotationSpeed * Time.fixedDeltaTime;

            rb.AddTorque(Vector3.down * xDirection);
            rb.AddTorque(Vector3.right * yDirection);
        }
    }

    private void OnMouseDrag()
    {
        isDragging = true;
    }

    private void OnMouseDown()
    {

    }
}
