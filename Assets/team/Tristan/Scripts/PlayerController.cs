using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Public Members
    [Range(1.0f, 50.0f)]
    public float m_thrust;
    [Range(1.0f, 50.0f)]
    public float m_maxSpeed;

    #endregion

    #region Public void

    #endregion

    #region System

    void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        m_rigidbody.AddForce(movement * m_thrust);
        if (m_rigidbody.velocity.magnitude > m_maxSpeed)
        {
            m_rigidbody.velocity = m_rigidbody.velocity.normalized * m_maxSpeed;
        }
    }

    #endregion

    #region Tools Debug And Utility

    #endregion

    #region Private an Protected Members

    private Rigidbody m_rigidbody;

    #endregion
}