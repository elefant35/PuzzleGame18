using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject selectedObject;
    [SerializeField] private GameObject selectedPos;
    [SerializeField] private GameObject oldSelectedPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(oldSelectedPos != selectedPos)
        {
            oldSelectedPos = selectedPos;
            selectedObject.GetComponent<SquareController>().MoveTo(selectedPos.GetComponent<GridPosController>().positionX, selectedPos.GetComponent<GridPosController>().positionY);
        }
    }

    public void setSelectedObject(GameObject currentObj)
    {
        selectedObject = currentObj;
    }
    public void setSelectedPos(GameObject currentObj)
    {
        selectedPos = currentObj;
    }
}
