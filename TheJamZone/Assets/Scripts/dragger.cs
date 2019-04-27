using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragger : MonoBehaviour
{
    private Vector3 mOffset;

    private float mZCoord;

    private Rigidbody m_RigidBody;

    private void OnMouseUp()
    {
        Rigidbody[] parentArray = GetComponentsInParent<Rigidbody>();
        Rigidbody[] childArray = GetComponentsInChildren<Rigidbody>();
        List<Rigidbody> totalList = new List<Rigidbody>();
        totalList.AddRange(parentArray);
        totalList.AddRange(childArray);
        Rigidbody[] totalArray = totalList.ToArray();
        foreach (Rigidbody r in totalArray)
        {
            r.constraints = RigidbodyConstraints.FreezeAll;
        }

        foreach (Rigidbody r in totalArray)
        {
            r.constraints = RigidbodyConstraints.None;
        }


    }

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(
            gameObject.transform.position).z;

        //Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        //z coordinate of game object onscreen
        mousePoint.z = mZCoord;

        //COnvert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }
}
