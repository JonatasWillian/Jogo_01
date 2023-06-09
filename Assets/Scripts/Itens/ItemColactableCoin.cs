using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Itens;

public class ItemColactableCoin : ItemColactableBase
{
    public Collider2D collider2D;

    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddByType(ItemType.COIN);
        collider2D.enabled = false;
    }
}
