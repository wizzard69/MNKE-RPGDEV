using UnityEngine;
using UnityEngine.UI;

public class KnightSelection : MonoBehaviour
{
    public GameObject KnightDefaultPrefab;
    public GameObject KnightDefaultSwordPrefab;
    public GameObject KnightDefaultShieldPrefab;
    public GameObject outfitPanel;
    public GameObject swordPanel;
    public GameObject shieldPanel;

    //public ShieldDatabase shieldDatabase;
    //public SwordDatabase swordDatabase;
    //public KnightOutfitDatabase KnightOutfitDatabase;

    GameObject currentCharacterObject;
    GameObject currentShieldObject;
    GameObject currentSwordObject;

    public static KnightSelection instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameObject go = (GameObject)Instantiate(KnightDefaultPrefab, GameObject.Find("CharacterObject").transform, false);
        GameObject sword = Instantiate(KnightDefaultSwordPrefab, go.transform.GetChild(0).gameObject.transform);
        GameObject shield = Instantiate(KnightDefaultShieldPrefab, go.transform.GetChild(1).gameObject.transform);

        currentCharacterObject = go;
        currentShieldObject = shield;
        currentSwordObject = sword;
    }

    public void KnightItemSelection(string knightItemType)
    {
        switch (knightItemType)
        {
            case "Outfit":
                OutfitSelection();
                break;
            case "Shield":
                ShieldSelection();
                break;
            case "Sword":
                SwordSelection();
                break;
        }
    }

    void OutfitSelection()
    {
        outfitPanel.SetActive(true);
        swordPanel.SetActive(false);
        shieldPanel.SetActive(false);
    }

    void ShieldSelection()
    {
        outfitPanel.SetActive(false);
        swordPanel.SetActive(false);
        shieldPanel.SetActive(true);
    }

    void SwordSelection()
    {
        outfitPanel.SetActive(false);
        swordPanel.SetActive(true);
        shieldPanel.SetActive(false);
    }

    public void UpdateOutfit(Item equipment)
    {
        if (equipment != null)
        {
            GameObject gosword = currentSwordObject;
            gosword.name = gosword.name.Replace("(Clone)", "");
            GameObject goshield = currentShieldObject;
            goshield.name = goshield.name.Replace("(Clone)", "");

            GameObject.Destroy(currentCharacterObject);

            currentCharacterObject = (GameObject)Instantiate(equipment.prefab, GameObject.Find("CharacterObject").transform, false);
            currentSwordObject = Instantiate(gosword, currentCharacterObject.transform.GetChild(0).gameObject.transform);
            currentShieldObject = Instantiate(goshield, currentCharacterObject.transform.GetChild(1).gameObject.transform);
        }
    }

    public void UpdateSword(Equipment equipment)
    {
        if (equipment != null)
        {
            GameObject.Destroy(currentSwordObject);
            currentSwordObject = Instantiate(equipment.prefab, currentCharacterObject.transform.GetChild(0).gameObject.transform);
        }
    }

    public void UpdateShield(Equipment equipment)
    {
        if (equipment != null)
        {
            GameObject.Destroy(currentShieldObject);
            currentShieldObject = Instantiate(equipment.prefab, currentCharacterObject.transform.GetChild(1).gameObject.transform);
        }
    }
}
