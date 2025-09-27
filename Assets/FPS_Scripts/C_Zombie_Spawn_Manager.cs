using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Zombie_Spawn_Manager : MonoBehaviour
{
    public GameObject ZombiePrefab;

    GameObject[] g_ZombieObjArray;
    float g_StartTime;
    float g_ElapsedTime;
    public Transform g_Target;
    public GameObject[] g_SpawnPosArray;
    // Start is called before the first frame update
    void Start()
    {
        g_StartTime = Time.time;
        m_CreateZombieObjs();
    }

    // Update is called once per frame
    void Update()
    {
        g_ElapsedTime = Time.time - g_StartTime;

        if (g_ElapsedTime >= 3)
        {
            g_StartTime = Time.time;
            m_LaunchZombie();
        }
    }

    void m_CreateZombieObjs()
    {
        int l_TotalCount = 10;
        g_ZombieObjArray = new GameObject[l_TotalCount];

        for (int i = 0; i < l_TotalCount; i++)
        {
            g_ZombieObjArray[i] = Instantiate(ZombiePrefab);
            //g_ZombieObjArray[i].GetComponent<C_ZombiControler>().Target = g_Target;
            g_ZombieObjArray[i].SetActive(false);
        }
    }

    void m_LaunchZombie()
    {

        for (int i = 0; i < g_ZombieObjArray.Length; i++)
        {
            if (g_ZombieObjArray[i].activeInHierarchy == false)
            {
                int k = Random.Range(0, g_SpawnPosArray.Length);
                g_ZombieObjArray[i].transform.position = g_SpawnPosArray[k].transform.position;
                g_ZombieObjArray[i].SetActive(true);
                break;
            }
        }

    }
}
