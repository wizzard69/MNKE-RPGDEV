﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    public void Start()
    {
        base.Start();
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            //armor.AddModifier(newItem.armorModifier);
            //damage.AddModifier(newItem.damageModifier);
        }

        if (oldItem != null)
        {
            //armor.RemoveModifier(oldItem.armorModifier);
            //damage.RemoveModifier(oldItem.armorModifier);
        }
    }

}
