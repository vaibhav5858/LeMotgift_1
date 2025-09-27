using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Cube : MonoBehaviour
{
    // Start is called before the first frame update

    float g_MoveSpeed = 0;
    Vector3 g_MoveDirection = Vector3.zero;


    float g_RotateSpeed = 0;
    Vector3 g_RotateDirection = Vector3.zero;
    void Start()
    {
        g_MoveSpeed = 3;
        g_RotateSpeed = 50;
    }

    // Update is called once per frame
    void Update()
    {
        m_move();
        m_Rotate();
        m_Scale();
    }

     void m_move()
    {
        g_MoveDirection.z = Input.GetAxis("Vertical");
        g_MoveDirection.x = Input.GetAxis("Horizontal");

        this.transform.Translate(g_MoveDirection * g_MoveSpeed * Time.deltaTime,Space.World);
    }

    void m_Rotate()
    {
        g_RotateDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            g_RotateDirection.y = 1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            g_RotateDirection.y = -1;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            g_RotateDirection.x = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            g_RotateDirection.x = -1;
        }

        this.transform.Rotate(g_RotateDirection*g_RotateSpeed*Time.deltaTime);

    }

    void m_Scale()
    {
       

        if (Input.GetKey(KeyCode.I))
        {
            this.transform.localScale += Vector3.one * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.O))
        {
            this.transform.localScale -= Vector3.one * Time.deltaTime;


            if (this.transform.localScale.x < 1)
            {
                this.transform.localScale = Vector3.one;
            }
        }
    }
}