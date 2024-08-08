using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorParameter : MonoBehaviour
{
    [SerializeField]
    private Animator Animator;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Animator.SetTrigger("LoseTrigger");
        }
        
    }
}
