using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private LegacyManager lm;
    public List<Button> levelButtons;
    // Start is called before the first frame update
    void Start()
    {
        lm = new LegacyManager();
        int unlockedLevel = lm.GetLevel();
        for (int i = unlockedLevel; i>0; i--) {
            levelButtons[i - 1].interactable = true;
        }
    }
}
