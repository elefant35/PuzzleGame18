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
        returnRandomObjectPos();
    }

    // Update is called once per frame
    void Update()
    {
        testObject = gridArray[3][3];
        returnIncorrectPositions();
    }

    public void SetPositionOnGrid(int posX, int posY, GameObject gridPos)
    {
        gridArray[posX][posY] = gridPos;
    }

    public GameObject getPosObject(int posX, int posY)
    {
        return gridArray[posX][posY];
    }

    public GameObject returnRandomObjectPos()
    {
        int randomArrayLength = 0;
        for(int x = 0; x<5; x++)
        {
            for (int y = 0; y<5; y++)
            {
                GameObject objectpos = gridArray[x][y];
                GridPosController gridPosController = objectpos.GetComponent<GridPosController>();
                //Debug.Log("Position:" + gridPosController.positionX + "," + gridPosController.positionY);
                if(gridPosController.currentSquare == null)
                {
                    randomArrayLength++;
                }
            }
        }
        GameObject[] randomArray = new GameObject[randomArrayLength];
        int i = 0;
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                GameObject objectpos = gridArray[x][y];
                GridPosController gridPosController = objectpos.GetComponent<GridPosController>();
                //Debug.Log("Position:" + gridPosController.positionX + "," + gridPosController.positionY);
                if (gridPosController.currentSquare == null)
                {
                    randomArray[i] = objectpos;
                    i++;
                }
            }
        }
        int randomArrayPos = Random.Range(0, randomArrayLength-1);
        GameObject randomObject = randomArray[randomArrayPos];
        GridPosController randomGridPosController = randomObject.GetComponent<GridPosController>();
        //Debug.Log("Random Object Pos" + randomGridPosController.positionX + "," + randomGridPosController.positionY);
        return randomObject;
    }

    public GameObject[] returnIncorrectPositions()
    {
        int numIncorrect = 0;
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                GameObject objectpos = gridArray[x][y];
                GridPosController gridPosController = objectpos.GetComponent<GridPosController>();
                Debug.Log("Position:" + gridPosController.positionX + "," + gridPosController.positionY);
                if (gridPosController.currentSquare != null)
                {
                    SquareController squareController = gridPosController.currentSquare.GetComponent<SquareController>();
                    if (!squareController.IsPositionCorrect())
                    {
                        numIncorrect++;
                    }
                }
            }
        }
        GameObject[] incorrectArray = new GameObject[numIncorrect];
        int i = 0;
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                GameObject objectpos = gridArray[x][y];
                GridPosController gridPosController = objectpos.GetComponent<GridPosController>();
                Debug.Log("Position:" + gridPosController.positionX + "," + gridPosController.positionY);
                if (gridPosController.currentSquare != null)
                {
                    SquareController squareController = gridPosController.currentSquare.GetComponent<SquareController>();
                    if (!squareController.IsPositionCorrect())
                    {
                        incorrectArray[i] = objectpos;
                        i++;
                    }
                }
            }
        }
        Debug.Log("Number incorrect:" + numIncorrect);
        return incorrectArray;
    }
    public void ShuffleObjects()
    {
        int numberOfSquares = 0;
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                GameObject objectpos = gridArray[x][y];
                GridPosController gridPosController = objectpos.GetComponent<GridPosController>();
                Debug.Log("Position:" + gridPosController.positionX + "," + gridPosController.positionY);
                if (gridPosController.currentSquare != null)
                {
                    numberOfSquares++;
                }
            }
        }
        GameObject[] ArrayOfSquares = new GameObject[numberOfSquares];
        int i = 0;
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                GameObject objectpos = gridArray[x][y];
                GridPosController gridPosController = objectpos.GetComponent<GridPosController>();
                Debug.Log("Position:" + gridPosController.positionX + "," + gridPosController.positionY);
                if (gridPosController.currentSquare != null)
                {

                    ArrayOfSquares[i] = gridPosController.currentSquare;
                    i++;
                }
            }
        }

        for (int n = 0; n < i; n++)
        {
            GameObject objectPos = returnRandomObjectPos();
            GridPosController gridPosController = objectPos.GetComponent<GridPosController>();
            SquareController squareController =  ArrayOfSquares[n].GetComponent<SquareController>();
            squareController.MoveTo(gridPosController.positionX, gridPosController.positionY);
        }

    }
}
