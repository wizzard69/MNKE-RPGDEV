using UnityEngine;
using UnityEngine.UI;

public class KnightOutfitPanel : MonoBehaviour {

    public KnightOutfitDatabase knightOutfitDatabase;
    public GameObject buttonPrefab;

    void Start()
    {
        foreach (Item item in knightOutfitDatabase.knightOutfitDatabase)
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

        KnightOutfitPanelSlot it = (button.GetComponent(typeof(KnightOutfitPanelSlot)) as KnightOutfitPanelSlot);
        it.UpdateSlot(item);
    }
}
