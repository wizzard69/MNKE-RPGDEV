using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WizardSelection : MonoBehaviour
{
    public GameObject wizardDefaultPrefab;
    public GameObject wizardDefaultStaffPrefab;
    public GameObject wizardDefaultHatPrefab;
    public GameObject outfitPanel;
    public GameObject hatPanel;
    public GameObject staffPanel;

    GameObject currentCharacterObject;
    GameObject currentStaffObject;
    GameObject currentHatObject;

    public static WizardSelection instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameController.Instance.charSelectData.charClass = GameController.CharClass.WIZARD;

        GameObject go = (GameObject)Instantiate(wizardDefaultPrefab, GameObject.Find("CharacterObject").transform, false);
        GameObject staff = Instantiate(wizardDefaultStaffPrefab, go.transform.GetChild(0).gameObject.transform);
        GameObject hat = Instantiate(wizardDefaultHatPrefab, go.transform);

        currentCharacterObject = go;
        currentStaffObject = staff;
        currentHatObject = hat;
    }

    public void WizardItemSelection(string knightItemType)
    {
        switch (knightItemType)
        {
            case "Outfit":
                OutfitSelection();
                break;
            case "Hat":
                HatSelection();
                break;
            case "Staff":
                StaffSelection();
                break;
        }
    }

    void OutfitSelection()
    {
        outfitPanel.SetActive(true);
        staffPanel.SetActive(false);
        hatPanel.SetActive(false);
    }

    void StaffSelection()
    {
        outfitPanel.SetActive(false);
        staffPanel.SetActive(true);
        hatPanel.SetActive(false);
    }

    void HatSelection()
    {
        outfitPanel.SetActive(false);
        staffPanel.SetActive(false);
        hatPanel.SetActive(true);
    }

    public void UpdateOutfit(Item equipment)
    {
        if (equipment != null)
        {
            GameObject goStaff = currentStaffObject;
            goStaff.name = goStaff.name.Replace("(Clone)", "");
            GameObject goHat = currentHatObject;
            goHat.name = goHat.name.Replace("(Clone)", "");

            GameObject.Destroy(currentCharacterObject);

            currentCharacterObject = (GameObject)Instantiate(equipment.prefab, GameObject.Find("CharacterObject").transform, false);
            currentStaffObject = Instantiate(goStaff, currentCharacterObject.transform.GetChild(0).gameObject.transform);
            currentHatObject = Instantiate(goHat, currentCharacterObject.transform);
        }

        GameController.Instance.charSelectData.CharacterOutfit = equipment;
    }

    public void UpdateStaff(Equipment equipment)
    {
        if (equipment != null)
        {
            GameObject.Destroy(currentStaffObject);
            currentStaffObject = Instantiate(equipment.prefab, currentCharacterObject.transform.GetChild(0).gameObject.transform);
        }

        GameController.Instance.charSelectData.Staff = equipment;
    }

    public void UpdateHat(Item equipment)
    {
        if (equipment != null)
        {
            GameObject.Destroy(currentHatObject);
            currentHatObject = Instantiate(equipment.prefab, currentCharacterObject.transform);
        }

        GameController.Instance.charSelectData.WizardHat = equipment;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("HeroSelection");
    }
}
