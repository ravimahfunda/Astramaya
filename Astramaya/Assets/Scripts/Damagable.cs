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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage(collision.gameObject);
    }

    public void TakeDamage(GameObject collision) {
        
        if (damagerTags.Contains(collision.tag))
        {
            Damager damager = collision.GetComponent<Damager>();
            if (damager != null)
            {

                currentHealth -= damager.damage;

                if (healthBar != null)
                {
                    healthBar.value = currentHealth / maxHealth;
                }
                if(currentHealth <= 0) onDie.Invoke();
            }
        }
    }
}
