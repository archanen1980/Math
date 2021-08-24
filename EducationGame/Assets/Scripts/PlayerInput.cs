using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInput : MonoBehaviour
{
    public GameObject markerObject;
    public int clickAmount = 0;

    GameManager gameManagerScript;
    GridObjInfo gridObjInfoScript;

    public List<GameObject> selectedObj = new List<GameObject>();

    private void Start()
    {
        gameManagerScript = GameObject.FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        DrawRayFromMouse();
    }

    void DrawRayFromMouse()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (Input.GetMouseButtonUp(0) && hit.collider != null)
        {
            if (clickAmount < 1)
            {
                Instantiate(markerObject, hit.transform.position, Quaternion.identity);
                selectedObj.Add(hit.transform.gameObject);
                gameManagerScript.value1.GetComponent<TMP_Text>().text = hit.transform.GetComponent<GridObjInfo>().numberValue.ToString();
                clickAmount++;
            }
            else if(clickAmount >= 1 && clickAmount < gameManagerScript.solutionNumbers)
            {
                Vector2 dirUp = hit.transform.position + transform.up;
                Vector2 startPosUp = new Vector2(hit.transform.position.x, hit.transform.position.y + .6f);

                Vector2 dirRight = hit.transform.position + transform.right;
                Vector2 startPosRight = new Vector2(hit.transform.position.x + .6f, hit.transform.position.y);

                Vector2 dirDown = hit.transform.position - transform.up;
                Vector2 startPosDown = new Vector2(hit.transform.position.x, hit.transform.position.y - .6f);

                Vector2 dirLeft = hit.transform.position - transform.right;
                Vector2 startPosLeft = new Vector2(hit.transform.position.x - .6f, hit.transform.position.y);

                RaycastHit2D hitUp = Physics2D.Raycast(startPosUp, dirUp);
                RaycastHit2D hitRight= Physics2D.Raycast(startPosRight, dirRight);
                RaycastHit2D hitDown = Physics2D.Raycast(startPosDown, dirDown);
                RaycastHit2D hitLeft = Physics2D.Raycast(startPosLeft, dirLeft);

                if (selectedObj[0] != null && hitUp && hitUp.transform.gameObject == selectedObj[0])
                {
                    Instantiate(markerObject, hit.transform.position, Quaternion.identity);
                    selectedObj.Add(hit.transform.gameObject);
                }
                else if(selectedObj[0] != null && hitRight && hitRight.transform.gameObject == selectedObj[0] && selectedObj[0] != null)
                {
                    Instantiate(markerObject, hit.transform.position, Quaternion.identity);
                    selectedObj.Add(hit.transform.gameObject);
                }
                else if (selectedObj[0] != null && hitDown && hitDown.transform.gameObject == selectedObj[0] && selectedObj[0] != null)
                {
                    Instantiate(markerObject, hit.transform.position, Quaternion.identity);
                    selectedObj.Add(hit.transform.gameObject);
                }
                else if (selectedObj[0] != null && hitLeft && hitLeft.transform.gameObject == selectedObj[0] && selectedObj[0] != null)
                {
                    Instantiate(markerObject, hit.transform.position, Quaternion.identity);
                    selectedObj.Add(hit.transform.gameObject);
                }
                else
                {
                    return;
                }
                gameManagerScript.value2.GetComponent<TMP_Text>().text = hit.transform.GetComponent<GridObjInfo>().numberValue.ToString();
                clickAmount++;
            }
        }
    }
}
