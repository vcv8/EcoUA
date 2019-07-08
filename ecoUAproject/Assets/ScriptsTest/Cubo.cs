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
            indicador.GetComponent<AciertoFade>().Fadeop(transform.position.x, transform.position.y, true);

            source.PlayOneShot(correctSound, 0.3f);
            
            Destroy(collision.gameObject);

            GameController.instance.score++;
        }
        else
        {
            indicador.GetComponent<AciertoFade>().Fadeop(transform.position.x, transform.position.y, false);

            source.PlayOneShot(errorSound, 0.3f);

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
