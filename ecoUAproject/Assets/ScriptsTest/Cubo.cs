using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo : MonoBehaviour
{	
    public AudioClip errorSound;
    public AudioClip correctSound;
    private AudioSource source;

    void Awake () {
        source = GetComponent<AudioSource>();
    }

    ///COLISIONES///
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject indicador = GameObject.Find("IndicadorAcierto");

        if(collision.transform.tag == transform.tag)
        {
            source.PlayOneShot(correctSound, 0.3f);

            indicador.GetComponent<AciertoFade>().Fadeop(transform.position.x, transform.position.y, true);
            
            Destroy(collision.gameObject);

            GameController.instance.score++;
        }
        else
        {
            source.PlayOneShot(errorSound, 0.4f);

            indicador.GetComponent<AciertoFade>().Fadeop(transform.position.x, transform.position.y, false);

            Destroy(collision.gameObject);

            GameController.instance.score--;
            if (GameController.instance.score < 0)
            {
                GameController.instance.score = 0;
            }       
        }
    }
}
