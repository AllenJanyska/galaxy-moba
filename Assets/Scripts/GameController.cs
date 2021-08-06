using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TeamNames{
    Red,
    Blue,
    None
}


public class GameController : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] private Dictionary<TeamNames, Color> TeamColors = new Dictionary<TeamNames, Color>();
    //Objective dictionary
    //[SerializeField] private Dictionary<TeamNames, >



    void Start()
    {

        TeamColors.Add(TeamNames.Red, Color.red);
        TeamColors.Add(TeamNames.Blue, Color.blue);
        TeamColors.Add(TeamNames.None, Color.gray);
        
    }

    public Color getTeamColor(TeamNames team){
        return TeamColors[team];
    }



}
