using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyWalkShoot : EnemyWalk
    {
        public GunBase gunBase;

        protected override void Init()
        {
            base.Init();

            gunBase.StartShoot();
        }
    }
}