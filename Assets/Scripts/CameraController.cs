using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Public Members

    //public Transform m_hamsterTransform;
    public GameObject m_zorb;

    #endregion

    #region Public void

    #endregion

    #region System

    void Start()
    {
        m_transform = transform;
        m_radius = m_zorb.GetComponent<SphereCollider>().radius;
        ratio_y = m_transform.position.y / m_radius;
        ratio_z = m_transform.position.z / m_radius;
    }
	
	void LateUpdate()
    {
        //m_radius = m_zorb.GetComponent<SphereCollider>().radius;

        //Vector3 tmp = m_transform.position;
        //tmp.y = m_radius * ratio_y;
        //tmp.z = m_radius * ratio_z;

        //m_transform.position = tmp;

        //transform.position = m_hamsterTransform.position + m_offset;
        //    Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
        //transform.position = -m_hamsterTransform.forward * m_offset;
    }

    #endregion

    #region Tools Debug And Utility

    #endregion

    #region Private an Protected Members
    private Transform m_transform;
    private float m_radius;
    private float ratio_y;
    private float ratio_z;

    #endregion
}