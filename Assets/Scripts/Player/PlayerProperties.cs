using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private TeamNames _curTeam;


    public TeamNames GetTeam(){
        return _curTeam;
    }


}
