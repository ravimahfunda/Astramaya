using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    public Transform target;
    private DialogManager dialogManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogManager = GameObject.FindGameObjectWithTag("DialogPanel").GetComponent<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.transform.position = target.position;
        }
    }
}
