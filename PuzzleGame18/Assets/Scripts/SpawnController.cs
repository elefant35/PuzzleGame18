using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    //Declare Variables
    [SerializeField] private GameObject squareObject;

    // Start is called before the first frame update
    void Start()
    {
        SpawnRandomObject();
        SpawnRandomObject();
        SpawnRandomObject();
        SpawnRandomObject();
        SpawnRandomObject();
    }

    // Update is called once per frame
    void Update()
    {
        //spawnSquareAtLocation(squareObject, 3, 3);
    }

    private void spawnSquareAtLocation(GameObject squareToSpawn, int posX, int posY) //this isn't working yet it places the square in the wrong location but under the right object
    {
        GridController gridController = GameObject.FindGameObjectWithTag("Grid").GetComponent<GridController>();
        GameObject gridPos = gridController.getPosObject(posX, posY);
        //Vector3 gridPosVect = new Vector3(gridPos.transform.position.x, gridPos.transform.position.y, -1);
        GameObject newSquare = Instantiate(squareObject);
        newSquare.GetComponent<SquareController>().MoveTo(posX, posY);
        newSquare.GetComponent<SquareController>().lockInDesiredPosition();
    }

    public void SpawnRandomObject()
    {
        GridController gridController = GameObject.FindGameObjectWithTag("Grid").GetComponent<GridController>();
        GameObject randomPos = gridController.returnRandomObjectPos();
        GridPosController randGridPosController = randomPos.GetComponent<GridPosController>();
        int posX = randGridPosController.positionX;
        int posY = randGridPosController.positionY;
        spawnSquareAtLocation(squareObject, posX, posY);
    }

}
