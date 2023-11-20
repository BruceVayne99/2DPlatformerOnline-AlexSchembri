using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DeathZone : MonoBehaviour
{
    private PlayerManager _playerManager;

    void Start()
    {
        _playerManager = GetComponent<PlayerManager>();
    }

    void OnDeath()
    {
        if (_playerManager != null)
        {
            _playerManager.ReloadScene();
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        {
            OnDeath();
        }
    }
}