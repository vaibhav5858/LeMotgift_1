using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_marker : MonoBehaviour
{
    float Start_time = 0;
    float Elapse_time = 0;
    float Life_span = 2;
    // Start is called before the first frame update
    void Start()
    {
        Start_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Elapse_time = Time.time - Start_time;
        if (Elapse_time > Life_span)
        {
            Destroy(this.gameObject);
        }
    }
}
