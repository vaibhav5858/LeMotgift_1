using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform target;
    float Dist_from_target=10;
    public bool is_active=false;
    // Start is called before the first frame update
    public void OnEnable()
    {
        is_active = true;
    }

    // Update is called once per frame
    void Update()
    {
        SetDesForAI();
    }
    void SetDesForAI()
    {
        Agent.destination = target.position;

    }
    void KillZombie()
    {
        StartCoroutine(KillSequence());
    }
    IEnumerator KillSequence()
    {
        is_active = false;
        Agent.isStopped = true;
        yield return new WaitForSeconds(3);
        this.gameObject.SetActive(false);
    }

    
}
