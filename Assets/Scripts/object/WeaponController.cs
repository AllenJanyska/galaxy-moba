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

    void Update()
    {
        Debug.DrawRay(_transform.position, _transform.forward, Color.grey, 0.1f);
    }



    //passing in positive infinity will cause weapon to fire straight forward
    public void Fire(Vector3 targetPoint, bool targetInfinity)
    {

        Quaternion targetHeading = _transform.rotation;
        Vector3 targetDirection = Vector3.back;

        if (!targetInfinity)
        {
            targetDirection = targetPoint - _transform.position;
            targetHeading = Quaternion.LookRotation(targetDirection, Vector3.up);

        }

        Debug.DrawRay(_transform.position, targetDirection, Color.red, 2.0f);
        Instantiate(ammoPrefab, _transform.position, targetHeading);
        _fireSound.Play();

    }

}
