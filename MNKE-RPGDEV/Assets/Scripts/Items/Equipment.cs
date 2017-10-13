using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType { Shield, Sword, Bow, Arrow, Staff, WizardHat }

[CreateAssetMenu(fileName = "New Equipment", menuName = "Items/Equipment")]
public class Equipment : Item {

    public int armorModifier;
    public int damageModifier;
    public SkinnedMeshRenderer prefab;

}
