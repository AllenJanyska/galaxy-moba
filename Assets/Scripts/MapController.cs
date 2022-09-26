using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    //blue base is 0 and red base is last
    [SerializeField] private GameObject[] pathMarkers;
    private List<Vector3> _pathPositions = new List<Vector3>();


    void Start() {

        Debug.Log(pathMarkers[0].GetComponent<Transform>().position);

        for (int i = 0; i < pathMarkers.Length; i++)
        {
            Debug.Log(i);
            _pathPositions.Add(pathMarkers[i].GetComponent<Transform>().position);
        }
    }


    public List<Vector3> getPathMarkers(TeamNames team){
        if(team == TeamNames.Red){
            // reverse path markers before returning. Need to look up how to do that
            _pathPositions.Reverse();
        }
        
        return _pathPositions;
    }

}
