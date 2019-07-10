using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPositioning : MonoBehaviour
{
    public Transform railCentral;

    // Start is called before the first frame update
    void Start()
    {
        Transform izq = transform.GetChild(0);
        izq.position = new Vector3(izq.position.x, railCentral.position.y, izq.position.z);
        Transform dch = transform.GetChild(1);
        dch.position = new Vector3(dch.position.x, railCentral.position.y, dch.position.z);
    }
}
