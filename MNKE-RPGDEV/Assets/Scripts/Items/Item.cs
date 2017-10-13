using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName ="Items/Item")]
public class Item : ScriptableObject {

    public string itemName;
    public Sprite icon;
}
