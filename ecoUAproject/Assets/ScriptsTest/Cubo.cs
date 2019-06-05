using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo : MonoBehaviour
{	
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D)){
            transform.Translate(0.6f, 0, 0);
        } else if(Input.GetKeyDown(KeyCode.A)){
            transform.Translate(-0.6f, 0, 0);
        }
    }

    ///COLISIONES///
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == transform.tag)
        {
            Destroy(collision.gameObject);

            GameController.instance.score++;
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
        }
    }
}
