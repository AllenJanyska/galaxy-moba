using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float HealthMax;
    [SerializeField] private float HealthLevel;
    void Start(){
        HealthLevel = HealthMax;
    }
    
    void OnCollisionEnter(Collision _object){

        Debug.Log("Collision");

        if(_object.gameObject.tag == "Bullet"){
            Debug.Log("Healthbar Hit");

            AmmoBase projectile = _object.gameObject.GetComponent<AmmoBase>();
            HealthLevel = HealthLevel - projectile.getDamage();
        }

        if(HealthLevel <= 0){
            Destroy(gameObject);
        } 
    
    } 
}
