using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName ="RPG/Items/Item")]
public class Item : ScriptableObject {

    public GameObject prefab;
    public string itemName;
    public Sprite icon;
}
