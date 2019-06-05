using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasuraGen : MonoBehaviour
{
     public Transform[] item;
     public float  intervalo;
     public float  totalTiempo;
    
    void Start(){
      StartCoroutine(Generador());
    }

    void Update(){
        
    }

    IEnumerator Generador()
    {
        //int InstanceCount = 1;

        for (float f = totalTiempo; f >= 0; f -= intervalo) 
        {
            //Debug.Log ("Instancia " + InstanceCount);
            int randomItem = Random.Range(0,item.Length);
            Vector3 spawnPosition = new Vector3 (Random.Range(-5f, 5f), 8, 0);
            //Vector3 spawnPosition = transform.parent.position + new Vector3 (0, .2f, 0);
            Quaternion spawnRotation = Quaternion.identity;
            //Instantiate (item[randomItem], spawnPosition, spawnRotation);
            Instantiate (item[randomItem], spawnPosition, spawnRotation);
            //InstanceCount++;

            yield return new WaitForSeconds(intervalo);
        }
    } 
}
