using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    bool alive = true;
    public float speed = 5;
    public float jumpforce = 400f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject Player;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spawnValue;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;

    public float speedIncreasePerPoint = 0.1f;

    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -5)
        {
            Die();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Player.transform.position.y < -spawnValue)
        {
            RespawnPoint();
        }
    }

    public void Die()
    {
        alive = false;
        // Restart the game
        Invoke("Restart", 1);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
        rb.AddForce(Vector3.up * jumpforce);
    }
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Obstacles")
        {
            Destroy(gameObject, 1f);
        }
    }
    public void RespawnPoint()
    {
        transform.position = spawnPoint.position;
    }

}