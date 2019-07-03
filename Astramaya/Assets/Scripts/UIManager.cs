using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject encounterScreen;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Encounter() {
        CombatAgent.Instance.player.SetActive(false);
        CombatAgent.Instance.encounterScreen.SetActive(true);
        encounterScreen.GetComponent<Animator>().SetTrigger("Encounter");
        //mainCamera.SetActive(false);
    }
}
