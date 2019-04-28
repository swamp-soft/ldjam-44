using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragger : MonoBehaviour
{
    private Vector3 mOffset;

    private float mZCoord;

    private Rigidbody m_RigidBody;

    private Vector3 mOffset_sub;

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

        FixedJoint[] ptArray = GetComponentsInParent<FixedJoint>();
        FixedJoint[] ctArray = GetComponentsInChildren<FixedJoint>();
        List<FixedJoint> ttList = new List<FixedJoint>();
        ttList.AddRange(ptArray);
        ttList.AddRange(ctArray);
        FixedJoint[] ttArray = ttList.ToArray();
        foreach (FixedJoint f in ttArray)
        {
            Destroy(f);
        }
        FixedJoint fj = GetComponent<FixedJoint>();
        Destroy(fj);
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

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
        Transform[] parentArray = GetComponentsInParent<Transform>();
        Transform[] childArray = GetComponentsInChildren<Transform>();
        List<Transform> totalList = new List<Transform>();
        totalList.AddRange(parentArray);
        totalList.AddRange(childArray);
        Transform[] totalArray = totalList.ToArray();
        foreach (Transform t in totalArray)
        {
            mOffset_sub = t.position - GetMouseAsWorldPoint();
            t.position = GetMouseAsWorldPoint() + mOffset_sub;
        }
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }
}
