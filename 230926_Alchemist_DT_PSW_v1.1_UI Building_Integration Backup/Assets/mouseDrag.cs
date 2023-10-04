using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseDrag : MonoBehaviour
{
    private Vector3 mOffset;
    //private int cloneNum = 0;
    private float mZCoord;
    public GameObject EETarget;

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
        

    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        gameObject.transform.position = GetMouseWorldPos() + mOffset;
        EETarget.transform.position = gameObject.transform.position;
    }

    private void Update()
    {
        EETarget.transform.position = gameObject.transform.position;
    }
}
