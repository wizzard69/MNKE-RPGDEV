using UnityEngine.UI;
using UnityEngine;

public class WizardStaffPanel : MonoBehaviour {

    public StaffDatabase wizardStaffDatabaseObject;
    public GameObject buttonPrefab;

    void Start()
    {
        foreach (Equipment equipment in wizardStaffDatabaseObject.staffDatabase)
        {
            CreateButton(equipment);
        }
    }

    void CreateButton(Equipment equipment)
    {
        GameObject button = (GameObject)Instantiate(buttonPrefab);
        button.name = "Button_" + equipment.itemName;
        button.transform.SetParent(transform, false);
        button.GetComponentInChildren<Text>().text = equipment.itemName;

        WizardStaffPanelSlot it = (button.GetComponent(typeof(WizardStaffPanelSlot)) as WizardStaffPanelSlot);
        it.UpdateStaff(equipment);
    }
}
