using UnityEngine;
using UnityEngine.UI;

public class DisplayHousePhotos : MonoBehaviour
{

    public GameObject houseImage, livingImage, bedroomImage, houseImageFinal, livingImageFinal, bedroomImageFinal;

    // Use this for initialization
    public void DisplayPhotos()
    {
        houseImage.GetComponent<ImageRandom>().DisplayRandomImage();
        livingImage.GetComponent<ImageRandom>().DisplayRandomImage();
        bedroomImage.GetComponent<ImageRandom>().DisplayRandomImage();

        //Set images in room 6 equal to the ones just displayed in room 4
        houseImageFinal.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        houseImageFinal.GetComponent<Image>().sprite = houseImage.GetComponent<Image>().sprite;

        livingImageFinal.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        livingImageFinal.GetComponent<Image>().sprite = livingImage.GetComponent<Image>().sprite;

        bedroomImageFinal.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        bedroomImageFinal.GetComponent<Image>().sprite = bedroomImage.GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    public void RemovePhotos()
    {
        houseImage.GetComponent<ImageRandom>().RemoveRandomImage();
        livingImage.GetComponent<ImageRandom>().RemoveRandomImage();
        bedroomImage.GetComponent<ImageRandom>().RemoveRandomImage();

        //Remove pictures from room 6 by setting color to transparent
        houseImageFinal.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
        houseImageFinal.GetComponent<Image>().sprite = null;

        livingImageFinal.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
        livingImageFinal.GetComponent<Image>().sprite = null;

        bedroomImageFinal.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
        bedroomImageFinal.GetComponent<Image>().sprite = null;
    }

}
