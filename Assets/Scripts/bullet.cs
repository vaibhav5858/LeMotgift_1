using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the tag "Zombie"
        if (collision.gameObject.CompareTag("Zombie"))
        {
            // Destroy the zombie
            Destroy(collision.gameObject);
        }

        // Destroy the bullet
        Destroy(gameObject);
    }
}
