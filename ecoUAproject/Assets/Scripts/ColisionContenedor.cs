using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionContenedor : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.tag);
    }
}
