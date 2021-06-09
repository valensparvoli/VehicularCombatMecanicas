using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerPlayer2 : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arco"))
        {
            PlayerInputP2.scorePlayer2 += 1;
            Destroy(other.gameObject);
            PlayerInput.cantidadArcos -= 1;
        }

        if (other.CompareTag("AumentoVelocidad"))
        {
            Debug.Log("Hola");
            StartCoroutine("PowerUpVelocidad");
        }
    }
 
    IEnumerator PowerUpVelocidad()
    {
        PlayerInputP2.SpeedPlayer2 = PlayerInputP2.SpeedPlayer2+ 0.5f;
        yield return new WaitForSeconds(1f);
        PlayerInputP2.SpeedPlayer2 -= PlayerInputP2.SpeedPlayer2 - 0.5f;
    }
}
