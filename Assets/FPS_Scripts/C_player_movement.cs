using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_player_movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 10f;

    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.SimpleMove(move * speed);
    }
}
