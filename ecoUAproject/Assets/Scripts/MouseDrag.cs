using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour {

    public GameObject railGO;
    //public GameObject railGOy;
    private float distance = 10;
    
    public void Start(){
        Vector3 startPos = new Vector3(0, railGO.transform.position.y, transform.position.z);
        transform.position = startPos;
    }
    private void OnMouseDrag()
    {
        float ycorrected = railGO.transform.position.y;
        //float xcorrected = railGOy.transform.position.x;

        Vector3 mousePos = new Vector3(Input.mousePosition.x, 0, distance);
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
        //Vector2 tam = railGO.GetComponent<SpriteRenderer>().sprite.bounds.size;
        Vector3 tam = railGO.transform.localScale;
        //Vector3 tamY = railGOy.transform.localScale;

       // if(transform.position.y == ycorrected){
            if(objectPos.x < -(tam.x/2)){
                objectPos.x = (float) -(tam.x/2);
            }else if(objectPos.x > (tam.x/2)){
                objectPos.x = (float) (tam.x/2);
            }
            objectPos.y = transform.position.y;
            
            transform.position = objectPos;
       // }

        /*if(transform.position.x == xcorrected){
            if(objectPos.y > ycorrected){
                objectPos.y = ycorrected;
            }else if(objectPos.y < (ycorrected - tamY.y)){
                objectPos.y = (ycorrected - tamY.y);
            }
            objectPos.x = transform.position.x;
            
            transform.position = objectPos;
        }*/
    }
}