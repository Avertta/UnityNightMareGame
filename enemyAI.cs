using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemyAI : MonoBehaviour
{
    //Primitive AI script for alpha testing.
    NavMeshAgent enemy;
    public float enemySpeed;
    public Transform targetPlayer;
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        enemy.destination = targetPlayer.position * enemySpeed;
    }
}
