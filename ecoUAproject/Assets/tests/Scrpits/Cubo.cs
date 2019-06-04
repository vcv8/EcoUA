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
        
    }
}
