using UnityEngine;

public class WizardHatPanelSlot : MonoBehaviour
{
    Item wizardPanelEquipment;

    public void UpdateHat(Item equipment)
    {
        wizardPanelEquipment = equipment;
    }

    public void PressButton()
    {
        if (wizardPanelEquipment != null)
        {
            WizardSelection.instance.UpdateHat(wizardPanelEquipment);
        }
    }
}
