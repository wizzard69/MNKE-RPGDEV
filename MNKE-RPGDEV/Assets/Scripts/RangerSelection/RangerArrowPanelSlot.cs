using UnityEngine;

public class RangerArrowPanelSlot : MonoBehaviour
{
    Equipment rangerPanelEquipment;

    public void UpdateArrow(Equipment equipment)
    {
        rangerPanelEquipment = equipment;
    }

    public void PressButton()
    {
        if (rangerPanelEquipment != null)
        {
            RangerSelection.instance.UpdateArrow(rangerPanelEquipment);
        }
    }
}
