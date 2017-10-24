using UnityEngine;
using UnityEngine.UI;

public class RangerOutfitPanel : MonoBehaviour {

    public RangerOutfitDatabase rangerOutfitDatabase;
    public GameObject buttonPrefab;

    void Start()
    {
        foreach (Item item in rangerOutfitDatabase.rangerOutfitDatabase)
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

        RangerOutfitPanelSlot it = (button.GetComponent(typeof(RangerOutfitPanelSlot)) as RangerOutfitPanelSlot);
        it.UpdateSlot(item);
    }
}
