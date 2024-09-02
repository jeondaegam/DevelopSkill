using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AddScoreAnimation : MonoBehaviour
{
    [SerializeField]
    private Text counterText;

    [SerializeField]
    private Button addScoreButton;

    public static int startValue = 0;
    private int endValue = 0;
    private float duration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        addScoreButton.onClick.AddListener(OnCounterBtnClick);
    }

    private void OnCounterBtnClick()
    {
        endValue = startValue + 1000;

        // 이거 공식 문서에서 찬찬히 뜯어보면 좋을듯
        // DOTween 공식 페이지랑도 친해져보자 
        DOTween.To(()=> startValue, x => startValue = x, endValue, duration)
            .OnUpdate(()=>counterText.text = startValue.ToString());
    }

}
