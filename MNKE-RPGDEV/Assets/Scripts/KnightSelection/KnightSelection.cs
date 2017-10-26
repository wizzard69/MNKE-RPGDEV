using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KnightSelection : MonoBehaviour
{
    public GameObject KnightDefaultPrefab;
    public GameObject KnightDefaultSwordPrefab;
    public GameObject KnightDefaultShieldPrefab;
    public GameObject outfitPanel;
    public GameObject swordPanel;
    public GameObject shieldPanel;

    public Item defaultOutfit;
    public Equipment defaultSword;
    public Equipment defaultShield;

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
        GameController.Instance.CClass = "KNIGHT";

        GameObject go = (GameObject)Instantiate(KnightDefaultPrefab, GameObject.Find("CharacterObject").transform, false);
        GameObject sword = Instantiate(KnightDefaultSwordPrefab, go.transform.GetChild(0).gameObject.transform);
        GameObject shield = Instantiate(KnightDefaultShieldPrefab, go.transform.GetChild(1).gameObject.transform);

        currentCharacterObject = go;
        currentShieldObject = shield;
        currentSwordObject = sword;

        GameController.Instance.Outfit = defaultOutfit;
        GameController.Instance.Sword = defaultSword;
        GameController.Instance.Shield = defaultShield;
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

        GameController.Instance.Outfit = equipment;
    }

    public void UpdateSword(Equipment equipment)
    {
        if (equipment != null)
        {
            GameObject.Destroy(currentSwordObject);
            currentSwordObject = Instantiate(equipment.prefab, currentCharacterObject.transform.GetChild(0).gameObject.transform);
        }

        GameController.Instance.Sword = equipment;
    }

    public void UpdateShield(Equipment equipment)
    {
        if (equipment != null)
        {
            GameObject.Destroy(currentShieldObject);
            currentShieldObject = Instantiate(equipment.prefab, currentCharacterObject.transform.GetChild(1).gameObject.transform);
        }

        GameController.Instance.Shield = equipment;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("HeroSelection");
    }
}
