using UnityEngine;
using UnityEngine.UI;

public class scriptStick1 : MonoBehaviour
{
    #region Public Members
    #endregion

    #region Public Methods
    public Spawner m_spawner;
    public float ColliderRelativeIncrease = 0.005f;
    public float m_catchableRatio = .5f;

    #endregion

    #region System
    void Awake()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        m_collider = gameObject.GetComponent<SphereCollider>();
        m_collider.radius *= 0.9f;
    }
    void Start() { }
    void OnEnable() { }

    void FixedUpdate() { }
    void Update() { }
    void LateUpdate() { }

    private Vector3 GetGameObjectRealSize(GameObject gameObject)
    {
        Vector3 sizeInScene = gameObject.GetComponent<MeshFilter>().sharedMesh.bounds.size;
        Vector3 scaleInScene = gameObject.transform.localScale;
        return new Vector3(sizeInScene.x * scaleInScene.x, sizeInScene.y * scaleInScene.y, sizeInScene.z * scaleInScene.z);
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.layer == 9) //Collectible
        {
            Vector3 CollectibleSize = GetGameObjectRealSize(c.gameObject);
            /*
            Debug.Log("CollectibleSize = " + CollectibleSize);
            Debug.Log("CollectibleSize.magnitude = " + CollectibleSize.magnitude);

            Debug.Log("m_collider.radius = " + m_collider.radius);
            Debug.Log("m_catchableRatio = " + m_catchableRatio);
            Debug.Log("m_collider.radius * m_catchableRatio = " + m_collider.radius * m_catchableRatio);
            Debug.Log("-------------------------");
            */
            if (CollectibleSize.magnitude < m_collider.radius * m_catchableRatio){
                c.transform.parent = m_Transform;

                Collider collider = c.gameObject.GetComponent<Collider>();
                if (collider)
                {
                    collider.enabled = false;

                    
                    //Debug.Log(size);

                    float add = Mathf.Abs(Mathf.Min(CollectibleSize.x, CollectibleSize.y, CollectibleSize.z) * ColliderRelativeIncrease);
                    //Debug.Log(add);
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
                m_spawner.Spawn();
            }
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