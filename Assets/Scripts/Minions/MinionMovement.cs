using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 _forward;
    [SerializeField] private TeamNames _curTeam;

    [SerializeField] private List<Vector3> _laneMarkers;
    [SerializeField] private float _speed = 3;
    [SerializeField] private int _destinationIndex;
    
    


    void Start()
    {
        _forward = transform.forward;
        _destinationIndex = getClosestLaneMarker();

    }

    // Update is called once per frame
    void Update()
    {
        if(_destinationIndex < _laneMarkers.Count){
            transform.position = Vector3.MoveTowards(gameObject.transform.position, _laneMarkers[_destinationIndex], _speed * Time.deltaTime);
        
            if(Vector3.Distance(gameObject.transform.position, _laneMarkers[_destinationIndex]) < 0.2){
                Debug.Log("updating destination index");
                _destinationIndex += 1;
            }
        } else {
            Destroy(gameObject);
        }

    }

    public void setLaneMarkers(List<Vector3> markers){
        _laneMarkers = markers;
    }

    private int getClosestLaneMarker() {
        
        float minDist = Vector3.Distance(_laneMarkers[0], transform.position);
        int index = 0;
        for (int i = 1; i < _laneMarkers.Count; i++)
        {
            float dist = Vector3.Distance(_laneMarkers[i], transform.position);
            if(dist < minDist){
                Debug.Log("minDist:"+ minDist);
                minDist = dist;
                index = i;
            }
        }

        return index;
    }
}
