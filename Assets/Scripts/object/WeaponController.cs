using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public BaseWeapon _weapon;

    [SerializeField] private Vector3 _bulletOrigin;
    public GameObject ammoPrefab;

    private Transform _transform;
    private AudioSource _fireSound;

    // Start is called before the first frame update
    void Start()
    {
        _fireSound = GetComponent<AudioSource>();
        _transform = GetComponent<Transform>();
    }

    void Update(){
        Debug.DrawRay(_transform.position, _transform.forward, Color.grey, 0.1f);
    }


    //Currently target point does nothing 
    public void Fire(Vector3 targetPoint){


        Vector3 targetDirection = targetPoint - _transform.position;
        Quaternion targetHeading = Quaternion.LookRotation(targetDirection, Vector3.up);
        Debug.DrawRay(_transform.position, targetDirection, Color.red, 1.0f);

        Instantiate(ammoPrefab, _transform.position , targetHeading);
        _fireSound.Play();
    }

}
