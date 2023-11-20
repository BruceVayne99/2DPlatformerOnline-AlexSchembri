using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUpDown : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float height = 4f;
    [SerializeField] float startY = -2f;

    void Update()
    {
        var pos = transform.position;
        var newY = startY + height * Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(pos.x, newY, pos.z);
    }
}
