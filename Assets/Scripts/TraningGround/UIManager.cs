using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI message;

    [SerializeField]
    private TextCube textBlockPrefab;
    [SerializeField]
    private TextMeshPro BlockText;

    // 백스페이스로 지울때도 문자열이 변하니까 마구잡이로 생성되는데
    // 이전문자열 길이랑 비교해서 길이가 더 커졌을 때만 블록 생성되게 해야겟음 

    // input field 값이 변했을 때 
    public void OnValueChanged(string newText)
    {
        message.text = $"Value Changed: {newText}";
        BlockText.text = getLastStr(newText);

        TextCube newCube = Instantiate(textBlockPrefab, transform.position, transform.rotation);
        newCube.SetText(getLastStr(newText));
    }

    private string getLastStr(string newText)
    {
        if (newText.Length > 0)
        {
            Debug.Log("new text : " + newText.Substring(newText.Length - 1));
            return newText.Substring(newText.Length - 1);
        }else
        {
            return newText;
        }
        
    }

    // input field에 값을 입력하고 enter를 눌렀을 때 
    public void OnEndEdit(string str)
    {
        message.text = $"End Edit: {str}";
    }

    // input field가 활성화 되었을 때
    public void OnSelect(string str)
    {
        message.text = $"Select : {str}";
    }

    // input field가 비활성화 되었을 때  
    public void OnDeselectEvent(string str)
    {
        message.text = $"Deselect : {str}";
    }
}
