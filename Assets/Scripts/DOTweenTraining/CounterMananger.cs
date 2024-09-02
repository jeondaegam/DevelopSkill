using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CounterMananger : MonoBehaviour
{
    public Button addScoreBtn;
    public Button resetScoreBtn;
    public Text counterText;

    public static CounterMananger Instance { get; private set; }

    int startValue = 0;
    int endValue = 0;
    int addedValue = 1000;
    float duration = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        addScoreBtn.onClick.AddListener(OnAddScoreBtnClick);
        resetScoreBtn.onClick.AddListener(OnResetScoreBtnClick);
    }

    private void OnResetScoreBtnClick()
    {
        startValue = 0;
        counterText.text = startValue.ToString();
    }

    private void OnAddScoreBtnClick()
    {
        //버튼 클래스 . Add Score
        endValue = startValue + addedValue;
        DOTween.To(() => startValue, x => startValue = x, endValue, duration)
            .OnUpdate(() => counterText.text = startValue.ToString());
        
    }

}
