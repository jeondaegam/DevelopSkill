using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectModeButton : MonoBehaviour
{
    // referencing
    public int level;

    // private
    private Button button;

    private void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(SetGameLevel);
    }

    private void SetGameLevel()
    {
        GameManager.Instance.GameStart(level);
    }
}
