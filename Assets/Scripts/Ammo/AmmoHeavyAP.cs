using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoHeavyAP : AmmoBase
{
    private float damage = 25.0f;
    private Transform _transform;
    private GameObject _parent;
    private Vector3 dir;
    public GameObject _projectile;

    //sets the speed as a factor of 1
    //0 is no movement
    //multiplies 1 by speed so can increase very fast
    [SerializeField] private float _speed;
    public AmmoHeavyAP(GameObject ammoModel)
    {
        _projectile = ammoModel;
    }
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
    }


    void OnCollisionEnter(Collision collision)
    {
        //ContactPoint contact = collision.contacts[0];
        //Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        //Vector3 position = contact.point;
        //Instantiate(explosionPrefab, position, rotation);
        Destroy(gameObject);
    }


}
