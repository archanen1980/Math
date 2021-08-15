using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int gridX = 0;
    public int gridY = 0;

    public GameObject[] gridObjects;

    private void Start()
    {
        for (int x = 0; x < gridX; x++)
        {
            for (int y = 0; y < gridY; y++)
            {
                Vector2 newPos = new Vector3(x, y);

                int randNum = Random.Range(0, gridObjects.Length);
                GameObject gem = Instantiate(gridObjects[randNum], newPos, Quaternion.identity);
            }
        }
    }
}
