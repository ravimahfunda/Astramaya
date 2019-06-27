using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class LegacyManager : MonoBehaviour
{

    private void Start()
    {

    }

    public void UnlockLevel(int level)
    {
        PlayerPrefs.SetInt("LevelUnlocked",level);
    }

    public int GetLevel()
    {
        return PlayerPrefs.GetInt("LevelUnlocked", 3);
    }

    public void UnlockCharacter(int level)
    {
        PlayerPrefs.SetInt("CharacterUnlocked", level);
    }

    public int GetCharacter()
    {
        return PlayerPrefs.GetInt("CharacterUnlocked", 2);
    }

    public void CollectArca(int index) {
        StringBuilder builder = new StringBuilder(PlayerPrefs.GetString("ArcaCollected", "111000"));
        builder.Remove(index, 1);
        builder.Insert(index, "1");

        PlayerPrefs.SetString("ArcaCollected",builder.ToString());
    }

    public bool CheckArcaCollected(int index)
    {
        return PlayerPrefs.GetString("ArcaCollected","010000")[index].Equals("1");
    }

    /**
     * ======================
     * SETTINGS
     * ======================
     **/
    public void SetSFXVolume(float volume) {
        PlayerPrefs.SetFloat("SfxVolume", volume);
    }

    public float GetSFXVolume()
    {
        return PlayerPrefs.GetFloat("SfxVolume", 1);
    }

    public void SetBGMVolume(float volume)
    {
        PlayerPrefs.SetFloat("BgmVolume", volume);
    }

    public float GetBGMVolume()
    {
        return PlayerPrefs.GetFloat("BgmVolume", 1);
    }

    /**
     * ======================
     * GAMEPLAY AND UPGRADE
     * ======================
     **/
    public int SetMaxArrow(int count)
    {
        PlayerPrefs.SetInt("MaxArrow", count);
        return count;
    }

    public int GetMaxArrow()
    {
        return PlayerPrefs.GetInt("MaxArrow", 10);
    }

    public int SetDamage(int amount)
    {
        PlayerPrefs.SetInt("Damage", amount);
        return amount;
    }

    public int GetDamage()
    {
        return PlayerPrefs.GetInt("Damage", 1);
    }

    public float SetAttackSpeed(float amount)
    {
        PlayerPrefs.SetFloat("AttackSpeed", amount);
        return amount;
    }

    public float GetAttackSpeed()
    {
        return PlayerPrefs.GetFloat("AttackSpeed", 1f);
    }

    public int SetMaxHealth(int amount)
    {
        PlayerPrefs.SetInt("MaxHealth", amount);
        return amount;
    }

    public int GetMaxHealth()
    {
        return PlayerPrefs.GetInt("MaxHealth", 10);
    }

    public int SetPotion(int amount)
    {
        PlayerPrefs.SetInt("Potion", amount);
        return amount;
    }

    public int GetPotion()
    {
        return PlayerPrefs.GetInt("Potion", 0);
    }

    public int SetCoin(int amount)
    {
        PlayerPrefs.SetInt("Coin", amount);
        return amount;
    }

    public int GetCoin()
    {
        return PlayerPrefs.GetInt("Coin", 0);
    }

    public void ResetData() {
        PlayerPrefs.DeleteAll();
    }
}
