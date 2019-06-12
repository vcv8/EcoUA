using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AciertoFade : MonoBehaviour
{
    public Sprite[] sprites;

    public void Start(){
        Color actual = GetComponent<SpriteRenderer>().color;
        actual.a = 0f;
        GetComponent<SpriteRenderer>().color = actual;

    }

    // Start is called before the first frame update
    public void Fadeop(float x, float y, bool tipo){
        Vector3 position = new Vector3(x, y+0.8f, 0f);

        if(tipo){
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        }else{
            GetComponent<SpriteRenderer>().sprite = sprites[1];
        }

        Color actual = GetComponent<SpriteRenderer>().color;
        actual.a = 1f;
        GetComponent<SpriteRenderer>().color = actual;

        transform.position = position;

        StartCoroutine(FadeIterator());
    }

    private IEnumerator FadeIterator(){
        for (float f = 1; f >= 0; f -= 0.1f) 
        {
            Color actual = GetComponent<SpriteRenderer>().color;
            actual.a -= 0.1f;

            GetComponent<SpriteRenderer>().color = actual;

            yield return new WaitForSeconds(0.1f);
        }
    }

}
