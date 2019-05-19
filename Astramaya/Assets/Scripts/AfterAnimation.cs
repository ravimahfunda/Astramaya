using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AfterAnimation : MonoBehaviour
{
    public UnityEvent complete;

    public void onComplete() {
        complete.Invoke();
    }
}
