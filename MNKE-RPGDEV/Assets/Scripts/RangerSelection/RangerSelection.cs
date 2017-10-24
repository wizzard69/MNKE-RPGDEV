using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RangerSelection : MonoBehaviour
{
    public GameObject rangerDefaultPrefab;
    public GameObject rangerDefaultBowPrefab;
    public GameObject rangerDefaultArrowPrefab;
    public GameObject outfitPanel;
    public GameObject bowPanel;
    public GameObject arrowPanel;

    GameObject currentCharacterObject;
    GameObject currentBowObject;
    GameObject currentArrowObject;

    public static RangerSelection instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameController.Instance.charSelectData.charClass = GameController.CharClass.RANGER;

        GameObject go = (GameObject)Instantiate(rangerDefaultPrefab, GameObject.Find("CharacterObject").transform, false);
        GameObject bow = Instantiate(rangerDefaultBowPrefab, go.transform.GetChild(0).gameObject.transform);
        GameObject arrow = Instantiate(rangerDefaultArrowPrefab, go.transform);

        currentCharacterObject = go;
        currentBowObject = bow;
        currentArrowObject = arrow;
    }

    public void rangerItemSelection(string rangerItemType)
    {
        switch (rangerItemType)
        {
            case "Outfit":
                OutfitSelection();
                break;
            case "Bow":
                BowSelection();
                break;
            case "Arrow":
                ArrowSelection();
                break;
        }
    }

    void OutfitSelection()
    {
        outfitPanel.SetActive(true);
        bowPanel.SetActive(false);
        arrowPanel.SetActive(false);
    }

    void BowSelection()
    {
        outfitPanel.SetActive(false);
        bowPanel.SetActive(true);
        arrowPanel.SetActive(false);
    }

    void ArrowSelection()
    {
        outfitPanel.SetActive(false);
        bowPanel.SetActive(false);
        arrowPanel.SetActive(true);
    }

    public void UpdateOutfit(Item equipment)
    {
        if (equipment != null)
        {
            GameObject goBow = currentBowObject;
            goBow.name = goBow.name.Replace("(Clone)", "");
            GameObject goArrow = currentArrowObject;
            goArrow.name = goArrow.name.Replace("(Clone)", "");

            GameObject.Destroy(currentCharacterObject);

            currentCharacterObject = (GameObject)Instantiate(equipment.prefab, GameObject.Find("CharacterObject").transform, false);
            currentBowObject = Instantiate(goBow, currentCharacterObject.transform.GetChild(0).gameObject.transform);
            currentArrowObject = Instantiate(goArrow, currentCharacterObject.transform);
        }

        GameController.Instance.charSelectData.CharacterOutfit = equipment;
    }

    public void UpdateBow(Equipment equipment)
    {
        if (equipment != null)
        {
            GameObject.Destroy(currentBowObject);
            currentBowObject = Instantiate(equipment.prefab, currentCharacterObject.transform.GetChild(0).gameObject.transform);
        }

        GameController.Instance.charSelectData.Bow = equipment;
    }

    public void UpdateArrow(Equipment equipment)
    {
        if (equipment != null)
        {
            GameObject.Destroy(currentArrowObject);
            currentArrowObject = Instantiate(equipment.prefab, currentCharacterObject.transform);
        }

        GameController.Instance.charSelectData.Arrow = equipment;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("HeroSelection");
    }
}
