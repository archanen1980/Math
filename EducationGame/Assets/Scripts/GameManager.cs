using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int gridX = 0;
    public int gridY = 0;
    public int drawnNum1;
    public int drawnNum2;
    public int calculatedNumb = 0;
    public int calculatedNumb2 = 0;
    public int randNum2;
    public Vector2 numVect;
    public GameObject circleSprite;

    public GameObject gridObjects;
    public GameObject numObjects;

    public List<GameObject> instantiatedNumbers = new List<GameObject>();

    numInfo numInfo;


    private void Start()
    {
     
        for (int x = 0; x < gridX; x++)
        {
            for (int y = 0; y < gridY; y++)
            {
                Vector2 newPos = new Vector3(x, y);

                int randNum = Random.Range(0, 9);
                GameObject newObject = Instantiate(gridObjects, newPos, Quaternion.identity);
                newObject.transform.parent = numObjects.transform;
                instantiatedNumbers.Add(newObject);

                newObject.GetComponent<numInfo>().numberInfo = randNum;
                
            }
        }

        randNum2 = Random.Range(0, instantiatedNumbers.Count);
        drawnNum1 = instantiatedNumbers[randNum2].GetComponent<numInfo>().numberInfo;
        //GameObject.Destroy(instantiatedNumbers[randNum2]);


        //calculatedNumb = randNum2;
        numVect = new Vector2(instantiatedNumbers[randNum2+1].transform.position.x, instantiatedNumbers[randNum2+1].transform.position.y);
        int randNum3 = Random.Range(0, 3);
        Instantiate(circleSprite, numVect, Quaternion.identity);


        //if(randNum3 == 0 && randNum2 >= 10) { calculatedNumb2 = randNum2 + calculatedNumb; } // North
        //else if (randNum3 == 1 && randNum2) { calculatedNumb2 = randNum2 + 1; } // East
        //else if (randNum3 == 2 && randNum2 <= (instantiatedNumbers.Count - 10)) { calculatedNumb2 = randNum2 + calculatedNumb; } // South
        //else if (randNum3 == 3 && randNum2) { calculatedNumb2 = randNum2 - 1; } // West

    }
}
