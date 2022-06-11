using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    private GameObject[] blocks;
    public LayerMask wallLayer, playerLayer;

    public float speed = 2;

    //Moving
    public Transform[] waypoints;
    private int i = 0;
    public float sightRange = 3;
    public float moveDelay = 2;
    private bool alreadyMoved = false;
    private Vector3 moveDirection, movePoint;
    private bool stop = false;
    private bool validMove = true;

    //Attacking
    public float health = 100;
    public float attackPower = 10;
    public float attackDelay = 10;
    private bool alreadyAttacked = false;
    public float attackRange = 0.2f;

    //State
    public bool PlayerInSightRange;
    public bool PlayerInAttackRange;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //blocks = GameObject.FindGameObjectsWithTag("W");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        PlayerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        if (!PlayerInSightRange && !PlayerInAttackRange)
        {
            Patrol();
        } else if (PlayerInSightRange && !PlayerInAttackRange)
        {
            Patrol();
            //Chase();
        } else if (PlayerInSightRange && PlayerInAttackRange)
        {
            Attack();
        }
    }

    private void Attack()
    {
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            // attack code
            player.GetComponent<HeartSystem>().TakeDamage();

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), attackDelay);

            /*
            alreadyMoved = true;
            stop = true;
            Invoke(nameof(ResetMove), moveDelay);
            */
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void Move(Vector3 dest)
    {
        if (!stop)
        {
            if (validMove)
            {
                transform.position = Vector3.MoveTowards(transform.position, dest, speed * Time.deltaTime);
            }

            if (transform.position == dest)
            {
                stop = true;
                Invoke(nameof(ResetMove), moveDelay);
            }
        }
    }

    private void ResetMove()
    {
        //print("move");
        alreadyMoved = false;
        stop = false;
    }

    private void Chase()
    {
        print("Chasing Player");
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void Patrol()
    {
        if (!alreadyMoved)
        {

            moveDirection = (waypoints[i].transform.position - transform.position).normalized;
            movePoint = moveDirection + transform.position;
            
            transform.LookAt(movePoint);

            validMove = !Physics.Raycast(transform.position, moveDirection, 1.4f, wallLayer);
            //print(movePoint);
            if (validMove)
            {
                alreadyMoved = true;
            }
        }


        Move(movePoint);

        if (transform.position == waypoints[i].transform.position)
        {
            i += 1;
        }

        if (i == waypoints.Length)
        {
            i = 0;
        }
    }
}
