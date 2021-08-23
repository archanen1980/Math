using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    Vector3 myPosX, myPosY, myPosZ;

    GridGenerator gridGenerator;

    private void Start()
    {
        gridGenerator = GameObject.FindObjectOfType<GridGenerator>();

        myPosX.x = gridGenerator.sizeX / 2;
        myPosY.y = gridGenerator.sizeY / 2;
        myPosZ.z = -1;

        transform.position = new Vector3(myPosX.x, myPosY.y, myPosZ.z); ;
    }
}
