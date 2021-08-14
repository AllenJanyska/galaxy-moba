using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchClock : MonoBehaviour
{
    
    [SerializeField] private float matchLength = 0;

    // Update is called once per frame
    void Update()
    {
        matchLength += Time.deltaTime;
    }
}
