using UnityEngine;
using UnityEngine.UI;

public class BillboardMove : MonoBehaviour
{

    public float xAxisDoor = -52.0f, xAxisOther = -67.5f;
    public GameObject billboardCastle, questionMark, castle;
    public Text billboardText;
    public ParticleSystem billboardBlue, billboardWhite, billboardRed;

    public void MoveUpdateBillboard()
    {
        billboardText.text = "We Build Castles";
        questionMark.SetActive(false);
        castle.SetActive(true);
        castle.GetComponent<ImageRandom>().DisplayRandomImage();
        billboardCastle.transform.position = new Vector3(xAxisDoor, billboardCastle.transform.position.y, billboardCastle.transform.position.z);
        billboardBlue.Play();
        billboardWhite.Play();
        billboardRed.Play();
    }

    public void ResetBillboard()
    {
        billboardText.text = "Your Castle";
        questionMark.SetActive(true);
        castle.SetActive(false);
    }

    public void MoveBillboardBackward()
    {
        billboardCastle.transform.position = new Vector3(xAxisOther, billboardCastle.transform.position.y, billboardCastle.transform.position.z);
    }

}