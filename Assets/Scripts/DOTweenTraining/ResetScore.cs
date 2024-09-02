using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetScore : MonoBehaviour
{

    [SerializeField]
    private Text counterText;

    [SerializeField]
    public Button resetButton;

    private int counterValue = 0;
    // Start is called before the first frame update
    void Start()
    {
        resetButton.onClick.AddListener(OnResetBtnClick);
    }

    private void OnResetBtnClick()
    {
        counterText.text = counterValue.ToString();

        // 외부 클래스의 변수를 직접 가져와 변경하는 것보다, 메서드로 처리하기
        // 그러기 위해서는 리셋버튼과 Add 버튼을 모두 들고있는 Manager 클래스를 만드는것이 적절하다 . 
        AddScoreAnimation.startValue = counterValue;
    }

}
