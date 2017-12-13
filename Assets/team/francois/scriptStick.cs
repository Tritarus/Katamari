using UnityEngine;
using UnityEngine.UI;

public class scriptStick : MonoBehaviour
{
    #region Public Members
    #endregion

    #region Public Methods
    #endregion

    #region System
    void Awake()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        m_collider = gameObject.GetComponent<SphereCollider>();
    }
    void Start() { }
    void OnEnable() { }

    void FixedUpdate() { }
    void Update() { }
    void LateUpdate() { }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.layer == 9) //Collectible
        {
            c.transform.parent = m_Transform;

            Collider collider = c.gameObject.GetComponent<Collider>();
            if (collider)
            {
                collider.enabled = false;
            }
            else
            {
                Debug.Log("OnCollisionEnter:collider=false");
            }
            Rigidbody rigidbody = c.gameObject.GetComponent<Rigidbody>();
            if (rigidbody)
            {
                rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                rigidbody.useGravity = false;
                rigidbody.isKinematic = true;
            }
            else
            {
                Debug.Log("OnCollisionEnter:rigidbody=false");
            }
            c.gameObject.layer = 0;
        }
    }
    #endregion

    #region Class Methods
    #endregion

    #region Tools Debug And Utilities
    private void OnGUI()
    {
        GUILayout.Button("m_collider.radius " + m_collider.radius);
    }
    #endregion

    #region Private an Protected Members
    private Transform m_Transform;
    private SphereCollider m_collider;
    #endregion

}