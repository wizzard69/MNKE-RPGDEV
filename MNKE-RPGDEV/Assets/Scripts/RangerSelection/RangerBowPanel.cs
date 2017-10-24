using UnityEngine.UI;
using UnityEngine;

public class RangerBowPanel : MonoBehaviour {

    public BowDatabase rangerBowDatabaseObject;
    public GameObject buttonPrefab;

    void Start()
    {
        foreach (Equipment equipment in rangerBowDatabaseObject.BowStatsDatabase)
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

        RangerBowPanelSlot it = (button.GetComponent(typeof(RangerBowPanelSlot)) as RangerBowPanelSlot);
        it.UpdateBow(equipment);
    }
}
