using UnityEngine;
using UnityEngine.UI;

public class ImageRandom : MonoBehaviour
{
     public Sprite[] imageFile;
    int index;

    public void DisplayRandomImage()
    {         index = Random.Range(0, imageFile.Length);
        GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        GetComponent<Image>().sprite = imageFile[index];
    }

    public void RemoveRandomImage()
    {

        GetComponent<Image>().color = new Color32(0, 0, 0, 0); // set color to transparent
        GetComponent<Image>().sprite = null;
    }

}
