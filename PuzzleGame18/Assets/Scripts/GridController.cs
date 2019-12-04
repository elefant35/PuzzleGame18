using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    GameObject[][] gridArray = new GameObject[5][];

    public GameObject testObject;

    // Start is called before the first frame update
    GridController()
    {
        gridArray[0] = new GameObject[5];
        gridArray[1] = new GameObject[5];
        gridArray[2] = new GameObject[5];
        gridArray[3] = new GameObject[5];
        gridArray[4] = new GameObject[5];
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        testObject = gridArray[3][3];
    }

    public void SetPositionOnGrid(int posX, int posY, GameObject gridPos)
    {
        gridArray[posX][posY] = gridPos;
    }

    public GameObject getPosObject(int posX, int posY)
    {
        return gridArray[posX][posY];
    }
}
