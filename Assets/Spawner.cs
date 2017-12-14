using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Public Members
    
    public GameObject m_zoneToSpawn;
    public GameObject m_zorb;
    public Camera m_camera;

    #endregion

    #region Public Methods
    #endregion

    #region System
    void Awake() { }
    void Start() { }
    void OnEnable()
    {
        for (int i = 0; i < 500; i++)
        {
            Spawn(.5f, init:true);
            Spawn(.8f, init: true);
            Spawn(1f, init: true);
        }
    }

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
    public void Spawn(float radiusModifier = 1.2f, bool init = false)
    {
        //   SpawnV1(radiusModifier, init);
        SpawnV2(radiusModifier, init);
    }

    public void SpawnV1(float radiusModifier = 1.2f, bool init = false)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.layer = 9;
        sphere.AddComponent<Rigidbody>();
        sphere.GetComponent<Rigidbody>().mass = 0;
        sphere.transform.localScale = GetScale(m_zorb, radiusModifier);
        //sphere.transform.position = GetPosition(m_zoneToSpawn, sphere);

        sphere.transform.position = new Vector3(Random.Range(-45f, 45f), sphere.GetComponent<SphereCollider>().radius, Random.Range(-45f, 45f));

        if (init)
        {
            sphere.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
    public void SpawnV2(float radiusModifier = 1.2f, bool init = false)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.layer = 9;
        sphere.AddComponent<Rigidbody>();
        sphere.GetComponent<Rigidbody>().mass = 0;
        sphere.transform.localScale = GetScale(m_zorb, radiusModifier);
        //sphere.transform.position = GetPosition(m_zoneToSpawn, sphere);
        
        //Vector3 worldVect = new Vector3(Random.Range(-45f, 45f), -10f, Random.Range(-45f, 45f));
        Vector3 worldVect = Vector3.zero;
        Vector3 camVect = Vector3.zero;
        bool outOfCamera = false;

        while (!outOfCamera)
        {
            worldVect = new Vector3(Random.Range(-45f, 45f), sphere.GetComponent<SphereCollider>().radius, Random.Range(-45f, 45f));
            camVect = m_camera.WorldToViewportPoint(worldVect);
            if (camVect.x < -1 || camVect.x > 1 || camVect.y < -1 || camVect.y > 1 || init)
            {
                //worldVect.y = sphere.GetComponent<SphereCollider>().radius;
                outOfCamera = true;
                sphere.transform.position = worldVect;
            }
        }
        if (!init)
        {
            sphere.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    Vector3 GetScale(GameObject m_zorb, float radiusModifier)
    {
        float val = m_zorb.GetComponent<SphereCollider>().radius * radiusModifier;
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