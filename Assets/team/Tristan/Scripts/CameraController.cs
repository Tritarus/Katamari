using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Public Members

    public GameObject m_player;
    
    #endregion

    #region Public void

    #endregion

    #region System

    void Start()
    {
        m_offset = transform.position - m_player.transform.position;
	}
	
	void Update()
    {
		
	}

    #endregion

    #region Tools Debug And Utility

    #endregion

    #region Private an Protected Members

    private vector3 m_offset;

    #endregion
}