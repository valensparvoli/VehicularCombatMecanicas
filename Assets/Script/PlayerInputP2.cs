using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputP2 : MonoBehaviour
{
    public static float SpeedPlayer2 = 1f;
    public static float TurnSpeed = 0.5f;
    public float gravityMultiplier = 0.3f;
    public static int AmpliadorNumeros = 10;
    Rigidbody rb;
    
    public static int scorePlayer2=0;
    public Text UIScorePlayer1;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (scorePlayer2<0)
        {
            scorePlayer2 = 0;
        }

        UIScorePlayer1.text = "Score Player1: " + scorePlayer2.ToString();
    }

    private void FixedUpdate()
    {
        MovePlayer2();
        TurnPlayer2();
        FallPlayer1();
    }

    void FallPlayer1()
    {
        rb.AddForce(Vector3.down * gravityMultiplier * AmpliadorNumeros);
    }

    void MovePlayer2()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * SpeedPlayer2 * AmpliadorNumeros);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * -SpeedPlayer2 * AmpliadorNumeros);
        }
        Vector3 LocalVelocity = transform.InverseTransformDirection(rb.velocity);
        LocalVelocity.x = 0;
        rb.velocity = transform.TransformDirection(LocalVelocity);
    }

    void TurnPlayer2()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(Vector3.up * TurnSpeed * AmpliadorNumeros);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddTorque(-Vector3.up * TurnSpeed * AmpliadorNumeros);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arco"))
        {
            scorePlayer2 = scorePlayer2 + 1;
            Debug.Log(scorePlayer2);
            Destroy(other.gameObject);
            PlayerInput.cantidadArcos -= 1;
        }

        if (other.CompareTag("AumentoVelocidad"))
        {
            Debug.Log("Hola");
            StartCoroutine("PowerUpVelocidad");
            Debug.Log(SpeedPlayer2);
        }
    }

    IEnumerator PowerUpVelocidad()
    {
        SpeedPlayer2 = SpeedPlayer2 + 1f;
        yield return new WaitForSecondsRealtime(1f);
        SpeedPlayer2 -= SpeedPlayer2 - 1f;

    }



}
