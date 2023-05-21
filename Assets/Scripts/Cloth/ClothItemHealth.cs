using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cloth
{
    public class ClothItemHealth : ClothItemBase
    {
        public float health = 20f;

        public override void Collect()
        {
            base.Collect();
            Player.Instance.healthBase.ChangeHealth(health, duration);
        }
    }
}
