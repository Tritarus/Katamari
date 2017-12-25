using UnityEngine;
using UnityEngine.UI;
using System;

public class StickController : MonoBehaviour
{
    #region Public Members
    public Spawner m_spawner;
    public float ColliderRelativeIncrease = 0.04f;
    public float m_catchableRatio = .5f;
    #endregion

    #region System
    void Awake()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        m_collider = gameObject.GetComponent<SphereCollider>();
        m_collider.radius *= 0.9f;
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.layer == 9) //Collectible
        {
            Vector3 CollectibleSize = GetGameObjectRealSize(c.gameObject);

            if (CollectibleSize.magnitude < m_collider.radius * m_catchableRatio){
                c.transform.parent = m_Transform;

                Collider collider = c.gameObject.GetComponent<Collider>();
                if (collider)
                {
                    collider.enabled = false;
                    float add = Mathf.Abs(Mathf.Min(CollectibleSize.x, CollectibleSize.y, CollectibleSize.z) * ColliderRelativeIncrease);
                    m_collider.radius += add;
                }
                Rigidbody rigidbody = c.gameObject.GetComponent<Rigidbody>();
                if (rigidbody)
                {
                    rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    rigidbody.useGravity = false;
                    rigidbody.isKinematic = true;
                }
                c.gameObject.layer = 0;
                m_spawner.m_collectibleList.Remove(c.gameObject);
                m_spawner.Spawn();
            }
        }
    }
    #endregion

    #region Class Methods
    private Vector3 GetGameObjectRealSize(GameObject gameObject)
    {
        Vector3 sizeInScene = gameObject.GetComponent<MeshFilter>().sharedMesh.bounds.size;
        Vector3 scaleInScene = gameObject.transform.localScale;
        return new Vector3(sizeInScene.x * scaleInScene.x, sizeInScene.y * scaleInScene.y, sizeInScene.z * scaleInScene.z);
    }
    #endregion

    #region Tools Debug And Utilities
    private void OnGUI()
    {
        GUILayout.Button("m_collider.radius " + Math.Round(m_collider.radius, 3));
        GUILayout.Button("m_collectible number " + m_spawner.m_collectibleList.Count);
    }
    #endregion

    #region Private an Protected Members
    private Transform m_Transform;
    private SphereCollider m_collider;
    #endregion

}