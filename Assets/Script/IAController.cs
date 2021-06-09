using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAController : MonoBehaviour
{
    public Transform nextPosition;
    Rigidbody rb;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(CalcularPlayer(), ForceMode.Force);
    }

    private Vector3 CalcularPlayer()
    {
        Vector3 VectorConDistancia = (nextPosition.position - transform.position).normalized;
        
        return Vector3.Normalize(VectorConDistancia) * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerInputP1.scorePlayer1 -= 1;
        }
        else if (collision.collider.CompareTag("Player2"))
        {
            PlayerInputP2.scorePlayer2 -=1;
        }
    }
}
