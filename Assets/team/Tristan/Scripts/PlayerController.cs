using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Public Members
    [Range(1.0f, 100.0f)]
    public float m_speed;
    public Rigidbody m_rigidbody;

    #endregion

    #region Public void

    #endregion

    #region System

    void Start()
    {
		
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        m_rigidbody.AddForce(movement * m_speed);
    }

    #endregion

    #region Tools Debug And Utility

    #endregion

    #region Private an Protected Members

    #endregion
}