using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_Zomieeee : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent g_Navemeash;
    public Transform target;
    public float moveSpeed = 3.0f; // Adjust the speed as needed

    // Start is called before the first frame update
    void Start()
    {
        // Initialize other components or settings if needed
    }

    // Update is called once per frame
    void Update()
    {
        m_zombieMove();
    }

    public void m_zombieMove()
    {
        g_Navemeash.speed = moveSpeed; // Set the speed
        g_Navemeash.destination = target.position;
    }
}