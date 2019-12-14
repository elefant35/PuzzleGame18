using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Image redX;
    [SerializeField] private Image greenCheck;
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject spawnControllerObj;

    // Start is called before the first frame update
    void Start()
    {
        redX.enabled = false;
        greenCheck.enabled = false;
        button2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /*public CheckState() // old check state this can be removed
    {
        GridController gridController = GameObject.FindGameObjectWithTag("Grid").GetComponent<GridController>();
        GameObject[] arrayIncorrect = gridController.returnIncorrectPositions();

        if(arrayIncorrect.Length == 0)
        {
            
            greenCheck.enabled = true;
        }
        else{
            redX.enabled = true;
        }
        
        
    }*/
    public bool solutionIsCorrect()
    {
        GridController gridController = GameObject.FindGameObjectWithTag("Grid").GetComponent<GridController>();
        GameObject[] arrayIncorrect = gridController.returnIncorrectPositions();

        if (arrayIncorrect.Length == 0)
        {
            return true;
        }
        else
        {
            return false;
        }


    }

    public void button2Press() // check if correct solution, add a square, and change button
    {
        SpawnController spawnController = spawnControllerObj.GetComponent<SpawnController>();
        if (solutionIsCorrect())
        {
            //add a square
            spawnController.SpawnRandomObject();
            //change old button to disabled
            button2.SetActive(false);
            //change the button enabled
            button1.SetActive(true);

            //call function to temporarily display check mark
        }
        else
        {
            //game over
            redX.enabled = true;
        }
    }
    public void button1Press()
    {
        //shuffle objects
        GridController gridController = GameObject.FindGameObjectWithTag("Grid").GetComponent<GridController>();
        gridController.ShuffleObjects();
        //change old button to disabled
        button1.SetActive(false);
        //change new button to enabled
        button2.SetActive(true);
    }
}
