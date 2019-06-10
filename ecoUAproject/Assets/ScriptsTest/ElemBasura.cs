using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElemBasura : MonoBehaviour
{
    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
        Vector2 tam = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        gameObject.GetComponent<BoxCollider2D>().size = tam;
        //gameObject.GetComponent<BoxCollider2D>().offset = new Vector2 ((tam.x / 2), 0);
    }
}
