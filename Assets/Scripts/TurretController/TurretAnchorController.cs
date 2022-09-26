using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAnchorController : MonoBehaviour
{


    [SerializeField] private GameObject turretPrefab;
    private GameObject turretReference;
    private Transform transformCache;
    // Start is called before the first frame update
    void Start()
    {
        transformCache = gameObject.GetComponent<Transform>();
        // SpawnTurret();
    }

    public void SpawnTurret()
    {
        Instantiate(turretPrefab, transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f), gameObject.GetComponent<Transform>());
        turretReference = transformCache.GetChild(0).gameObject;
    }
}