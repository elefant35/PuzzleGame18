using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPosController : MonoBehaviour
{
    // Start is called before the first frame update
    public int positionX;
    public int positionY;
    public GameObject currentSquare;
    void Awake()
    {
        GridController gridController = GameObject.FindGameObjectWithTag("Grid").GetComponent<GridController>();
        gridController.SetPositionOnGrid(positionX, positionY, gameObject); //set the position of the gridPos object on the grid
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        PlayerController playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerController.setSelectedPos(gameObject);
    }

    public void setCurrentSquare(GameObject newSquare)
    {
        currentSquare = newSquare;
    }
}
