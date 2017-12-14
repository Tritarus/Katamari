using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Public Members

    public Transform m_hamsterTransform;
    public Transform m_zorbTranform;

    #endregion

    #region Public void

    #endregion

    #region System

    void Start()
    {
        //m_offset = transform.position - m_hamsterTransform.position;
	}
	
	void Update()
    {
        //transform.position = m_hamsterTransform.position + m_offset;
        //    Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
        //transform.position = -m_hamsterTransform.forward * m_offset;
    }

    #endregion

    #region Tools Debug And Utility

    #endregion

    #region Private an Protected Members

    private Vector3 m_offset;

    #endregion
}