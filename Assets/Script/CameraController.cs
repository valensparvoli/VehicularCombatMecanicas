using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    internal enum updateMethod
    {
        fixedUpdate,
        update,
        lateUpdate
    }

    [SerializeField] private updateMethod updateDemo;


    public GameObject cameraLookObject;
    private PlayerInput controllerReference;
    [Range(0, 20)] public float smothTime = 5;


    private void Start()
    {
        controllerReference = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        cameraLookObject = GameObject.FindGameObjectWithTag("Player").transform.Find("camera lookAt").gameObject;
    }

    private void FixedUpdate()
    {
        if (updateDemo == updateMethod.fixedUpdate)
        {
            cameraBehaviour();
            
        }
    }



    private void cameraBehaviour()
    {
        Vector3 velocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, cameraLookObject.transform.position, ref velocity, smothTime * Time.deltaTime);
        transform.LookAt(cameraLookObject.transform);
    }

}
