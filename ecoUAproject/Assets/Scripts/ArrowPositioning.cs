using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPositioning : MonoBehaviour
{
    public Transform railCentral;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, railCentral.position.y, transform.position.z);
    }
}
