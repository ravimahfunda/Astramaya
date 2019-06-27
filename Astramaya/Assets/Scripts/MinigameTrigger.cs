using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MinigameTrigger : MonoBehaviour
{

    public string minigameScene;
    
    public UnityEvent onComplete;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(minigameScene, LoadSceneMode.Additive);
        onComplete.Invoke();
    }
}
