using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LegacyAgent : MonoBehaviour
{
    public Damagable playerHealth;

    public Text potionText;
    private int potionCount;

    private LegacyManager lm;

    // Start is called before the first frame update
    void Start()
    {
        lm = new LegacyManager();
        potionCount = lm.GetPotion();

        potionText.text = "X " + potionCount;

        int maxHealth = lm.GetMaxHealth();
        playerHealth.maxHealth = maxHealth;
        playerHealth.currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Heal() {
        if (potionCount > 0 && playerHealth.currentHealth < playerHealth.maxHealth) {
            playerHealth.Heal(10);
            potionCount -= 1;
            lm.SetPotion(potionCount);
            potionText.text = "X "+ potionCount;
        }
    }
}
