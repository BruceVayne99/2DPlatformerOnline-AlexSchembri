using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    public TMP_Text HealthText;
    [SerializeField]
    public float _health = 100f;
    [SerializeField]
    public float _maxHealth = 100f;
    private SpriteRenderer _sprite;
    private PlayerManager _playerManager;
    [SerializeField]
    private ParticleSystem _hitParticlePrefab;

    void Start()
    {
        DisplayHealth();
        _sprite = GetComponent<SpriteRenderer>();
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

    void PlayHitParticle()
    {
        if (_hitParticlePrefab != null)
        {
            Vector3 spawnPosition = transform.position;
            spawnPosition.z = -5;
            Instantiate(_hitParticlePrefab, transform.position, Quaternion.identity);
        }
    }

    IEnumerator FlashRed()
    {
        if (_sprite != null)
        {
            _sprite.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            _sprite.color = Color.white;
        }

    }

    void DisplayHealth()
    {
        if (HealthText != null)
        {
            HealthText.text = _health.ToString();
        }
    }

    public void Damage(int damage)
    {
        StartCoroutine(FlashRed());
        PlayHitParticle();

        _health -= damage;

        if (_health <= 0)
        {
            OnDeath();
        }
        DisplayHealth();
    }

    public void Heal(int healthRestore)
    {
        _health += healthRestore;
        DisplayHealth();
    }
}
