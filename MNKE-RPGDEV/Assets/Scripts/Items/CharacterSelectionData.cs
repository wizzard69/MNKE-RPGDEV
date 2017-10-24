using UnityEngine;

[CreateAssetMenu(fileName = "Character Selection Data", menuName = "RPG/Items/Charcter Selection Data")]
public class CharacterSelectionData : ScriptableObject
{
    public GameController.CharClass charClass;
    public Item CharacterOutfit;
    public Equipment Shield;
    public Equipment Sword;
    public Equipment Bow;
    public Equipment Arrow;
    public Equipment Staff;
    public Item WizardHat;
}
