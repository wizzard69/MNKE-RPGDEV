using UnityEngine;

public class WizardOutfitPanelSlot : MonoBehaviour
{
    Item wizardPanelEquipment;

    public void UpdateSlot(Item item)
    {
        wizardPanelEquipment = item;
    }

    public void PressButton()
    {
        if (wizardPanelEquipment != null)
        {
            WizardSelection.instance.UpdateOutfit(wizardPanelEquipment);            
        }        
    }
}
