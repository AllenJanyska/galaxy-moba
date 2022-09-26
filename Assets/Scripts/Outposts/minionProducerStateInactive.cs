using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minionProducerStateInactive : minionProducerState
{
    // Start is called before the first frame update
    void Start()
    {
        setProduction(false);
    }
}
