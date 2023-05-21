using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Cloth
{
    public class ClothItemBase : MonoBehaviour
    {
        public ClothType clothType;
        public float duration = 2f;

        public string compareTag = "Player";

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.transform.CompareTag(compareTag))
            {
                Collect();
            }
        }

        public virtual void Collect()
        {
            var setup = ClothManager.Instance.GetSetupByType(clothType);
            if (setup != null)
            {
                Player.Instance.ChangeTexture(setup);
                SaveManager.Instance.SaveEquippedCloth(clothType);
                HideObject();
            }
            else
            {

            }
        }

        private void HideObject()
        {
            gameObject.SetActive(false);
        }
    }
}