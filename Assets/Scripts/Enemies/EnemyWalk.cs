using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyWalk : EnemyBase
    {
        //[Header("Waypointns")]
        //public GameObject[] waypoints;
        //public float minDistance = 1f;
        //public float speed = 1f;
        //public float speedDeath = 2f;

        //public Rigidbody rig;

        //private int _index = 0;

        //public override void Awake()
        //{
        //    base.Awake();
        //    rig = GetComponent<Rigidbody>();
        //}

        //public override void Update()
        //{
        //    base.Update();
        //}

        //private void FixedUpdate()
        //{
        //    if (Vector3.Distance(transform.position, waypoints[_index].transform.position) < minDistance)
        //    {
        //        _index++;
        //        if (_index >= waypoints.Length)
        //        {
        //            _index = 0;
        //        }
        //    }

        //    transform.position = Vector3.MoveTowards(transform.position, waypoints[_index].transform.position, Time.deltaTime * speed);

        //    Vector3 direction = (waypoints[_index].transform.position - transform.position).normalized;
        //    rig.MovePosition(transform.position + direction * Time.deltaTime * speed);
        //    transform.LookAt(waypoints[_index].transform.position);
        //}

        //protected override void OnKill()
        //{
        //    speed = speedDeath;
        //    base.OnKill();
        //}
    }
}