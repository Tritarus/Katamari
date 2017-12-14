using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Public Members
    
    public GameObject m_zoneToSpawn;
    public GameObject m_zorb;

    #endregion

    #region Public Methods
    #endregion

    #region System
    void Awake() { }
    void Start() { }
    void OnEnable() { }

    void FixedUpdate() { }
    void Update() { }
    void LateUpdate() { }

    void OnGUI() { }
    #endregion

    #region Class Methods
    private Vector3 GetGameObjectRealSize(GameObject gameObject)
    {
        Vector3 sizeInScene = gameObject.GetComponent<MeshFilter>().sharedMesh.bounds.size;
        Vector3 scaleInScene = gameObject.transform.localScale;
        return new Vector3(sizeInScene.x * scaleInScene.x, sizeInScene.y * scaleInScene.y, sizeInScene.z * scaleInScene.z);
    }
    public void Spawn()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.layer = 9;
        sphere.AddComponent<Rigidbody>();
        sphere.transform.localScale = GetScale(m_zorb);
        //sphere.transform.position = GetPosition(m_zoneToSpawn, sphere);
        sphere.transform.position = new Vector3(Random.Range(-20f,20f), sphere.GetComponent<SphereCollider>().radius, Random.Range(-20f, 20f));
    }

    Vector3 GetScale(GameObject m_zorb)
    {
        float val = m_zorb.GetComponent<SphereCollider>().radius *1.2f ;
        return new Vector3(val, val, val);
    }

    Vector3 GetPosition(GameObject plane, GameObject primitive)
    {
        Vector3 res = Vector3.zero;
        Vector3 planeSize = GetGameObjectRealSize(plane);
        planeSize.x -= 1;
        planeSize.z -= 1;
        return res;
    }
    #endregion

    #region Tools Debug And Utilities
    #endregion

    #region Private an Protected Members
    #endregion

}