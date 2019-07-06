using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectionHost : MonoBehaviour
{
    [SerializeField]
    public List<CollectionKey> collections;

    private List<string> keyMap;


    // Start is called before the first frame update
    void Start()
    {
        keyMap = new List<string>();
        foreach (CollectionKey c in collections) {
            keyMap.Add(c.key);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void collected(string key) {
        int index = keyMap.IndexOf(key);
        collections[index].currentCount++;
        collections[index].onCollect.Invoke();

        if (collections[index].currentCount >= collections[index].wantedCount) {
            collections[index].onAllCollected.Invoke();
        }
    }


}

[Serializable]
public class CollectionKey {
    public string key;
    public int wantedCount;
    public int currentCount;
    public UnityEvent onAllCollected;
    public UnityEvent onCollect;
}
