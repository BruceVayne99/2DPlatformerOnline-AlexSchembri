using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthRestore = 20;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health _health = collision.GetComponent<Health>();

        if(_health)
        {
            _health.Heal(healthRestore);
            Destroy(gameObject);
        }
    }
}
