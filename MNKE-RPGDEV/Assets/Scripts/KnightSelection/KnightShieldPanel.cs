using UnityEngine.UI;
using UnityEngine;

public class KnightShieldPanel : MonoBehaviour {

    public ShieldDatabase knightShieldDatabaseObject;
    public GameObject buttonPrefab;

    void Start()
    {
        foreach (Equipment equipment in knightShieldDatabaseObject.ShieldStatsDatabase)
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

        KnightShieldPanelSlot it = (button.GetComponent(typeof(KnightShieldPanelSlot)) as KnightShieldPanelSlot);
        it.UpdateShield(equipment);
    }
}
