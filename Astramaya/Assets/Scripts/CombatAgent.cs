using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatAgent : MonoBehaviour
{

    private static CombatAgent _instance;
    private LegacyManager lm;

    public static CombatAgent Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        lm = new LegacyManager();
    }

    public GameObject encounterScreen;
    public GameObject mainCamera;
    public GameObject player;

    public void OnBattleStart()
    {
        lm.SetCurrentHealth(player.GetComponent<Damagable>().currentHealth);

        encounterScreen.SetActive(true);
        mainCamera.SetActive(false);
        player.SetActive(false);
    }

    public void OnBattleDone() {
        encounterScreen.SetActive(false);
        mainCamera.SetActive(true);
        player.SetActive(true);
        player.GetComponent<Damagable>().SetHealth(lm.GetCurrentHealth());
        Debug.LogWarning(lm.GetCurrentHealth());
    }
}
