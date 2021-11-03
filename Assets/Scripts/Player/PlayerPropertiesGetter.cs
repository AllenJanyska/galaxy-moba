using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPropertiesGetter : MonoBehaviour
{

    private PlayerProperties _parentProperties;
    // Start is called before the first frame update
    void Start()
    {
        _parentProperties = gameObject.transform.parent.GetComponent<PlayerProperties>();
    }

    public TeamNames GetTeam()
    {
        return _parentProperties.GetTeam();
    }
}
