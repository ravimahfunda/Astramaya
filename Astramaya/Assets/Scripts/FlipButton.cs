using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlipButton : MonoBehaviour
{
    public Image core;

    public int index;
    public int position;

    private Animator anim;
    private FlipMatchManager manager;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        manager = GameObject.FindGameObjectWithTag("Minigame Manager").GetComponent<FlipMatchManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CardClick() {
        if (manager.allowToPick) {
            anim.SetBool("IsOpen", true);
            manager.CardSelect(index, position);
        }
    }

    public void CardClose()
    {
        anim.SetBool("IsOpen", false);
    }
}
