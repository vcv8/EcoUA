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
            Destroy(collision.gameObject);

            GameController.instance.score++;

            indicador.GetComponent<AciertoFade>().Fadeop(true);
        }
        else
        {
            Destroy(collision.gameObject);

            GameController.instance.score--;
            if (GameController.instance.score < 0)
            {
                GameController.instance.score = 0;
            }
            Handheld.Vibrate();

            indicador.GetComponent<AciertoFade>().Fadeop(false);
        }
    }
}
