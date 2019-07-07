using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaUdara : MonoBehaviour
{
    private bool isHealing = false;
    Damagable dmg;

    void Start()
    {
        dmg = GameObject.FindGameObjectWithTag("Player").GetComponent<Damagable>();
        StartCoroutine(GiveOxygen());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player")) {
            isHealing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            isHealing = false;
        }
    }

    IEnumerator GiveOxygen() {
        yield return new WaitForSeconds(2f);
        if (isHealing) {
            dmg.Heal(10);
            Debug.Log("Uhuk");
        }
        StartCoroutine(GiveOxygen());
    }
}
