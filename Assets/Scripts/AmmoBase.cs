using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AmmoBase : MonoBehaviour{
    // Start is called before the first frame update
    private float damage;

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
