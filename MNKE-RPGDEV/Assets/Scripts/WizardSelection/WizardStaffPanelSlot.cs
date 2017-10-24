using UnityEngine;

public class WizardStaffPanelSlot : MonoBehaviour {

    Equipment wizardStaffPanelSlot;

    public void UpdateStaff(Equipment equipment)
    {
        wizardStaffPanelSlot = equipment;
    }

    public void PressButton()
    {
        if (wizardStaffPanelSlot != null)
        {
            WizardSelection.instance.UpdateStaff(wizardStaffPanelSlot);
        }
    }
}
