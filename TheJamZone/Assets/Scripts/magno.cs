using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class magno : MonoBehaviour
{
    public static readonly string[] Poles = {
        "n:leg",
        "s:leg",
        "n:arm",
        "s:arm",
        "n:head",
        "s:head",
        "n:gi",
        "s:gi",
        "n:bile",
        "s:bile",
        "n:heart",
        "s:heart",
        "n:lungs",
        "s:lungs"
    };

    public float MagnetForce;
    public string MagneticPole;
    public Rigidbody RigidBody;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDrawGizmos()
    {

    }


}

