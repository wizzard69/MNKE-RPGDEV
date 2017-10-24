using UnityEngine;

public class RangerOutfitPanelSlot : MonoBehaviour
{
    Item rangerPanelEquipment;

    public void UpdateSlot(Item item)
    {
        rangerPanelEquipment = item;
    }

    public void PressButton()
    {
        if (rangerPanelEquipment != null)
        {
            RangerSelection.instance.UpdateOutfit(rangerPanelEquipment);            
        }        
    }
}
