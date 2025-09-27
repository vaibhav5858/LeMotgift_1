using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_ZombieManager : MonoBehaviour
{
    public GameObject g_ZombiePrefab;
    
    GameObject g_CloneObj;
 
    // Start is called before the first frame update
    void Start()
    {
        
        m_InitZombies();
    }

    // Update is called once per frame
    void Update()
    {
        //m_SpawnZombies();
       
    }

    void m_InitZombies()
    {
       
        {
            
           g_CloneObj = Instantiate(g_ZombiePrefab);
        }

    }

    
}