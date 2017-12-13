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

                Vector3 sizeInScene = c.gameObject.GetComponent<MeshFilter>().sharedMesh.bounds.size;
                Vector3 scaleInScene = c.gameObject.transform.localScale;
                Vector3 size = new Vector3(sizeInScene.x * scaleInScene.x, sizeInScene.y * scaleInScene.y, sizeInScene.z * scaleInScene.z);
                Debug.Log(size);
                
                float add = Mathf.Abs(Mathf.Min(size.x, size.y, size.z) * 0.001f);
                Debug.Log(add);
                m_collider.radius += add;
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