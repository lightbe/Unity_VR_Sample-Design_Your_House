using UnityEngine;
using UnityEngine.UI;

public class CalcHomePrice : MonoBehaviour
{
    public bool displayDebug;
    public GameObject selectionStop;
    public Text budgetRangeText, housePriceText, randomOptionsText;
    float sqft, bedrooms, baths;
    float[] homePrice;
    int i, index;

    public void DisplayHouseData()
    {
        // Create array with home prices between 200,000 & 600,000 with multiples of 50,000.
        homePrice = new float[9];
        for (i = 0; i < homePrice.Length; i++)
        {
            if (i == 0)
            {
                homePrice[i] = 200000f;
            }
            else
            {
                homePrice[i] = homePrice[i - 1] + 50000f;
            }
        }
        if (displayDebug)
        {
            Debug.Log("Home Price Array: " + homePrice[0] + ", " + homePrice[1] + ", " + homePrice[2] + ", " + homePrice[3] + ", " + homePrice[40] + ", " + homePrice[5] + ", "
                      + homePrice[6] + ", " + homePrice[7] + ", " + homePrice[8]);
        }

        // Select random price from array.
        index = Random.Range(0, homePrice.Length);

        sqft = Mathf.Round((homePrice[index] / 100) + 20);
        bedrooms = Mathf.Round(homePrice[index] / 100000);
        baths = Mathf.Round(bedrooms / 2);
        if (displayDebug)
        {
            Debug.Log("Selected Price: " + homePrice[index]);
            Debug.Log("SqFt ((Selected Price / 100) + 20): " + sqft);
            Debug.Log("Bedrooms (Selected Price / 100000): " + bedrooms);
            Debug.Log("Bathrooms (Bedrooms Price / 2): " + baths);
        }
        budgetRangeText.text = "Your Budget Range: " + selectionStop.GetComponent<GetSelectedToggle>().selectedToggleBudgetText;
        housePriceText.text = "Your Total House Price\n(including options) IS\n$" + homePrice[index];
        randomOptionsText.text = "Surface: " + sqft + " Sq Ft\nBedrooms: " + bedrooms + "\nBaths: " + baths;
    }
}
