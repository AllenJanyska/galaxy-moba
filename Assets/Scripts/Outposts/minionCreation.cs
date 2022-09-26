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

    private AlignmentControl _alignmnetControllerCache;

    private MapController _mapController;

    void Start()
    {
        _alignmnetControllerCache = gameObject.GetComponent<AlignmentControl>();
        
        _mapController = GameObject.FindGameObjectsWithTag("MapController")[0].GetComponent<MapController>();

    }

    void setProduction(productionState new_state){
        _curProduction = new_state;
    }


    public void Activate(List<Vector3> path){
        _curProduction = productionState.Active;

        StartCoroutine(Produce(path));
    }

    public void Deavtivate(){
        _curProduction = productionState.Inactive;
        StopCoroutine("Produce");
    }


    private IEnumerator Produce(List<Vector3> movementPath){

        Debug.Log("begining construction");

        yield return new WaitForSeconds(5);

        Debug.Log("making minion");

        // figure out if i can pass args to an instantiated prefab
        // otherwise i can create 2 different minion prefabs
        GameObject minion = Instantiate(minionPrefab, transform.position, Quaternion.Euler(0.0f,0.0f,0.0f));
        minion.GetComponent<MinionMovement>().setLaneMarkers(movementPath);

        StartCoroutine(Produce(movementPath));

    }
    

}
