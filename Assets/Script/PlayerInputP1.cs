using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputP1 : MonoBehaviour
{
    public static float SpeedPlayer1 = 1f;
    public static float TurnSpeed = 0.5f;
    public float gravityMultiplier = 0.3f;
    
    public static int AmpliadorNumeros = 10;

    public static int scorePlayer1=0;
    public Text UIScorePlayer2;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (scorePlayer1 < 0)
        {
            scorePlayer1 = 0;
        }
        UIScorePlayer2.text = "Score Player2: " + scorePlayer1.ToString();
    }

    private void FixedUpdate()
    {
        MovePlayer1();
        TurnPlayer1();
        FallPlayer1();
    }

    void MovePlayer1()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * SpeedPlayer1 * AmpliadorNumeros);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * -SpeedPlayer1 * AmpliadorNumeros);
        }
        Vector3 LocalVelocity = transform.InverseTransformDirection(rb.velocity);
        LocalVelocity.x = 0;
        rb.velocity = transform.TransformDirection(LocalVelocity);
    }

    void TurnPlayer1()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(Vector3.up * TurnSpeed * AmpliadorNumeros);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(-Vector3.up * TurnSpeed * AmpliadorNumeros);
        }
    }

    void FallPlayer1()
    {
        rb.AddForce(Vector3.down * gravityMultiplier * AmpliadorNumeros);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arco"))
        {
            scorePlayer1 += 1;
            Destroy(other.gameObject);
            PlayerInput.cantidadArcos -= 1;
        }

        if (other.CompareTag("AumentoVelocidad"))
        {
            Debug.Log("Hola");
            StartCoroutine("PowerUpVelocidad");
            Debug.Log(SpeedPlayer1);
        }
    }

    IEnumerator PowerUpVelocidad()
    {
        SpeedPlayer1 = SpeedPlayer1 + 1f;
        yield return new WaitForSecondsRealtime(1f);
        SpeedPlayer1 -= SpeedPlayer1 - 1f;
        
    }
}
