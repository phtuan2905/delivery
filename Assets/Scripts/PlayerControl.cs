using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float acceleration;
    public float deceleration;
    public float defaultDeceleration;
    public float maxSpeed;
    public float rotateSpeed;
    public float backdownRotateSpeed;
    public float brakeDeceleration;
    public Vector3 direction;
    public Rigidbody Navigator;
    private Rigidbody Player;
    public Vector3 velocity;
    public int inertia;
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = Player.velocity;
        GetInput();
        SetVelocity();
    }

    void GetInput()
    {
        float Move = Input.GetAxisRaw("Vertical");
        float Rotate = Input.GetAxisRaw("Horizontal");
        inertia = 0;
        deceleration = defaultDeceleration;
        if (Move < 0)
        {
            deceleration = brakeDeceleration;
            if (speed > 0)
            {
                StartCoroutine(Decelerating());
            }
            CheckBrakeOrBackdown();
            if (speed < 0)
            {   
                transform.Rotate(new Vector3(0f, backdownRotateSpeed, 0f) * Rotate * Time.deltaTime);
            }
        }
        else if ((Move + inertia) > 0)
        {
            if ((speed < maxSpeed && Rotate == 0 && Input.GetKey(KeyCode.Space)) || speed < acceleration)
            {
                StartCoroutine(Accelerating());
            }
            transform.Rotate(new Vector3(0f, rotateSpeed, 0f) * Rotate * Time.deltaTime);
        }        
        else if (Move == 0)
        {
            if (speed > 0)
            {
                StartCoroutine(Decelerating());
                transform.Rotate(new Vector3(0f, backdownRotateSpeed, 0f) * Rotate * Time.deltaTime);
            }
            SetInertia();
        }

        direction = new Vector3(Navigator.position.x - transform.position.x, 0f, Navigator.position.z - transform.position.z).normalized;

        Player.velocity = new Vector3((Move + inertia) * speed * direction.x, Player.velocity.y, (Move + inertia) * speed * direction.z);
    }

    bool isAccelerating = false;
    float acceleratingTime;
    IEnumerator Accelerating()
    {
        if (!isAccelerating)
        {
            if (speed <= 10)
            {
                acceleratingTime = 0.25f;
            }
            else
            {
                acceleratingTime = 0.75f;
            }
            isAccelerating = true;
            speed += acceleration;
            yield return new WaitForSeconds(acceleratingTime);
            isAccelerating = false;
        }
    }

    bool isDecelerating = false;
    float deceleratingTime = 0.1f;
    IEnumerator Decelerating()
    {
        if (!isDecelerating)
        {
            isDecelerating = true;
            speed -= deceleration;
            yield return new WaitForSeconds(deceleratingTime);
            isDecelerating = false;
        }
    }

    void SetInertia()
    {
        inertia = 1;
    }
    void CheckBrakeOrBackdown()
    {
        if (speed > 0)
        {
            inertia = 2;
        }
        else
        {
            inertia = 2;
            speed = -5;
        }
    }
    void SetVelocity()
    {
        if (speed < 0)
        {
            speed = 0;
        }
    }
}
