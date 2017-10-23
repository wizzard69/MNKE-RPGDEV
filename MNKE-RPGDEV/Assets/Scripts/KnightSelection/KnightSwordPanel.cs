using UnityEngine.UI;
using UnityEngine;

public class KnightSwordPanel : MonoBehaviour {

    public SwordDatabase knightSwordDatabaseObject;
    public GameObject buttonPrefab;

    void Start()
    {
        foreach (Equipment equipment in knightSwordDatabaseObject.SwordStatsDatabase)
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

        KnightSwordPanelSlot it = (button.GetComponent(typeof(KnightSwordPanelSlot)) as KnightSwordPanelSlot);
        it.UpdateSword(equipment);
    }
}
