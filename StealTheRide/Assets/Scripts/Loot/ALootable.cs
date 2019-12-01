using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LootItem
{
    public float dropChance;
    public GameObject item;
}

abstract public class ALootable : MonoBehaviour
{
    public LootItem[] lootTable;

    public void Drop()
    {
        float r = Random.Range(0, 101);
        foreach (LootItem lootItem in lootTable)
        {
            if (r <= lootItem.dropChance)
            {
                DropLogic(lootItem);
                break;
            }
        }
    }

    private void DropLogic(LootItem lootItem)
    {
        Instantiate(lootItem.item, transform.position, Quaternion.identity);
    }
}
