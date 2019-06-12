using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo : MonoBehaviour
{	

    void Update()
    {
        
    }

    ///COLISIONES///
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject indicador = GameObject.Find("IndicadorAcierto");

        if(collision.transform.tag == transform.tag)
        {
            indicador.GetComponent<AciertoFade>().Fadeop(transform.position.x, transform.position.y, true);
            
            Destroy(collision.gameObject);

            GameController.instance.score++;
        }
        else
        {
            indicador.GetComponent<AciertoFade>().Fadeop(transform.position.x, transform.position.y, false);

            Destroy(collision.gameObject);

            GameController.instance.score--;
            if (GameController.instance.score < 0)
            {
                GameController.instance.score = 0;
            }
            Handheld.Vibrate();            
        }
    }
}
