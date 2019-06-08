using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{
    private LegacyManager lm;

    int maxArrow;
    int arrowDamage;
    float attackSpeed;

    int maxHealth;
    int potion;

    int coin;

    public Text maxArrowText;
    public Text arrowDamageText;
    public Text attackSpeedText;

    public Text maxHealthText;
    public Text potionText;

    public Text coinText;

    public int upCostMaxArrow;
    public int upCostArrowDamage;
    public int upCostAttackSpeed;
    public int upCostMaxHealth;
    public int upCostPotion;

    // Start is called before the first frame update
    void Start()
    {
        lm = new LegacyManager();

        lm.ResetData();

        maxArrow = lm.GetMaxArrow();
        arrowDamage = lm.GetDamage();
        attackSpeed = lm.GetAttackSpeed();

        maxHealth = lm.GetMaxHealth();
        potion = lm.GetPotion();
        lm.SetCoin(3000);
        coin = lm.GetCoin();

        maxArrowText.text = maxArrow.ToString();
        arrowDamageText.text = arrowDamage.ToString();
        attackSpeedText.text = attackSpeed.ToString();
        maxHealthText.text = maxHealth.ToString();
        potionText.text = potion.ToString();
        coinText.text = coin.ToString();
    }

    public void UpMaxArrow() {
        if (coin >= upCostMaxArrow) {
            lm.SetCoin(lm.GetCoin() - upCostMaxArrow);
            coin = lm.GetCoin();
            coinText.text = coin.ToString();

            lm.SetMaxArrow(lm.GetMaxArrow() + 1);
            maxArrowText.text = lm.GetMaxArrow().ToString();
        }
    }

    public void UpArrowDamage()
    {
        if (coin >= upCostArrowDamage)
        {
            lm.SetCoin(lm.GetCoin() - upCostArrowDamage);
            coin = lm.GetCoin();
            coinText.text = coin.ToString();

            lm.SetDamage(lm.GetDamage() + 2);
            arrowDamageText.text = lm.GetDamage().ToString();
        }
    }

    public void UpAttackSpeed()
    {
        if (coin >= upCostAttackSpeed && lm.GetAttackSpeed() > 0.1f)
        {
            lm.SetCoin(lm.GetCoin() - upCostAttackSpeed);
            coin = lm.GetCoin();
            coinText.text = coin.ToString();

            lm.SetAttackSpeed(lm.GetAttackSpeed() - 0.08f);
            attackSpeedText.text = lm.GetAttackSpeed().ToString();
        }
    }

    public void UpMaxHealth()
    {
        if (coin >= upCostMaxHealth)
        {
            lm.SetCoin(lm.GetCoin() - upCostMaxHealth);
            coin = lm.GetCoin();
            coinText.text = coin.ToString();

            lm.SetMaxHealth(lm.GetMaxHealth() + 1);
            maxHealthText.text = lm.GetMaxHealth().ToString();
        }
    }

    public void UpPotion()
    {
        if (coin >= upCostPotion)
        {
            lm.SetCoin(lm.GetCoin() - upCostPotion);
            coin = lm.GetCoin();
            coinText.text = coin.ToString();

            lm.SetPotion(lm.GetPotion() + 1);
            potionText.text = lm.GetPotion().ToString();
        }
    }
}
