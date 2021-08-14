using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AmmoBase : MonoBehaviour{
    
    private float damage;

    // Start is called before the first frame update
    void Start(float _damage){
        damage = _damage;   
    }

    protected void setDamage(float newVal){
        damage = newVal;
    }

    public float getDamage(){
        return damage;
    }

}
