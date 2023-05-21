using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy; //adicionado para pegar o BossWalkAtPlayer

namespace Boss
{
    public class BossTrigger : MonoBehaviour
    {
        public BossWalkAtPlayer bossToActive;

        private void OnTriggerEnter(Collider other)
        {
            Player p = other.GetComponent<Player>();
            if (p != null)
            {
                bossToActive.gameObject.SetActive(true);
                //bossToActive.SwitchState(BossAction.WALK);
                gameObject.SetActive(false);
            }
        }
    }
}