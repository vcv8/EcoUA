using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    public LayerMask touchInputMask;
    private GameObject[] touchList = new GameObject[4];

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if(Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0)){
            RaycastHit2D hit2d = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, touchInputMask);
            if(hit2d.transform != null)
            {
                //Debug.Log(hit2d.transform.position.y);
                GameObject recipient = hit2d.transform.gameObject;

                if(Input.GetMouseButton(0))
                {
                    recipient.GetComponent<MouseDrag>().onTouchStay(Input.mousePosition);
                    //recipient.SendMessage("OnTouchStay",Input.mousePosition,SendMessageOptions.DontRequireReceiver);
                }
            }
        }
#endif
        foreach(Touch touch in Input.touches) {
            switch(touch.phase)
            {
                case TouchPhase.Began:
                    RaycastHit2D hit2d = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero, touchInputMask);

                    if(hit2d.transform != null)
                    {
                        GameObject recipient = hit2d.transform.gameObject;
                        touchList[touch.fingerId] = recipient;
                    }

                    break;

                case TouchPhase.Moved:
                    touchList[touch.fingerId].GetComponent<MouseDrag>().onTouchStay(touch.position);
                    //recipient.SendMessage("OnTouchStay",touch.position,SendMessageOptions.DontRequireReceiver);

                    break;

                case TouchPhase.Ended:
                    touchList[touch.fingerId] = null;

                    break;

                case TouchPhase.Canceled:
                    touchList[touch.fingerId] = null;

                    break;
            }
        }
    }
}
