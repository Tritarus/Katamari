using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Public Members    
    public GameObject m_zoneToSpawn;
    public GameObject m_zorb;
    public Camera m_camera;
    public int m_ballNumber;
    #endregion

    #region System

    private void Awake()
    {
        m_planeRenderer = GetComponentInChildren<Renderer>();
        m_minusX = -m_planeRenderer.bounds.size.x / 2 + 5;
        m_plusX = m_planeRenderer.bounds.size.x / 2 - 5;
        m_minusZ = -m_planeRenderer.bounds.size.z / 2 + 5;
        m_plusZ = m_planeRenderer.bounds.size.z / 2 - 5;
        Debug.Log("Spawn Zone : " + m_minusX + "," + m_minusZ + "-" + m_plusX + "," + m_plusZ);
    }

    void OnEnable()
    {
        for (int i = 0; i < m_ballNumber/3; i++)
        {
            Spawn(.5f, init:true);
            Spawn(.8f, init: true);
            Spawn(1f, init: true);
        }
    }


    //Debug.Log("T(): );

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

    private void SpawnV1(float radiusModifier = 1.2f, bool init = false)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.layer = 9;
        sphere.AddComponent<Rigidbody>();
        sphere.GetComponent<Rigidbody>().mass = 0;
        sphere.transform.localScale = GetScale(m_zorb, radiusModifier);

        sphere.transform.position = new Vector3(Random.Range(m_minusX, m_plusX), sphere.GetComponent<SphereCollider>().radius, Random.Range(m_minusZ, m_plusZ));

        if (init)
        {
            sphere.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
    private void SpawnV2(float radiusModifier = 1.2f, bool init = false)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        Vector3 worldVect = Vector3.zero;
        Vector3 camVect = Vector3.zero;
        bool outOfCamera = false;
        int maxTest = 3;
        for (int i = 0; i <= maxTest && !outOfCamera; i++)
        {
            worldVect = new Vector3(Random.Range(m_minusX, m_plusX), sphere.GetComponent<SphereCollider>().radius, Random.Range(m_minusZ, m_plusZ));
            camVect = m_camera.WorldToViewportPoint(worldVect);
            if (camVect.x < -1 || camVect.x > 1 || camVect.y < -1 || camVect.y > 1 || init)
            {
                sphere.layer = 9;
                sphere.AddComponent<Rigidbody>();
                sphere.GetComponent<Rigidbody>().mass = 0;
                sphere.transform.localScale = GetScale(m_zorb, radiusModifier);
                sphere.transform.position = worldVect;

                outOfCamera = true;
            }
            else if(i == maxTest)
            {
                Destroy(sphere);
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

    #region Private Members

    private Renderer m_planeRenderer;
    private float m_minusX;
    private float m_plusX;
    private float m_minusZ;
    private float m_plusZ;

    #endregion
}