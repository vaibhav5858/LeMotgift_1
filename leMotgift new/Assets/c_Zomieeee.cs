using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cZomieeee : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent gNavemeash;
    public Transform target1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mzombieMove();
    }

    void mzombieMove()
    {
        gNavemeash.destination = target1.position;
    }
}
