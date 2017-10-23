using UnityEngine;

public class KnightOutfitPanelSlot : MonoBehaviour
{
    Item KnightPanelEquipment;

    public void UpdateSlot(Item item)
    {
        KnightPanelEquipment = item;
    }

    public void PressButton()
    {
        if (KnightPanelEquipment != null)
        {
            KnightSelection.instance.UpdateOutfit(KnightPanelEquipment);            
        }        
    }
}
