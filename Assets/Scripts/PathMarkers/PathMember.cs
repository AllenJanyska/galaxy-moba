using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class will handle the atributes of the path. To start it will be straight lines from one marker to the next
//markers will be built into the map 
public class PathMember : MonoBehaviour
{
    [SerializeField] private GameObject _RedNeighbor; //Toward the negative x negative z corner 
    private GameObject _BlueNeighbor; //toward the positive x positive z corner
    

    //cache variables
    private Transform _RedNeighborTrans;
    private Transform _BlueNeighborTrans;
    private Transform _selfTrans;

    // Start is called before the first frame update
    void Start()
    { 
        _RedNeighborTrans = _RedNeighbor.GetComponent<Transform>();
        _selfTrans = gameObject.GetComponent<Transform>();

        PathMember temp = _RedNeighbor.GetComponent<PathMember>();

        temp.setBlueNeighbor(gameObject);

        //line will be drawn only to _redNeighbor
        Debug.DrawLine(_selfTrans.position, _RedNeighborTrans.position, Color.blue, 300.0f);

    }


    public void setBlueNeighbor(GameObject marker){
        _BlueNeighbor = marker;
        _BlueNeighborTrans = _BlueNeighbor.GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
                
    }
}
