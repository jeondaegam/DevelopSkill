using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInputWindow : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputField;

    [SerializeField]
    private Button OKBtn, CancelBtn;

    [SerializeField]
    private TextMeshProUGUI titleText;


    private void Awake()
    {
        //Hide();
        //Show();
    }

    private void Start()
    {
        Show();
        CancelBtn.onClick.AddListener(ClickedCancelBtn);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        {
            ClickedOkBtn();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            ClickedCancelBtn();
        }
    }


    private void ClickedCancelBtn()
    {
        Hide();
        ClearInputField();
        //Debug.Log($"Cancel clicked : {inputField.text}");
    }

    private void ClickedOkBtn()
    {
        Hide();
        Debug.Log($"Ok clicked: {inputField.text}");
        ClearInputField();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void ClearInputField()
    {
        inputField.text = "";
    }
}
