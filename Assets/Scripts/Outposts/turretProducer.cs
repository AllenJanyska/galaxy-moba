using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretProducer : MonoBehaviour
{

    private int turretCount;
    [SerializeField] private GameObject turretPrefab;
    [SerializeField] private int constructionTime = 5;

    [SerializeField] private GameObject[] turretAnchors; 
    private bool turretBuilding;


    public void Activate(){
        StartCoroutine("ProduceTurret");
    }

    public void Deavtivate(){
        StopCoroutine("ProduceTurret");
    }


    private IEnumerator ProduceTurret(){

        yield return new WaitForSeconds(constructionTime);

        Debug.Log(turretAnchors);

        if(turretAnchors != null && turretAnchors.Length > 0){
            Debug.Log("making turret");
            turretAnchors[0].GetComponent<TurretAnchorController>().SpawnTurret();
        }
    }
}
