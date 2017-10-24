using UnityEngine;

public class RangerBowPanelSlot : MonoBehaviour {

    Equipment rangerPanelEquipment;

    public void UpdateBow(Equipment equipment)
    {
        rangerPanelEquipment = equipment;
    }

    public void PressButton()
    {
        if (rangerPanelEquipment != null)
        {
            RangerSelection.instance.UpdateBow(rangerPanelEquipment);
        }
    }
}
