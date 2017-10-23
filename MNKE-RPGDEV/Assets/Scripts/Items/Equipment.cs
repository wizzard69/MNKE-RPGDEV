using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType { Shield, Sword, Bow, Arrow, Staff, WizardHat }

[CreateAssetMenu(fileName = "New Equipment", menuName = "Items/Equipment")]
public class Equipment : Item {

    public EquipmentType equipmentType;
    public bool isProjectile;
    public int armorModifier;
    public int damageModifier;    
    public SkinnedMeshRenderer meshPrefab;
    public GameObject prefabObject;   
}
