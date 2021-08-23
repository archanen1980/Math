using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public int sizeX = 10;
    public int sizeY = 10;

    public GameObject gridObjects;

    private void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                int randGridObjValue = Random.Range(0, 9);
                Vector2 gridPos = new Vector3(x, y);
                GameObject newGridObj = Instantiate(gridObjects, gridPos, Quaternion.identity);

                newGridObj.GetComponent<GridObjInfo>().numberValue.ToString();
                newGridObj.GetComponent<GridObjInfo>().SetObjectInfo(randGridObjValue);
            }
        }
    }
}
