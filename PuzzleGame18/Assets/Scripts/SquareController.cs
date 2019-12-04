﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareController : MonoBehaviour
{
    public int currentPosX;
    public int currentPosY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //MoveTo(currentPosX, currentPosY);
    }

    public void MoveTo(int posX, int posY)
    {
        currentPosX = posX;
        currentPosY = posY;
        GridController gridController = GameObject.FindGameObjectWithTag("Grid").GetComponent<GridController>();
        GameObject gridPos = gridController.getPosObject(posX, posY);
        gameObject.transform.position = gridPos.transform.position; // move the object to the specified position on the grid
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
    }

    private void OnMouseDown()
    {
        PlayerController playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerController.setSelectedObject(gameObject);
    }
}