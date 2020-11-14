using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public Rigidbody2D body2D;
    public float leftAngle;
    public float rightAngle;
    public float moveSpeed;

    bool movingClockwise;
    // Start is called before the first frame update
    void Start()
    {
        movingClockwise = true;
        body2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void ChangeDir()
    {
        if(transform.rotation.z > rightAngle)
        {
            movingClockwise = false;
        }
        if(transform.rotation.z < leftAngle)
        {
            movingClockwise = true;
        }
    }

    public void Move()
    {
        ChangeDir();
        if (movingClockwise)
        {
            body2D.angularVelocity = moveSpeed;
        }
        if (!movingClockwise)
        {
            body2D.angularVelocity = moveSpeed * -1;
        }

    }
}
