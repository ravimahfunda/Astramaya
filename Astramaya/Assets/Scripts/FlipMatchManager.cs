using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlipMatchManager : MonoBehaviour
{
    public List<Sprite> artworks;
    public List<GameObject> buttons;

    public int level;
    private int matched;

    private int firstSelected;
    private int firstPosition;

    // Start is called before the first frame update
    void Start()
    {
        firstSelected = -1;
        GenerateLevel(level);
    }

    private void GenerateLevel(int level) {
        List<int> ids = new List<int>();
        for (int i=0;i<16;i++) {
            ids.Add(i);
        }

        for (int i = 0; i<8; i++) {
            int rand = Random.Range(0, ids.Count-1);
            buttons[ids[rand]].GetComponent<FlipButton>().core.sprite = artworks[i];
            buttons[ids[rand]].GetComponent<FlipButton>().index = i;
            Debug.Log("Position: " + ids[rand] + " | Index: " + i);
            ids.RemoveAt(rand);
            

            rand = Random.Range(0, ids.Count);
            buttons[ids[rand]].GetComponent<FlipButton>().core.sprite = artworks[i];
            buttons[ids[rand]].GetComponent<FlipButton>().index = i;
            Debug.Log("Position: " + ids[rand] + " | Index: " + i);
            ids.RemoveAt(rand);
        }
    }

    public void CardSelect(int index, int position) {
        Debug.Log("Index: "+index);
        if (firstSelected == -1)
        {
            firstSelected = index;
            firstPosition = position;
        }
        else
        {
            if (firstSelected == index)
            {
                matched++;

                StartCoroutine(Correct(position));
            }
            else
            {
                StartCoroutine(Wrong(position));
            }
            firstSelected = -1;
        }
    }

    IEnumerator Correct(int position) {
        yield return new WaitForSeconds(.7f);
        buttons[firstPosition].SetActive(false);
        buttons[position].SetActive(false);
        if (matched >= level * level / 2)
        {
            SceneManager.UnloadSceneAsync("FlipMatch");
        }
    }

    IEnumerator Wrong(int position)
    {
        yield return new WaitForSeconds(.7f);
        buttons[firstPosition].GetComponent<FlipButton>().CardClose();
        buttons[position].GetComponent<FlipButton>().CardClose();
    }
}
