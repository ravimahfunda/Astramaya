using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class LegacyManager : MonoBehaviour
{

    public void UnlockLevel(int level)
    {
        PlayerPrefs.SetInt("LevelUnlocked",level);
    }

    public int GetLevel()
    {
        return PlayerPrefs.GetInt("LevelUnlocked", 1);
    }

    public void UnlockCharacter(int level)
    {
        PlayerPrefs.SetInt("CharacterUnlocked", level);
    }

    public int GetCharacter()
    {
        return PlayerPrefs.GetInt("CharacterUnlocked", 1);
    }

    public void CollectArca(int index) {

        string prev = PlayerPrefs.GetString("ArcaCollected", "100000");
        StringBuilder builder = new StringBuilder(prev);

        builder.Remove(index, 1);
        builder.Insert(index, '1');

        string after = builder.ToString();
        PlayerPrefs.SetString("ArcaCollected", after);
    }

    public bool CheckArcaCollected(int index)
    {
        string arcas = PlayerPrefs.GetString("ArcaCollected", "100000");
        return arcas[index] == '1';
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
        return PlayerPrefs.GetInt("MaxArrow", 5);
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
        return PlayerPrefs.GetFloat("AttackSpeed", 0.6f);
    }

    public int SetMaxHealth(int amount)
    {
        PlayerPrefs.SetInt("MaxHealth", amount);
        return amount;
    }

    public int GetMaxHealth()
    {
        return PlayerPrefs.GetInt("MaxHealth", 100);
    }

    public float SetCurrentHealth(float amount)
    {
        PlayerPrefs.SetFloat("CurrentHealth", amount);
        return amount;
    }

    public float GetCurrentHealth()
    {
        return PlayerPrefs.GetFloat("CurrentHealth", GetMaxHealth());
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

    /**
     * ======================
     * COMBAT
     * ======================
     **/
    public int SetDifficulty(int count)
    {
        PlayerPrefs.SetInt("Difficulty", count);
        return count;
    }

    public int GetDifficulty()
    {
        return PlayerPrefs.GetInt("Difficulty", 1);
    }
}
