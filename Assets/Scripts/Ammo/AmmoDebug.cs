using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class AmmoDebug : AmmoBase
{

    private float damage = 25.0f;
    private Transform _transform;
    private GameObject _parent;
    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {

        _transform = GetComponent<Transform>();
        dir = _transform.forward;
        setDamage(damage);
    }

    void FixedUpdate()
    {

        _transform.Translate(dir, Space.World);

        Debug.DrawRay(_transform.position, dir, Color.red, 0.01f);
    }

    void OnCollisionEnter(Collision collision)
    {
        //ContactPoint contact = collision.contacts[0];
        //Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        //Vector3 position = contact.point;
        //Instantiate(explosionPrefab, position, rotation);
        Destroy(gameObject);

        Debug.Log("Hit");
    }

}
