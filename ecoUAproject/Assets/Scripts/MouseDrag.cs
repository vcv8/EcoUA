using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour {

    public GameObject railGO;
    private float distance = 10;
    
    public void Start(){
        Vector3 startPos = new Vector3(0, railGO.transform.position.y, transform.position.z);
        transform.position = startPos;
    }
    private void OnMouseDrag()
    {
        float ycorrected = railGO.transform.position.y;

        Vector3 mousePos = new Vector3(Input.mousePosition.x, 0, distance);
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);

        if(objectPos[0] < -2.5f){
            objectPos[0] = -2.5f;
        }else if(objectPos[0] > 2.5f){
            objectPos[0] = 2.5f;
        }
        objectPos[1] = ycorrected;
        
        transform.position = objectPos;
    }
}