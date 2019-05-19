using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public float leftClamp;
    public float rightClamp;
    public float bottomClamp;
    public float topClamp;

    public void ChangeFocus(Transform target) {
        this.target = target;
    }

    void FixedUpdate()
    {
        Vector3 clampedPosition = new Vector3(
            Mathf.Clamp(target.position.x, leftClamp, rightClamp), 
            Mathf.Clamp(target.position.y, bottomClamp, topClamp), 
            target.position.z);

        Vector3 desiredPosition = clampedPosition + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        //transform.LookAt(target);
    }
}
