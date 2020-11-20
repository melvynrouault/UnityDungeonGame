﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemyController : MonoBehaviour {

    public Transform player;
    public float playerDistance;
    public float awareAI = 10f;
    public float AIMoveSpeed;

    public Transform[] navPoint;
    public UnityEngine.AI.NavMeshAgent agent;
    public int destPoint = 0;
    public Transform goal;

    void Start () {
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;
        agent.autoBraking = false;
    }

    void Update ()
    {
        playerDistance = Vector3.Distance(player.position, transform.position);
        if (playerDistance < awareAI)
        {
            LookAtPlayer();
        }

        if (playerDistance < awareAI)
        {
            if (playerDistance < 2f)
                Chase();
            else
                GotoNextPoint();		
        }

        if (agent.remainingDistance < 0.5f)
            GotoNextPoint();	
    }

    void LookAtPlayer()
    {
        transform.LookAt(player);	
    }

    void GotoNextPoint()
    {
        if (navPoint.Length == 0) return;       
        agent.destination = navPoint[destPoint].position;
        destPoint = (destPoint + 1) % navPoint.Length;
    }

    void Chase ()
    {
        transform.Translate(Vector3.forward * (AIMoveSpeed * Time.deltaTime));
    }
}