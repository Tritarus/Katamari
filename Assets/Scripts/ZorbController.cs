using UnityEngine;

public class ZorbController : MonoBehaviour
{
    #region Public Members
    public Transform m_hamsterTransform;
    [Range(1.0f,30.0f)]
    public float m_thrust = 5f;
    #endregion

    #region System
    void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 forward = m_hamsterTransform.forward;
        m_rigidbody.velocity = forward * m_thrust * moveVertical;
    }
    #endregion

    #region Private an Protected Members
    private Rigidbody m_rigidbody;
    #endregion

}