using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag == "Player")
        { 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}