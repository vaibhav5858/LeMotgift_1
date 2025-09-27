using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_controller : MonoBehaviour
{

    CharacterController controller;
    public int speed;
    Vector3 move_direction = Vector3.zero;
    public float r_speed;
    Camera p_cam;
    Vector3 Cam_Euler_Angle = Vector3.zero;
    Vector3 Rotate_dir = Vector3.zero;
    public bool is_VFX_play=false;
    public ParticleSystem Gun_particle;
     Ray ray;
    Vector3 R_origin= Vector3.zero;
    RaycastHit r_info;
    public GameObject HitVFX;
   
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        p_cam = this.transform.GetChild(0).GetComponent<Camera>();
        R_origin.x = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        playermove();
        playerotate();
        manageWeapon();
        manageWeaponVFX();
    }
    public void playermove()
    {
        move_direction = this.transform.forward * Input.GetAxis("Vertical");
        move_direction += this.transform.forward * Input.GetAxis("Horizontal");
        controller.Move(move_direction * speed);

    }
    public void playerotate()
    {
        Rotate_dir.x=-Input.GetAxis("Mouse Y")*r_speed*Time.deltaTime;
        p_cam.transform.Rotate(Rotate_dir, Space.Self);
        Cam_Euler_Angle.x = p_cam.transform.localEulerAngles.x;
        if(Cam_Euler_Angle.x>200 && Cam_Euler_Angle.x<300)
        {
            Cam_Euler_Angle.x=300;
        }
        else if(Cam_Euler_Angle.x > 100 && Cam_Euler_Angle.x < 60)
        {
            Cam_Euler_Angle.x = 60;
        }
        p_cam.transform.localEulerAngles = Cam_Euler_Angle;
        Rotate_dir = Vector3.zero;
        Rotate_dir.y = Input.GetAxis("Mouse X")*r_speed * Time.deltaTime;
        this.transform.Rotate(Rotate_dir, Space.World);
    }
    public void manageWeapon()
    {
        if(Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }
    public void shoot()
    {
        if (Input.GetMouseButtonDown(0) && !is_VFX_play)
        {
            ray = p_cam.ViewportPointToRay(R_origin);
            if (Physics.Raycast(ray,out r_info))
            {
                Instantiate(HitVFX,r_info.point, Quaternion.LookRotation(r_info.normal));
            }
        }
       
    }
    public void manageWeaponVFX()
    {
        if (Input.GetMouseButtonDown(0) && !is_VFX_play)
        {
           
            Gun_particle.Play();
            is_VFX_play = true;
        }
        if (Input.GetMouseButtonUp(0) && is_VFX_play)
        {
            Gun_particle.Stop();
            is_VFX_play = false;
        }
    }
}
