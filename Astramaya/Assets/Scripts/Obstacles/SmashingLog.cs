using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashingLog : MonoBehaviour
{

    private bool isShrinking;
    
    public bool isFlipped;
    public float speed;
    public float maxScale;
    public float minScale;

    // Start is called before the first frame update
    void Start()
    {
        isShrinking = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float newPosition = transform.localScale.x;

        if (newPosition >= minScale )
        {
            newPosition = minScale;
            isShrinking = false;
        }
        else if(newPosition <= maxScale)
        {
            newPosition = maxScale;
            isShrinking = true;
        }

        if (isShrinking)
        {
            newPosition += Time.deltaTime * speed;
        }
        else {
            newPosition -= Time.deltaTime * speed;
        }

        transform.localScale = new Vector3(newPosition, transform.localScale.y, transform.localScale.z);
    }
}
