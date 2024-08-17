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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

    }

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
