using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public int sizeX = 10;
    public int sizeY = 10;

    public GameObject parentObj;
    public GameObject gridObject;
    public List<GameObject> gridObjects = new List<GameObject>();

    private void Awake()
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
                GameObject newGridObj = Instantiate(gridObject, gridPos, Quaternion.identity);
                gridObjects.Add(newGridObj);
                newGridObj.name = gridPos.ToString();
                newGridObj.transform.parent = parentObj.transform;

                newGridObj.GetComponent<GridObjInfo>().numberValue.ToString();
                newGridObj.GetComponent<GridObjInfo>().SetObjectInfo(randGridObjValue);
            }
        }
    }
}
