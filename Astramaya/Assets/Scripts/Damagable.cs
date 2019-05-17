using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Damagable : MonoBehaviour
{
    public Slider healthBar;

    public List<string> damagerTags;

    public UnityEvent onDie;

    public float maxHealth;
    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (damagerTags.Contains(collision.gameObject.tag))
        {
            Damager damager = collision.gameObject.GetComponent<Damager>();
            if (damager != null)
            {
                TakeDamage(damager.damage);
            }
        }
    }

    public void TakeDamage(float amount) {
        currentHealth -= amount;

        if (healthBar != null) {
            healthBar.value = currentHealth / maxHealth;
        }

        onDie.Invoke();
    }
}
