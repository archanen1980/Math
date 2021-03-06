using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int solutionNumbers = 2;
    public GameObject value1;
    public GameObject value2;
    public GameObject answerValue;
    public GameObject operator1;
    public int selectedAnswer;
    GameObject firstSelection;
    GameObject secondSelection;
    public static GameObject InstantiatedMarkerObject1;
    public static GameObject InstantiatedMarkerObject2;

    public int randOperator;

    GridGenerator gridGeneratorScript;
    PlayerInput playerInputScript;

    private void Start()
    {
        gridGeneratorScript = GameObject.FindObjectOfType<GridGenerator>();
        playerInputScript = GameObject.FindObjectOfType<PlayerInput>();

        ChooseRandomNumbers();
        ChooseEquation();
    }

    void ChooseEquation()
    {
        randOperator = Random.Range(0, 3);

        if (randOperator == 0) // Addition
        {
            operator1.GetComponent<TMP_Text>().text = "+";

            answerValue.GetComponent<GridObjInfo>().numberValue = firstSelection.GetComponent<GridObjInfo>().numberValue + secondSelection.GetComponent<GridObjInfo>().numberValue;
            answerValue.GetComponent<GridObjInfo>().SetObjectInfo(answerValue.GetComponent<GridObjInfo>().numberValue);
        }
        else if (randOperator == 1) // Subtraction
        {
            operator1.GetComponent<TMP_Text>().text = "-";

            answerValue.GetComponent<GridObjInfo>().numberValue = firstSelection.GetComponent<GridObjInfo>().numberValue - secondSelection.GetComponent<GridObjInfo>().numberValue;
            answerValue.GetComponent<GridObjInfo>().SetObjectInfo(answerValue.GetComponent<GridObjInfo>().numberValue);
        }
        else if (randOperator == 2) // Multiplication
        {
            operator1.GetComponent<TMP_Text>().text = "x";

            answerValue.GetComponent<GridObjInfo>().numberValue = firstSelection.GetComponent<GridObjInfo>().numberValue * secondSelection.GetComponent<GridObjInfo>().numberValue;
            answerValue.GetComponent<GridObjInfo>().SetObjectInfo(answerValue.GetComponent<GridObjInfo>().numberValue);
        }
        else
        {
            return;
        }
        /*
        else if (randOperator == 3)
        {
            if (firstSelection.GetComponent<GridObjInfo>().numberValue == 0 || firstSelection.GetComponent<GridObjInfo>().numberValue == 0)
            {
                NewRound();
                Debug.Log("Cannot divide by 0");
            }
            else
            {
                operator1.GetComponent<TMP_Text>().text = "/";

                answerValue.GetComponent<GridObjInfo>().numberValue = firstSelection.GetComponent<GridObjInfo>().numberValue / secondSelection.GetComponent<GridObjInfo>().numberValue;
                answerValue.GetComponent<GridObjInfo>().SetObjectInfo(answerValue.GetComponent<GridObjInfo>().numberValue);
            }
        }
        */
    }

    void ChooseRandomNumbers()
    {
        int randSelection1 = Random.Range(0, gridGeneratorScript.gridObjects.Count);
        firstSelection = gridGeneratorScript.gridObjects[randSelection1].transform.gameObject;

        Vector2 dirUp = gridGeneratorScript.gridObjects[randSelection1].transform.position + transform.up;
        Vector2 startPosUp = new Vector2(gridGeneratorScript.gridObjects[randSelection1].transform.position.x, gridGeneratorScript.gridObjects[randSelection1].transform.position.y + .6f);

        Vector2 dirRight = gridGeneratorScript.gridObjects[randSelection1].transform.position + transform.right;
        Vector2 startPosRight = new Vector2(gridGeneratorScript.gridObjects[randSelection1].transform.position.x + .6f, gridGeneratorScript.gridObjects[randSelection1].transform.position.y);

        Vector2 dirDown = gridGeneratorScript.gridObjects[randSelection1].transform.position - transform.up;
        Vector2 startPosDown = new Vector2(gridGeneratorScript.gridObjects[randSelection1].transform.position.x, gridGeneratorScript.gridObjects[randSelection1].transform.position.y - .6f);

        Vector2 dirLeft = gridGeneratorScript.gridObjects[randSelection1].transform.position - transform.right;
        Vector2 startPosLeft = new Vector2(gridGeneratorScript.gridObjects[randSelection1].transform.position.x - .6f, gridGeneratorScript.gridObjects[randSelection1].transform.position.y);

        RaycastHit2D hitUp = Physics2D.Raycast(startPosUp, dirUp);
        RaycastHit2D hitRight = Physics2D.Raycast(startPosRight, dirRight);
        RaycastHit2D hitDown = Physics2D.Raycast(startPosDown, dirDown);
        RaycastHit2D hitLeft = Physics2D.Raycast(startPosLeft, dirLeft);

        int randSelection2 = Random.Range(0, 4);
       
        if(randSelection2 == 0 && hitUp.transform != null)
        {
            secondSelection = hitUp.transform.gameObject;
        }
        else if (randSelection2 == 1 && hitRight.transform != null)
        {
            secondSelection = hitRight.transform.gameObject;
        }
        else if (randSelection2 == 2 && hitDown.transform != null)
        {
            secondSelection = hitDown.transform.gameObject;
        }
        else if (randSelection2 == 3 && hitLeft.transform != null)
        {
            secondSelection = hitLeft.transform.gameObject;
        }
        else
        {
            return;
        }

    }

    public void SubmitSelections()
    {
        
        if (randOperator == 0) // Addition
        {
            selectedAnswer = int.Parse(value1.GetComponent<TMP_Text>().text) + int.Parse(value2.GetComponent<TMP_Text>().text);
        }
        else if (randOperator == 1) // Subtraction
        {
            selectedAnswer = int.Parse(value1.GetComponent<TMP_Text>().text) - int.Parse(value2.GetComponent<TMP_Text>().text);
        }
        else if (randOperator == 2) // Multiplication
        {
            selectedAnswer = int.Parse(value1.GetComponent<TMP_Text>().text) * int.Parse(value2.GetComponent<TMP_Text>().text);
        }
        else
        {
            return;
        }
        CheckMath();
    }

    public void CheckMath()
    {
        if (selectedAnswer == answerValue.GetComponent<GridObjInfo>().numberValue)
        {
            Debug.Log(selectedAnswer);
            Debug.Log(answerValue.GetComponent<GridObjInfo>().numberValue);
            Debug.Log("Correct");
        }
        else if(selectedAnswer != answerValue.GetComponent<GridObjInfo>().numberValue)
        {
            Debug.Log(selectedAnswer);
            Debug.Log(answerValue.GetComponent<GridObjInfo>().numberValue);
            Debug.Log("Incorrect");
        }

        NewRound();
    }

    public void NewRound()
    {
        PlayerInput.clickAmount = 0;
        firstSelection = null;
        secondSelection = null;
        playerInputScript.selectedObj.Clear();

        value1.GetComponent<TMP_Text>().text = "";
        value2.GetComponent<TMP_Text>().text = "";

        Destroy(InstantiatedMarkerObject1);
        Destroy(InstantiatedMarkerObject2);

        ChooseRandomNumbers();
        ChooseEquation();
        

    }
}
