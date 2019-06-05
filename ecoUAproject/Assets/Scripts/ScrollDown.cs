using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollDown : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!GameController.instance.finishLevel) //Si no se ha perdido o no se ha llegado al tiempo max del nivel
        {
            rb2d.velocity = new Vector2(0, -GameController.instance.speed_scrollDown);
        }
        else
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        }

        if (transform.position.y < -8.0f) //Eliminamos el objeto si esta fuera de la pantalla 
        {
            Destroy(gameObject);
        }
    }
}
