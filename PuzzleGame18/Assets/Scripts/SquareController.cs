using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareController : MonoBehaviour
{
    public int currentPosX = -1;
    public int currentPosY = -1;

    public int desiredPositionX;
    public int desiredPositionY;
    // Start is called before the first frame update
    void Awake()
    {
        //Debug.Log("CurrentPosX at awake:" + currentPosX);
        currentPosY = -1;
        currentPosX = -1;
    }

    // Update is called once per frame
    void Update()
    {
        //MoveTo(currentPosX, currentPosY);
    }

    public void MoveTo(int posX, int posY)
    {
        //Debug.Log("currentPosX at time of move:" + currentPosX + " CurrentPosY at time of move:" + currentPosY);
        if (currentPosX != -1 || currentPosY != -1)
        {
            //Debug.Log("section added to deal with old position called");
            GridController OldGridController = GameObject.FindGameObjectWithTag("Grid").GetComponent<GridController>();
            GameObject OldGridPos = OldGridController.getPosObject(currentPosX, currentPosY);
            GridPosController OldGridPosController = OldGridPos.GetComponent<GridPosController>();
            OldGridPosController.setCurrentSquare(null);
        }


        currentPosX = posX;
        currentPosY = posY;
        GridController gridController = GameObject.FindGameObjectWithTag("Grid").GetComponent<GridController>();
        GameObject gridPos = gridController.getPosObject(posX, posY);
        gameObject.transform.position = gridPos.transform.position; // move the object to the specified position on the grid
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        GridPosController gridPosController = gridPos.GetComponent<GridPosController>();
        gridPosController.setCurrentSquare(gameObject);
    }

    private void OnMouseDown()
    {
        PlayerController playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerController.setSelectedObject(gameObject);
    }

    public void lockInDesiredPosition()
    {
        desiredPositionX = currentPosX;
        desiredPositionY = currentPosY;
    }
    public bool IsPositionCorrect()
    {
        if (currentPosX == desiredPositionX && currentPosY == desiredPositionY)
        {
            return true;
        }
        else return false;
    }
}
