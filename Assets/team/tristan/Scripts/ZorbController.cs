using UnityEngine;
using UnityEngine.UI;

public class ZorbController : MonoBehaviour
{
    #region Public Members

    public Transform m_hamsterTransform;
    [Range(0.0f,30.0f)]
    public float m_thrust = 5f;

    #endregion

    #region Public Methods
    #endregion

    #region System
    void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        

    }
    void OnEnable() { }

    void FixedUpdate()
    {
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 forward = m_hamsterTransform.forward;
        //Debug.Log(moveVertical);
        //Debug.Log(m_rigidbody.velocity);

        
        m_rigidbody.velocity = forward * m_thrust * moveVertical;

        /*
        Vector3 currentDirection = Vector3.up;
        Vector3 monAngleEnEuler = new Vector3(0, 90, 0);
        Quaternion monAngle = Quaternion.Euler(monAngleEnEuler);
        Vector3 newDirection = monAngle * currentDirection;
        //*/
    }
    void Update() { }
    void LateUpdate() { }

    void OnGUI()
    {

    }
    #endregion

    #region Class Methods
    #endregion

    #region Tools Debug And Utilities
    #endregion

    #region Private an Protected Members

    private Rigidbody m_rigidbody;

    #endregion

}