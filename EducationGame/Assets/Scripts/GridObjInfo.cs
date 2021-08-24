using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridObjInfo : MonoBehaviour
{
    public int numberValue;
    public TMP_Text textInfo;

    public void SetObjectInfo(int value)
    {
        numberValue = value;

        textInfo = gameObject.GetComponentInChildren<TMP_Text>();
        textInfo.text = numberValue.ToString();
    }

}
