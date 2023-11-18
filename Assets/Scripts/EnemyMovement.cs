using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Speed = 10;
    public bool IsMovingRight = true;
    public float leftBoundry;
    public float rightBoundry;

    private void Start()
    {
        leftBoundry = transform.position.x + leftBoundry;
        rightBoundry = transform.position.x + rightBoundry;
    }

    void Update()
    {
        if (IsMovingRight)
        {
            transform.position += new Vector3(Speed, 0, 0) * Time.deltaTime;
        }

        else
        {
            transform.position -= new Vector3(Speed, 0, 0) * Time.deltaTime;
        }

        if (transform.position.x >= rightBoundry)
        {
            IsMovingRight = false;
        }

        if (transform.position.x <= leftBoundry)
        {
            IsMovingRight = true;
        }

    }
}
