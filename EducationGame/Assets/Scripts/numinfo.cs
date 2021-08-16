using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class numInfo : MonoBehaviour
{
    public int numberInfo;
    public TMP_Text textInfo;

    private void Start()
    {
        textInfo = gameObject.GetComponentInChildren<TMP_Text>();
        textInfo.text = numberInfo.ToString();
    }
}
