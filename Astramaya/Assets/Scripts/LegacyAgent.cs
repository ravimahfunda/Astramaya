using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LegacyAgent : MonoBehaviour
{
    public GameObject player;
    public Text potionText;

    private Damagable playerHealth;
    private PlayerBehaviours playerBehave;
    private int potionCount;

    private LegacyManager lm;

    // Start is called before the first frame update
    void Start()
    {
        lm = new LegacyManager();
        potionCount = lm.GetPotion();
        playerHealth = player.GetComponent<Damagable>();
        playerBehave = player.GetComponent<PlayerBehaviours>();


        if(potionText != null)
            potionText.text = "X " + potionCount;

        if (player == null) return;
        Debug.LogWarning("Olo");
        playerHealth.maxHealth = lm.GetMaxHealth();
        playerHealth.SetHealth(lm.GetCurrentHealth());

        playerBehave.attackDelay = lm.GetAttackSpeed();
        playerBehave.maxArrowAmmo= lm.GetMaxArrow();
        playerBehave.ammoBar.maxValue = lm.GetMaxArrow();
        playerBehave.ammoBar.value= lm.GetMaxArrow();
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
