using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Arco"))
        {
            PlayerInputP1.scorePlayer1 += 1;
            Destroy(collision.gameObject);
            PlayerInput.cantidadArcos -= 1;
        }

        if (collision.collider.CompareTag("AumentoVelocidad"))
        {
            StartCoroutine("PowerUpVelocidad");
        }
    }

    IEnumerator PowerUpVelocidad()
    {
        PlayerInputP1.SpeedPlayer1 += 0.5f;
        yield return new WaitForSeconds(1f);
        PlayerInputP1.SpeedPlayer1 -= 0.5f;
    }
}
