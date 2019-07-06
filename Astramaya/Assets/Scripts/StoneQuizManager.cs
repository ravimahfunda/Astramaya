using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoneQuizManager : MonoBehaviour
{
    public string[] correctAnswers;

    public Text answer;
    public Text title;

    // Start is called before the first frame update
    void Start()
    {
        title.text = MinigameManager.Instance.minigameTitle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click(string s) {
        answer.text += s;

        if (answer.text.Length >= correctAnswers[MinigameManager.Instance.minigameIndex].Length) {
            Debug.Log(answer.text);
            Debug.Log(correctAnswers[MinigameManager.Instance.minigameIndex]);
            if (answer.text.Equals(correctAnswers[MinigameManager.Instance.minigameIndex]))
            {
                Debug.Log("Is Correct");
                SequenceDoor.Instance.Completing();
                SceneManager.UnloadScene("Stone Quiz");
            }
            else {
                answer.text = "";
            }
        }
    }
}
