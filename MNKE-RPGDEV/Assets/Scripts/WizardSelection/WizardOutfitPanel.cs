using UnityEngine;
using UnityEngine.UI;

public class WizardOutfitPanel : MonoBehaviour {

    public WizardOutfitDatabase wizardOutfitDatabase;
    public GameObject buttonPrefab;

    void Start()
    {
        foreach (Item item in wizardOutfitDatabase.wizardOutfitDatabase)
        {
            CreateButton(item);
        }
    }

    void CreateButton(Item item)
    {
        GameObject button = (GameObject)Instantiate(buttonPrefab);
        button.name = "Button_" + item.itemName;
        button.transform.SetParent(transform, false);
        button.GetComponentInChildren<Text>().text = item.itemName;

        WizardOutfitPanelSlot it = (button.GetComponent(typeof(WizardOutfitPanelSlot)) as WizardOutfitPanelSlot);
        it.UpdateSlot(item);
    }
}
