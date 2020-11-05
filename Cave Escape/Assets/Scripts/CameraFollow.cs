using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;

    [Range(1,10)]
    public float smoothFactor;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {   //store current camera position in variable targetPosition
        Vector3 temp = transform.position;

        //set camera's position y to be the player's position y
        temp.y = playerTransform.position.y;

        //smoothing the camera follow, delay effect
        Vector3 smoothPosition = Vector3.Lerp(transform.position, temp, smoothFactor * Time.fixedDeltaTime);

        //set back the camera position to the smoothed camera position
        transform.position = smoothPosition;
    }
}
