using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ebac.Core.Singleton;

namespace Itens
{
    public enum ItemType
    {
        COIN,
        LIFE_PACK
    }

    public class ItemManager : Singleton<ItemManager>
    {
        public List<ItemSetup> itemSetups;

        private void Start()
        {
            Reset();
            LoadItensFromSave();

            //EnemiesManager.Instance.OnAllEnemiesDead += EnemiesDeadCallback;
        }

        public void LoadItensFromSave()
        {
            //AddByType(ItemType.COIN, (int) SaveManager.Instance.Setup.coins);
            //AddByType(ItemType.LIFE_PACK, (int) SaveManager.Instance.Setup.health);
        }

        private void Reset()
        {
            foreach (var i in itemSetups)
            {
                i.soInt.value = 0;
            }
        }

        public ItemSetup GetItemByType(ItemType itemType)
        {
            return itemSetups.Find(i => i.ItemType == itemType);
        }

        public void AddByType(ItemType itemType, int amount = 1)
        {
            if (amount < 0) return;
            itemSetups.Find(i => i.ItemType == itemType).soInt.value += amount;
        }

        public void RemoveByType(ItemType itemType, int amount = 1)
        {
            var item = itemSetups.Find(i => i.ItemType == itemType);
            item.soInt.value -= amount;

            if (item.soInt.value < 0) item.soInt.value = 0;
        }

        [NaughtyAttributes.Button]
        private void AddCoin()
        {
            AddByType(ItemType.COIN);
        }

        [NaughtyAttributes.Button]
        private void AddLifePack()
        {
            AddByType(ItemType.LIFE_PACK);
        }

        //public void EnemiesDeadCallback()
        //{
        //    Debug.Log("All Enemies Dead");
        //}
    }

    [System.Serializable]
    public class ItemSetup
    {
        public ItemType ItemType;
        public SOInt soInt;
        public Sprite icon;
    }
}