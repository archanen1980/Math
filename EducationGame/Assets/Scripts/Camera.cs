using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Vector3 myPosX, myPosY, myPosZ;

    public GameManager gameManager;

    private void Start()
    {
        myPosX.x = gameManager.gridX / 2;
        myPosY.y = gameManager.gridY / 2;
        myPosZ.z = -1;

        transform.position = new Vector3(myPosX.x, myPosY.y, myPosZ.z); ;
    }
}
