using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignmentControl : MonoBehaviour
{

    private enum state{
        neutral,
        owned,
        capturing,
        none
    }

    private GameController _gameController;

    private minionCreation _minionCreationCache;

    /// <summary>All GameObjects around the outpost that change color when the team is changed.
    ///This is defined through the unity editor as part of the prefab</summary>
    [SerializeField] private GameObject[] _colorElements;
    
    ///<summary> a cache of components for all connected color elements. </summary>
    private LinkedList<colorController> _colorElementCache = new LinkedList<colorController>();

    ///<summary> user defined points where turrets will spawn as an outpost is captured. </summary>
    [SerializeField] private GameObject[] _turretAnchors;


    private TeamNames _destTeam;
    private TeamNames _curTeam = TeamNames.None;

    [SerializeField] private state _curState = state.neutral;

    // Start is called before the first frame update
    void Start()
    {
        _curState = state.neutral;

        for(int i =0; i < _colorElements.Length; i++){
            _colorElementCache.AddFirst(_colorElements[i].GetComponent<colorController>());

        }
        Debug.Log(_colorElementCache.Count);
        _gameController = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GameController>();
        _minionCreationCache = gameObject.GetComponent<minionCreation>();

    }

    private void OnTriggerEnter(Collider other){

        //checks if the collision is with a player
        if(other.tag == "Player" & _curState == state.neutral){
            _curState = state.capturing;
            _destTeam = other.gameObject.GetComponent<PlayerProperties>().GetTeam();
            StartCoroutine("Capturing");
        } else if(other.tag == "Player"){
            CancelCap();
        }
    }

    private void CancelCap(){
            _curState = state.neutral;
            _destTeam = TeamNames.None;
    }


    //Transition from neutral to captured by a team
    private void CompleteCap(){

        //Change color of all connected elements
        for(LinkedListNode<colorController> i =_colorElementCache.First; i != null; i= i.Next){
            i.Value.SetTeam(_curTeam);
        }

        if(_minionCreationCache != null){
            _minionCreationCache.Activate();
        }

    }

    private IEnumerator Capturing(){

        yield return new WaitForSeconds(5);
        _curState = state.owned;
        _curTeam = _destTeam;
        _destTeam = TeamNames.None;

        CompleteCap();
        
    }


    private void OnTriggerExit(Collider other){
        
        if(_curState == state.capturing){
            CancelCap();
            StopCoroutine("Capturing");
        }

    }

    


}
