using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{
    private NavMeshAgent inimigo;
    private Transform point;

    public string player = "Player";

    void Start()
    {
        inimigo = GetComponent<NavMeshAgent>();
        point = GameObject.Find(player).transform;
    }

    void Update()
    {
        inimigo.SetDestination(point.position);
    }
}
