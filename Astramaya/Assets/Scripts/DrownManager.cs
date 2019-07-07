using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrownManager : MonoBehaviour
{
    public Damagable playerDamagable;

    // Start is called before the first frame update
    void Start()
    {
        playerDamagable = GameObject.FindGameObjectWithTag("Player").GetComponent<Damagable>();
        StartCoroutine(Drowing());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Drowing() {
        yield return new WaitForSeconds(5f);
        Debug.Log("Uhuk");
        playerDamagable.TakeDamage(gameObject);
        StartCoroutine(Drowing());
    }
}
