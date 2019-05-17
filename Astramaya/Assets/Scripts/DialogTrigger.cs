using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    private DialogManager dialogManager;
    public DialogObject dialog;
    public bool autoInteract;

    // Start is called before the first frame update
    void Start()
    {
        dialogManager = GameObject.FindGameObjectWithTag("DialogPanel").GetComponent<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player")) {
            dialogManager.ShowInteract(dialog.charaters, dialog.sequence, autoInteract);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            dialogManager.HideInteract();
        }
    }
}
