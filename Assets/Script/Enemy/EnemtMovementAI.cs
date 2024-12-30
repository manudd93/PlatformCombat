using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemtMovementAI : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    EnemyStateController enemyStateController;
    public Transform PlayerTarget;
    public Transform FountainTarget;
    public float Speed;
    [SerializeField] float Direction;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        enemyStateController = GetComponent<EnemyStateController>();
        PlayerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        FountainTarget = GameObject.FindGameObjectWithTag("Fontana").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Direction = Mathf.Sign(PlayerTarget.transform.position.x - transform.position.x);
        Debug.Log("mi sto muovendo");
        


        rb.velocity = new Vector2(Direction*Speed, rb.velocity.y);
    }
}
