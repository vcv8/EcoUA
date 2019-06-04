using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo : MonoBehaviour
{	
	public Tipo tipo;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Soy Cubo de tipo " + tipo.colortipo);
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
        if(other.gameObject.tag == "ElementoBasura"){
            Debug.Log ("Son MISMO TIPO");
        }
    }
}
