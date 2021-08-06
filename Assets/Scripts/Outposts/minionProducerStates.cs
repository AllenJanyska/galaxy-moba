using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class minionProducerState : MonoBehaviour
{
    private bool productionEnabled;
    // Start is called before the first frame update
    
    public bool getProduction(){
        return productionEnabled;
    }

    protected void setProduction(bool new_state){
        productionEnabled = new_state;
    }

}
