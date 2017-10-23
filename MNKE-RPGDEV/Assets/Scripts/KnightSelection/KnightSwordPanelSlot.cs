using UnityEngine;

public class KnightSwordPanelSlot : MonoBehaviour
{
    Equipment KnightPanelEquipment;

    public void UpdateSword(Equipment equipment)
    {
        KnightPanelEquipment = equipment;
    }

    public void PressButton()
    {
        if (KnightPanelEquipment != null)
        {
            KnightSelection.instance.UpdateSword(KnightPanelEquipment);
        }
    }
}
