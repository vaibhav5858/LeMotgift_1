using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Motrunning : MonoBehaviour
{
    bool alive = true;
    bool canJump = true;
    public float speed = 5;
    public float jumpforce = 400f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Rigidbody rb; // Declare the Rigidbody variable
    [SerializeField] GameObject Player;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spawnValue;
    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;
    public float speedIncreasePerPoint = 0.1f;
    public float jumpCooldown = 1.0f;
    float lastJumpTime;

    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);

        if (!canJump && Time.time - lastJumpTime >= jumpCooldown)
        {
            canJump = true;
        }
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.UpArrow) && canJump)
        {
            speed += speedIncreasePerPoint;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            speed -= speedIncreasePerPoint;
        }

        if (transform.position.y < -5)
        {
            Die();
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Jump();
        }

        if (Player.transform.position.y < -spawnValue)
        {
            RespawnPoint();
        }
    }

    public void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpforce);
            canJump = false;
            lastJumpTime = Time.time;
        }
    }

    public void Die()
    {
        alive = false;
        Invoke("Restart", 1);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Obstacles")
        {
            Destroy(gameObject, 0.8f);
        }
    }

    public void RespawnPoint()
    {
        transform.position = spawnPoint.position;
    }
}