using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnosetta : MonoBehaviour
{
    public float MagnetForce;
    magno[] m_magnets;

    // Use this for initialization
    void Start()
    {
        m_magnets = GetComponentsInChildren<magno>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < m_magnets.Length; i++)
        {
            m_magnets[i].MagnetForce = MagnetForce;
        }
    }
}