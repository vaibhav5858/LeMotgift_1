using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldVersionMovement : MonoBehaviour
{
    public float g_CharacterMoveSpeed, g_CharacterRotateSpeed = 0;
    // public ParticleSystem g_MuzzleFlash;
    // public GameObject g_HitVFX;
    Vector3 g_MoveDirection, g_RotateDirection, g_CameraEulerAngle = Vector3.zero;
    CharacterController g_CharacterController;
    Camera g_PlayerCamera;
    public float speed = 5;
    public float jumpforce = 400f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

        Application.targetFrameRate = 30;
        g_CharacterController = this.GetComponent<CharacterController>();
        g_PlayerCamera = this.transform.GetChild(0).GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        //if(C_GameManager.g_GameStartFlag)
        {
            m_ManagePlayerMovement();
            m_ManagePlayerRotation();
            Jump();
        }

    }

    void m_ManagePlayerMovement()
    {
        g_MoveDirection = this.transform.forward * Input.GetAxis("Vertical");
        g_MoveDirection += this.transform.right * Input.GetAxis("Horizontal");

        g_CharacterController.SimpleMove(g_MoveDirection * g_CharacterMoveSpeed);

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            g_MoveDirection = this.transform.forward * Input.GetAxis("Vertical");

        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            g_MoveDirection = this.transform.forward * Input.GetAxis("Horizontal");

        }
    }
    void m_ManagePlayerRotation()
    {
        g_RotateDirection.x = -Input.GetAxis("Mouse Y") * g_CharacterRotateSpeed * Time.deltaTime;
        g_PlayerCamera.transform.Rotate(g_RotateDirection, Space.Self);

        g_CameraEulerAngle = Vector3.zero;
        g_CameraEulerAngle.x = g_PlayerCamera.transform.localEulerAngles.x;

        if (g_CameraEulerAngle.x > 200 && g_CameraEulerAngle.x < 300)
        {
            g_CameraEulerAngle.x = 300;
        }
        else if (g_CameraEulerAngle.x < 100 && g_CameraEulerAngle.x > 60)
        {
            g_CameraEulerAngle.x = 60;
        }

        g_PlayerCamera.transform.localEulerAngles = g_CameraEulerAngle;

        g_RotateDirection = Vector3.zero;
        g_RotateDirection.y = Input.GetAxis("Mouse X") * g_CharacterRotateSpeed * Time.deltaTime;
        this.transform.Rotate(g_RotateDirection, Space.World);
    }
    public void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
        rb.AddForce(Vector3.up * jumpforce);
    }

}
