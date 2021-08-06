using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Color _targetColor = Color.gray; 
    private MeshRenderer _redererCache;
    private GameController _gameController;
    void Start()
    {
        //cache the mesh rederer
        _redererCache = gameObject.GetComponent<MeshRenderer>();

        //Cache the global game controller
        _gameController = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GameController>();

    }

    public void SetTeam(TeamNames team){
        Debug.Log(team.ToString());
        Debug.Log("updating team");
        _targetColor = _gameController.getTeamColor(team);
        SetColor(_targetColor);
        
    }

    public void SetColor(Color new_color){
        _targetColor = new_color;
        _redererCache.material.SetColor("_Color", new_color);
    }

}
