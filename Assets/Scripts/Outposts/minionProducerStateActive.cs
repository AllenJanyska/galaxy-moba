using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minionProducerStateActive : minionProducerState
{
    private float _productionRate;

    // Start is called before the first frame update
    void Start()
    {
        
        setProduction(true);
        _productionRate = 5f;

    }

    public float getProductionRate(){
        return _productionRate;
    }

}
