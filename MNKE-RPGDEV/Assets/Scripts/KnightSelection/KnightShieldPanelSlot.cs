using UnityEngine;

public class KnightShieldPanelSlot : MonoBehaviour {

    Equipment KnightPanelEquipment;

    public void UpdateShield(Equipment equipment)
    {
        KnightPanelEquipment = equipment;
    }

    public void PressButton()
    {
        if (KnightPanelEquipment != null)
        {
            KnightSelection.instance.UpdateShield(KnightPanelEquipment);
        }
    }
}
