using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody _rb;
    private Transform _transform;
    [SerializeField] private Vector3 _dir;
    [SerializeField] private Vector3 _rot;
    [SerializeField] private float _strafeSpeed = 1.0f;
    [SerializeField] private float _movementSpeed = 1.0f;
    


    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        _transform = gameObject.GetComponent<Transform>();
    }

    void FixedUpdate(){
        
        _rb.AddForce(_dir);
        _rb.AddRelativeTorque(_rot);

    }    
    
    // Update is called once per frame
    void Update()
    {
        _dir = Vector3.zero;
        Quaternion offset = Quaternion.AngleAxis(-90, Vector3.up);
        Vector3 left = offset * _transform.forward;
        _rot = Vector3.zero;



        if(Input.GetKey("w")){
            _dir = (_transform.forward * _movementSpeed) + _dir;    
        }
        if(Input.GetKey("s")){
            _dir = (_transform.forward * -1 * _movementSpeed) + _dir;
        }
        if(Input.GetKey("a")){
            _dir = (left * _strafeSpeed) + _dir;
        }
        if(Input.GetKey("d")){
            _dir = (left * -1 * _strafeSpeed) + _dir;
        }


        //Movement guides

        Debug.DrawRay(_transform.position, _transform.forward*15, Color.red, 0.01f);
        Debug.DrawRay(_transform.position, _dir*15, Color.green, 0.01f);
        Debug.DrawRay(_transform.position, left*15, Color.gray, 0.1f);


   
    }

    void OnCollisionEnter(Collision collision)
    {
        //ContactPoint contact = collision.contacts[0];
        //Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        //Vector3 position = contact.point;
        //Instantiate(explosionPrefab, position, rotation);
        Debug.Log("movement Hit");
    }




}
