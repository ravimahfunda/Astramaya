using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatAgent : MonoBehaviour
{

    private static CombatAgent _instance;

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

    public GameObject encounterScreen;
    public GameObject mainCamera;
    public GameObject player;

    public void OnBattleStart()
    {
        encounterScreen.SetActive(true);
        mainCamera.SetActive(false);
        player.SetActive(false);
    }

    public void OnBattleDone() {
        encounterScreen.SetActive(false);
        mainCamera.SetActive(true);
        player.SetActive(true);
    }
}
