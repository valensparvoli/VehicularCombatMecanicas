using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{

    public static int cantidadArcos = 11;
    private void Update()
    {
        if (cantidadArcos == 0)
        {
            if (PlayerInputP2.scorePlayer2 > PlayerInputP1.scorePlayer1)
            {
                Debug.Log("Feliciaciones, gano el player 1, player 2 perdiste");

            }
            else if (PlayerInputP1.scorePlayer1>PlayerInputP2.scorePlayer2)
            {
                Debug.Log("Felicitaciones, gano el player 2, player 1 perdiste");
            }
        }

    }

}
