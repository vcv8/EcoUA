using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FondoSelector : MonoBehaviour
{
    public Sprite[] fondos;
    private int numfondos;

    // Start is called before the first frame update
    void Start()
    {
        numfondos = fondos.Length;

        int lev = GameData.loadedLevel;
        if(lev > numfondos){
            while(lev > numfondos){
                lev -= numfondos;
            }
        }
        GetComponent<SpriteRenderer>().sprite = fondos[lev-1];
    }
}
