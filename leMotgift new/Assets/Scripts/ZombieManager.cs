using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    public GameObject Zombie;
    public GameObject [] SpawnPoints;
    float Elapse_time = 0;
    float Start_time = 0;
    public float Spawn_Interval = 0;
    int total_zombie_count;
    Zombie[] ZombieScriptArray;
    public GameObject Zombie_Prefab;
    // Start is called before the first frame update
    void Start()
    {
       Start_time = Time.time;
        Spawn_Interval = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Spawnzombies();
    }
    public void Spawnzombies()
    {
        Elapse_time= Time.time-Start_time;
        if(Elapse_time < Spawn_Interval)
        {
            Start_time=Time.time;
            Elapse_time = 0;
        }
        for(int i = 0; i < total_zombie_count; i++)
        {
            if (!ZombieScriptArray[i])
            {

            }
        }
    }
    public void InitZombies()
    {
        total_zombie_count = 20;
        ZombieScriptArray=new Zombie[total_zombie_count];
        for(int i = 0; i < total_zombie_count; i++)
        {
            Zombie = Instantiate(Zombie_Prefab);
            Zombie.SetActive(false);
            Zombie.transform.parent=this.transform;
            ZombieScriptArray[i]=Zombie.GetComponent<Zombie>();
        }
    }
}
