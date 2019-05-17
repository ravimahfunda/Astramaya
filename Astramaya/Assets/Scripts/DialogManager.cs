using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogText;
    public Image artwork;

    public Animator controlAnimator;

    private Animator animator;

    private List<string> dialogs;
    private List<CharacterObject> characters;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowInteract(List<CharacterObject> characters, List<string> dialogs, bool autoInteract)
    {
        nameText.text = name;

        this.dialogs = dialogs;
        this.characters = characters;

        index = 0;
        nameText.text = this.characters[0].name;
        artwork.sprite = this.characters[0].artwork;
        dialogText.text = this.dialogs[index];

        if (autoInteract) {
            controlAnimator.SetBool("Show", false);
            animator.SetBool("Show", true);
        }
        else
            animator.SetBool("Interact", true);
    }

    public void HideInteract()
    {
        animator.SetBool("Interact", false);
    }

    public void Next()
    {
        index++;

        if (index >= dialogs.Count) {
            HideDialog();
        }
        else
        {
            if (dialogs[index].Substring(0, 1) == "#")
            {
                int indexChar = int.Parse(dialogs[index].Substring(1, 1));
                nameText.text = characters[indexChar % characters.Count].name;
                artwork.sprite = characters[indexChar % characters.Count].artwork;
                Next();
            }
            else
            {
                dialogText.text = dialogs[index];
            }
        }
    }

    public void ShowDialog()
    {
        controlAnimator.SetBool("Show", false);

        animator.SetBool("Interact", false);
        animator.SetBool("Show", true);
    }

    public void HideDialog()
    {
        animator.SetBool("Show", false);
        controlAnimator.SetBool("Show", true);
    }
}
