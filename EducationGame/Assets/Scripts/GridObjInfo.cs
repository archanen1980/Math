using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridObjInfo : MonoBehaviour
{
    public int numberValue;
    public TMP_Text textInfo;

    private void Update()
    {
    }

    public void SetObjectInfo(int value)
    {
        numberValue = value;

        textInfo = gameObject.GetComponentInChildren<TMP_Text>();
        textInfo.text = numberValue.ToString();
    }

    void OnDrawGizmos()
    {
        Vector2 dirUp = transform.position + 1 * transform.up;
        Vector2 startPosUp = new Vector2(transform.position.x, transform.position.y + .6f);

        Gizmos.DrawLine(startPosUp, dirUp);
    }
}
