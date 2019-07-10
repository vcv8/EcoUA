using UnityEngine;

public class RailScalig : MonoBehaviour {
    
    
    private void Start() {
        Vector3 tam = transform.localScale;
        Vector3 dimensiones = Camera.main.ScreenToWorldPoint(new Vector3 (Screen.width, 0, 0));
        Debug.Log("Scrn width: " + dimensiones.x);
        Debug.Log("tam X: " + tam.x);

        //Adapta ancho de rail
        if(tam.x/2 > dimensiones.x){
            Debug.Log("REDUCE");
            tam.x = (dimensiones.x-0.2f)*2;
            transform.localScale = tam;
        }
        
    }
}