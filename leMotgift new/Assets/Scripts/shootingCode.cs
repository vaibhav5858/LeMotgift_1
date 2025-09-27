using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Shooter : MonoBehaviour
{
    public GameObject g_CannonBallPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_ShootCannonBall();
    }

    GameObject g_SpawnedCannonBall;
    void m_ShootCannonBall()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1))
        {
            g_SpawnedCannonBall = Instantiate(g_CannonBallPrefab);
            g_SpawnedCannonBall.transform.position = Camera.main.transform.position;
            g_SpawnedCannonBall.GetComponent<Rigidbody>().AddForce(Vector3.forward * 30, ForceMode.VelocityChange);
        }
    }
}