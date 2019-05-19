using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private CollectionHost host;
    public string key;

    private void Start()
    {
        host = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<CollectionHost>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player")) {
            host.collected(key);
            Destroy(gameObject);
        }
    }
}
