using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Itens
{
    public class ItemLayoutManager : MonoBehaviour
    {
        //public ItemLayout prefabLayout;
        //public Transform container;

        public List<ItemLayout> itemLayouts;

        public ItemLayout coinLayout;
        public ItemLayout lifeLayout;

        private void Start()
        {
            //CreateItens();

            coinLayout.Load(ItemManager.Instance.GetItemByType(ItemType.COIN));
            lifeLayout.Load(ItemManager.Instance.GetItemByType(ItemType.LIFE_PACK));
        }

        private void CreateItens()
        {
            /*foreach (var setup in ItemManager.Instance.itemSetups)
            {
                var item = Instantiate(prefabLayout, container);
                item.Load(setup);
                itemLayouts.Add(item);
            }*/
        }
    }
}