using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    private Item _template;

    public void AddItem(Weapon weapon)
    {
        Item item;
        item = Instantiate(_template, transform);
        item.Weapon = weapon;
    }
}
