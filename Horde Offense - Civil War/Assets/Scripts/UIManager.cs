using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text lifeText;

    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void setLifeText(string text)
    {
        lifeText.text = text;
    }
}
