using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SequenceDoor : MonoBehaviour
{
    public int progress = -1;
    public int toBeCompleted;
    public UnityEvent[] onCompleted;

    private static SequenceDoor _instance;

    public static SequenceDoor Instance { get { return _instance; } }

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

    public void Completing() {
        progress++;
        onCompleted[progress].Invoke();
    }
}
