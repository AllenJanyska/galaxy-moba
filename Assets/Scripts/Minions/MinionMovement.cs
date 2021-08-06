using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 _forward;

    void Start()
    {
        _forward = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_forward*0.05f);
    }
}
