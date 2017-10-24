using UnityEngine.UI;
using UnityEngine;

public class RangerArrowPanel : MonoBehaviour {

    public ArrowDatabase rangerArrowDatabaseObject;
    public GameObject buttonPrefab;

    void Start()
    {
        foreach (Equipment equipment in rangerArrowDatabaseObject.ArrowStatsDatabase)
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

        RangerArrowPanelSlot it = (button.GetComponent(typeof(RangerArrowPanelSlot)) as RangerArrowPanelSlot);
        it.UpdateArrow(equipment);
    }
}
