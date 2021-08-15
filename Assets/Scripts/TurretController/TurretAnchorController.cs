using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAnchorController : MonoBehaviour
{


    [SerializeField] private GameObject turretPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(turretPrefab, transform.position, Quaternion.Euler(0.0f,0.0f,0.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}