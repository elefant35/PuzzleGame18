using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Image redX;
    [SerializeField] private Image greenCheck;

    // Start is called before the first frame update
    void Start()
    {
        redX.enabled = false;
        greenCheck.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CheckState()
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
        
        
    }
}
