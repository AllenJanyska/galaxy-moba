using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamAssignment : MonoBehaviour
{

    [SerializeField] private TeamNames teamAssignment;

    // Start is called before the first frame update
    void Start()
    {
        teamAssignment = TeamNames.None;
    }

    public void SetTeam(TeamNames team)
    {
        teamAssignment = team;
    }

    public TeamNames GetTeam()
    {
        return teamAssignment;
    }

}
