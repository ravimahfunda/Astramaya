using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogTrigger : MonoBehaviour
{
    private DialogManager dialogManager;
    public DialogObject dialog;
    public bool autoInteract;
    public bool useLimit;
    public int interactLimit;

    public UnityEvent onComplete;
    public bool isArca;
    public int arcaIndex;


    // Start is called before the first frame update
    void Start()
    {
        dialogManager = GameObject.FindGameObjectWithTag("DialogPanel").GetComponent<DialogManager>();

        if (isArca) {
            if (new LegacyManager().CheckArcaCollected(arcaIndex)) {
                Destroy(this.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && (!useLimit || interactLimit > 0)) {
            dialogManager.ShowInteract(dialog.charaters, dialog.sequence, autoInteract);
            if (useLimit) interactLimit--;
            if (interactLimit <= 0) Destroy(this.gameObject);
            onComplete.Invoke();
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
