using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Transform _transform;
    
    [SerializeField] private GameObject debugTargetMarker;
    [SerializeField] private Camera _cam;

    [SerializeField] private LinkedList<WeaponController> weapons; 
    [SerializeField] private int _weaponCount;

    [SerializeField] private Vector3 _target;

    private WeaponController temp;

    void Start()
    {

        weapons = new LinkedList<WeaponController>();
        _transform = GetComponent<Transform>();

        for(int i = 0; i < _transform.childCount; i++){
            if(_transform.GetChild(i).tag == "WeaponControl"){
                
                weapons.AddFirst(_transform.GetChild(i).gameObject.GetComponent<WeaponController>());
            }
        }
        
        _weaponCount = weapons.Count;
    }

    void FixedUpdate(){

        //Update the target to match the mouse position
        Vector3 mousePos = Input.mousePosition;
        Ray ray = _cam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        _target = Vector3.zero;
        
        LayerMask mask = ~LayerMask.GetMask("ControlHitBoxes");

        if(Physics.Raycast(ray, out hit, 300, mask,QueryTriggerInteraction.Ignore)){
            _target = hit.point;
        } 
    }

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            FireProcedure();
        }
    }

    void FireProcedure(){
        
        for(LinkedListNode<WeaponController> current = weapons.First; current != null; current = current.Next){
                current.Value.Fire(_target);
        }
        

    }
}
