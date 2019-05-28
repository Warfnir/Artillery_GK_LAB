using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    public float acceleration = 1.0f;
    public float max_speed = 3.0f;
    public float braking = 0.9f;
    public float rotation_speed = 1.0f;

    private GameObject Barrel;
    public Transform Shooting_point;

    private Vector3 move_direction = Vector3.zero;
    public Rigidbody CannonBall;
    public float BallSpeed = 10000.0f;

    public ParticleSystem explosion;
    public AudioSource audio;

    ResultScript resScript;
    GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();  
        Barrel = transform.Find("Barrel Rotation Point").gameObject;
        canvas = GameObject.Find("Result");
        resScript = canvas.GetComponent<ResultScript>();
      //  explosion = Resources.Load<ParticleSystem>("Assets/Prefab/Explosion.prefab");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            move_direction += transform.forward * Time.deltaTime * acceleration;
        }
        if (Input.GetKey(KeyCode.S))
        {
            move_direction -= transform.forward * Time.deltaTime * acceleration;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotation_speed, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotation_speed, 0);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Barrel.transform.Rotate(0, 0, -rotation_speed);
        }
        if (Input.GetKey(KeyCode.E))
        {
            Barrel.transform.Rotate(0, 0, rotation_speed);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody ball;
            ball = Instantiate(CannonBall, Shooting_point.transform.position, Barrel.transform.rotation) as Rigidbody;
            ball.AddForce((Shooting_point.transform.position - Barrel.transform.position) * 500f);
            ParticleSystem ps;
            ps = Instantiate(explosion, Shooting_point.transform.position, Barrel.transform.rotation);         
            ps.Play();
            audio.Play();
            resScript.shoots += 1;

        }


        move_direction *= braking;
        //if(move_direction.sqrMagnitude > max_speed)
        //{
        //    move_direction = transform.forward * max_speed;
        //}
        characterController.Move(move_direction);
    }
}
