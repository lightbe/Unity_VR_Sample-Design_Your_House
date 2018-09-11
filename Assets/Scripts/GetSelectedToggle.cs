using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GetSelectedToggle : MonoBehaviour
{

    public ToggleGroup budgetToggleGroup, styleToggleGroup, sqftToggleGroup, bedroomToggleGroup, bathToggleGroup, outsideToggleGroup, insideToggleGroup;
    public GameObject roomPhotos, roomInside, roomReveal;
    public string selectedToggleBudgetText;
    bool checkToggles, checkOutsideToggle, checkInsideToggle;
    Toggle selectedToggleBudget, selectedToggleStyle, selectedToggleSqft, selectedToggleBedroom, selectedToggleBath, selectedToggleOutside, selectedToggleInside;

    // Initialize gameobjects to check toggles for initial house selection
    public void ResetHouseSelectionRoom()
    {
        roomPhotos.SetActive(false);
        StartToggleChecking();

        budgetToggleGroup.SetAllTogglesOff();
        styleToggleGroup.SetAllTogglesOff();
        sqftToggleGroup.SetAllTogglesOff();
        bedroomToggleGroup.SetAllTogglesOff();
        bathToggleGroup.SetAllTogglesOff();

        selectedToggleBudget = null;
        selectedToggleBudgetText = null;
        selectedToggleStyle = null;
        selectedToggleSqft = null;
        selectedToggleBedroom = null;
        selectedToggleBath = null;

    }

    // Initialize gameobjects to check toggles for outside house option
    public void ResetOutsideOptionRoom()
    {
        roomInside.SetActive(false);

        outsideToggleGroup.SetAllTogglesOff();

        selectedToggleOutside = null;
    }

    // Initialize gameobjects to check toggles for inside house options
    public void ResetInsideOptionRoom()
    {
        roomReveal.SetActive(false);

        insideToggleGroup.SetAllTogglesOff();

        selectedToggleInside = null;
    }

    // Use this for initialization
    public void StartToggleChecking()
    {
        checkToggles = true;
    }

    // Use this for initialization
    public void StopToggleChecking()
    {
        checkToggles = false;
    }

    // Use this for initialization
    public void StartToggleCheckingOutside()
    {
        checkOutsideToggle = true;
    }

    // Use this for initialization
    public void StopToggleCheckingOutside()
    {
        checkOutsideToggle = false;
    }

    // Use this for initialization
    public void StartToggleCheckingInside()
    {
        checkInsideToggle = true;
    }

    // Use this for initialization
    public void StopToggleCheckingInside()
    {
        checkInsideToggle = false;
    }

    // Use this for initialization
    void Update()
    {

        if (checkToggles)
        {

            if (budgetToggleGroup.ActiveToggles().FirstOrDefault())
            {
                selectedToggleBudget = budgetToggleGroup.ActiveToggles().FirstOrDefault();
                selectedToggleBudgetText = selectedToggleBudget.GetComponentInChildren<Text>().text;
            }

            if (styleToggleGroup.ActiveToggles().FirstOrDefault())
            {
                selectedToggleStyle = styleToggleGroup.ActiveToggles().FirstOrDefault();
            }

            if (sqftToggleGroup.ActiveToggles().FirstOrDefault())
            {
                selectedToggleSqft = sqftToggleGroup.ActiveToggles().FirstOrDefault();
            }

            if (bedroomToggleGroup.ActiveToggles().FirstOrDefault())
            {
                selectedToggleBedroom = bedroomToggleGroup.ActiveToggles().FirstOrDefault();
            }

            if (bathToggleGroup.ActiveToggles().FirstOrDefault())
            {
                selectedToggleBath = bathToggleGroup.ActiveToggles().FirstOrDefault();
            }

            if (selectedToggleBudget == null || selectedToggleStyle == null || selectedToggleSqft == null || selectedToggleBedroom == null || selectedToggleBath == null)
            {

            }
            else
            {
                roomPhotos.SetActive(true);
            }

        }

        if (checkOutsideToggle)
        {

            if (outsideToggleGroup.ActiveToggles().FirstOrDefault())
            {
                selectedToggleOutside = outsideToggleGroup.ActiveToggles().FirstOrDefault();
                roomInside.SetActive(true);
            }

        }

        if (checkInsideToggle)
        {

            if (insideToggleGroup.ActiveToggles().FirstOrDefault())
            {
                selectedToggleInside = insideToggleGroup.ActiveToggles().FirstOrDefault();
                roomReveal.SetActive(true);
            }

        }

    }

}