using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class BossWalkAtPlayer : EnemyBase
    {
        [Header("Waypointns")]
        public GameObject[] waypoints;
        public float minDistance = 1f;
        public float speed = 1f;

        public GunBase gunBase;

        private int _index = 0;

        protected override void Init()
        {
            base.Init();

            gunBase.StartShoot();
        }

        /*public override void Update()
        {
            base.Update();

            if (Vector3.Distance(transform.position, waypoints[_index].transform.position) < minDistance)
            {
                _index++;
                if (_index >= waypoints.Length)
                {
                    _index = 0;
                }
            }

            transform.position = Vector3.MoveTowards(transform.position, waypoints[_index].transform.position, Time.deltaTime * speed);
        }*/
    }
}
