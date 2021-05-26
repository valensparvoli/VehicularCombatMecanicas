using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    public float Speed;
    public float TurnSpeed;
    public float gravityMultiplier; 
    int score;

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (score == 11)
        {
            Debug.Log("Ganaste");
        }
    }
    void FixedUpdate()
    {
        Move();
        Turn();
        Fall();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(new Vector3(Vector3.forward.x,0,Vector3.forward.z) * Speed * 10);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * -Speed * 10);
        }
        Vector3 LocalVelocity = transform.InverseTransformDirection(rb.velocity);
        LocalVelocity.x = 0;
        rb.velocity = transform.TransformDirection(LocalVelocity);
    }

    void Turn()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(Vector3.up * TurnSpeed * 10);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(-Vector3.up * TurnSpeed * 10);
        }
    }

    void Fall()
    {
        rb.AddForce(Vector3.down * gravityMultiplier * 10);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arco"))
        {
            score += 1;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("AumentoVelocidad"))
        {
            StartCoroutine("PowerUpVelocidad");
        }
    }

    IEnumerator PowerUpVelocidad()
    {
        Speed += 2;
        yield return new WaitForSeconds(1f);
        Speed -= 2;
    }
}
