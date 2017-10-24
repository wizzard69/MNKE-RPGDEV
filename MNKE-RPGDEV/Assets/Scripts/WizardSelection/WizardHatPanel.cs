using UnityEngine.UI;
using UnityEngine;

public class WizardHatPanel : MonoBehaviour {

    public HatDatabase WizardHatDatabaseObject;
    public GameObject buttonPrefab;

    void Start()
    {
        foreach (Item equipment in WizardHatDatabaseObject.HatStatsDatabase)
        {
            CreateButton(equipment);
        }
    }

    void CreateButton(Item equipment)
    {
        GameObject button = (GameObject)Instantiate(buttonPrefab);
        button.name = "Button_" + equipment.itemName;
        button.transform.SetParent(transform, false);
        button.GetComponentInChildren<Text>().text = equipment.itemName;

        WizardHatPanelSlot it = (button.GetComponent(typeof(WizardHatPanelSlot)) as WizardHatPanelSlot);
        it.UpdateHat(equipment);
    }
}
