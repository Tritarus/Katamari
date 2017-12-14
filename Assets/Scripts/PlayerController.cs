using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Public Members
    public Transform m_zorbTransform;
    #endregion
    
    #region System
    void Awake()
    {
        m_transform = GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        m_transform.Rotate(new Vector3(0f, moveHorizontal, 0f));
        Debug.DrawLine(m_transform.position, m_transform.forward * 100, Color.red);

        m_transform.position = m_zorbTransform.position;
    }
    #endregion

    #region Private an Protected Members
    private Transform m_transform;
    #endregion
}