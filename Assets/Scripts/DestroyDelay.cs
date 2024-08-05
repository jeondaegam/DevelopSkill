using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDelay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // destroy after 2 seconds
        Destroy(gameObject, 2);
    }

}
