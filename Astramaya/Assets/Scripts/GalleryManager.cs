using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryManager : MonoBehaviour
{

    LegacyManager lm;

    public Button[] characterButton;
    public Button[] loreButton;

    public CharacterObject[] characters;
    public CharacterObject[] arcas;

    public Image artwork;
    public Text title;
    public Text description;

    // Start is called before the first frame update
    void Start()
    {
        lm = new LegacyManager();

        for (int i = 0; i < lm.GetCharacter(); i++) {
            characterButton[i].interactable = true;
        }

        for (int i = 0; i < 3; i++)
        {
            loreButton[i].interactable = true;
        }
    }

    public void ShowCharacter(int index) {
        artwork.sprite = characters[index].artwork;
        title.text = characters[index].name;
        description.text = characters[index].description;
    }

    public void ShowLore(int index)
    {
        artwork.sprite = arcas[index].artwork;
        title.text = arcas[index].name;
        description.text = arcas[index].description;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
