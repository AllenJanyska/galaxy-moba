using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // revisit this import, feels like it will pull in more than needed

public class OutpostController : MonoBehaviour
{

    private int turretCount;
    
    [SerializeField] private GameObject[] turretAnchors; 
    private bool turretBuilding;

    private minionCreation _minionCreationCache;
    private MapController _mapController;

    [SerializeField] private TeamNames _curTeam = TeamNames.None;

    // Start is called before the first frame update
    void Start()
    {
        _minionCreationCache = gameObject.GetComponent<minionCreation>();

        var mapControllers = GameObject.FindGameObjectsWithTag("MapController");
        if(mapControllers.Length != 1) {
            throw new Exception($"Expected 1 map controller but found {mapControllers.Length}. Please only add 1 map controller per scene.");
        } 
        _mapController = mapControllers[0].GetComponent<MapController>();
    }

    protected private void setTurretBuilding(bool newState){
        turretBuilding = newState;
    }

    public void startMinionProduction(){
        Debug.Log("begining minion construction");
        _minionCreationCache.Activate(_mapController.getPathMarkers(_curTeam));
    }

    public void setTeam(TeamNames team){
        _curTeam = team;
    }

    public TeamNames getTeam(){
        return _curTeam;
    }
}
