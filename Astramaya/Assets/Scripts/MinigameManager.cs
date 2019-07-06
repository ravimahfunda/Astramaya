using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    private static MinigameManager _instance;

    public static MinigameManager Instance { get { return _instance; } }
    public int minigameIndex;
    public string minigameTitle;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetIndex(int index) {
        minigameIndex = index;
    }

    public void SetTitle(string title)
    {
        minigameTitle = title;
    }
}
