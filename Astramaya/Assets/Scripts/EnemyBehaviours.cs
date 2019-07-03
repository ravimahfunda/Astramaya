using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviours : MonoBehaviour
{

    public enum BEHAVIOUR_TYPE {
        PATROL,
        CHASE,
        STILL
    }

    public BEHAVIOUR_TYPE behaviour_type;

    public Transform[] patrolPoints;
    public float delayBetweenPatrol;

    public float speed;
    public float spotRange;

    private Transform player;
    private bool playerInRange;
    private bool isFacingRight;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        isFacingRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerInRange = Vector2.Distance(transform.position, player.position) <= spotRange;

        if (behaviour_type == BEHAVIOUR_TYPE.CHASE || playerInRange) {
            Move();
        }
    }

    void Move() {
        float step = speed * Time.deltaTime;

        if ((player.position.x > transform.position.x && !isFacingRight)||(player.position.x < transform.position.x && isFacingRight))
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            isFacingRight = true;
        }

        transform.position = Vector2.MoveTowards(transform.position, player.position, step);
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = new Color(200,50,50,0.4f);
        Gizmos.DrawSphere(transform.position, spotRange);
    }
}
