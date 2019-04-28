using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sticker : MonoBehaviour
{
    bool hasJoint;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>() != null && !hasJoint)
        {
            gameObject.AddComponent<FixedJoint>();
            gameObject.GetComponent<FixedJoint>().connectedBody = collision.rigidbody;
            hasJoint = true;
        }
    }
}
