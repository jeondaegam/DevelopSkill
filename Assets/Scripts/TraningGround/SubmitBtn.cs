using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitBtn : MonoBehaviour
{
    [SerializeField]
    private UIInputWindow UIInputWindow;

    private Button myButton;
    // Start is called before the first frame update
    void Start()
    {
        myButton = transform.GetComponent<Button>();
        myButton.onClick.AddListener(() => UIInputWindow.Show());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
