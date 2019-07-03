using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    public Text dialogText;
    public Image artwork;

    public List<string> dialogs;
    public List<Sprite> images;
    private int index = -1;

    public UnityEvent onDone;

    // Start is called before the first frame update
    void Start()
    {
        Next();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Next()
    {
        index++;

        if (index >= dialogs.Count)
        {
            Done();
        }
        else
        {
            if (dialogs[index].Substring(0, 1) == "#")
            {
                int indexArt = int.Parse(dialogs[index].Substring(1, 1));
                artwork.sprite = images[indexArt];
                Next();
            }
            else
            {
                dialogText.text = dialogs[index];
            }
        }
    }

    public void Done() {
        onDone.Invoke();
    }
}
