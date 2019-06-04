using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElemBasura : MonoBehaviour
{
    public Tipo tipo;
    public float caidaPS;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Soy Basura de tipo " + tipo.colortipo);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, caidaPS * Time.deltaTime, 0); 
    }

    void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log ("Tipo: "+ other.gameObject.GetComponent<Tipo>());
        if(other.gameObject.GetComponent<Tipo>() == tipo){
            Debug.Log ("Son MISMO TIPO");
        }
    }
}
