using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum productionState{
        Active,
        Inactive, 
        Threatened
};
    

public class minionCreation : MonoBehaviour
{
    
    [SerializeField] private Quaternion minion_rotation;
    [SerializeField] private GameObject minionPrefab;
    private productionState _curProduction;
    private float _productionRate;
    private Dictionary<productionState, minionProducerState> _minionStates;

    private AlignmentControl _alignmnetControllerCache;
    // Start is called before the first frame update

    void Start()
    {
        _minionStates = new Dictionary<productionState, minionProducerState>();
        _minionStates.Add(productionState.Active, new minionProducerStateActive());
        _minionStates.Add(productionState.Inactive, new minionProducerStateInactive());

        _alignmnetControllerCache = gameObject.GetComponent<AlignmentControl>();
        
    }

    void setProduction(productionState new_state){
        _curProduction = new_state;
    }


    public void Activate(){
        _curProduction = productionState.Active;

        StartCoroutine("Produce");
    }

    public void Deavtivate(){
        _curProduction = productionState.Inactive;
        StopCoroutine("Produce");
    }


    private IEnumerator Produce(){

        yield return new WaitForSeconds(5);

        Debug.Log("makeing minion");
        Instantiate(minionPrefab, transform.position, Quaternion.Euler(0.0f,0.0f,0.0f));


        StartCoroutine("Produce");

    }
    

}
