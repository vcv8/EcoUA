using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo : MonoBehaviour
{	
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Soy Cubo de tipo " + tag);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D)){
            transform.Translate(0.6f, 0, 0);
        } else if(Input.GetKeyDown(KeyCode.A)){
            transform.Translate(-0.6f, 0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == tag){
            GameController.instance.TriggeredCollision(other.gameObject, true);
        }else
        {
            GameController.instance.TriggeredCollision(other.gameObject, false);
        }
    }
}
