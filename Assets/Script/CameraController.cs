using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float Smoothing;
    public float RotationSmoothing;
    public Transform player;
    
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, Smoothing);
        transform.rotation = Quaternion.Slerp(transform.rotation, player.rotation, Smoothing);
        transform.rotation = Quaternion.Euler(new Vector3(0,transform.rotation.eulerAngles.y,0));
    }
}
