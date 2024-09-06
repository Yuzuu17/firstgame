using UnityEngine;
using TMPro;

public class BearScore : MonoBehaviour
{
    public TextMeshProUGUI bearText;
    private inventory miloInventory;

    void Start()
    {
        miloInventory = FindObjectOfType<inventory>();                       //para mahanap

        if (miloInventory == null)                                          // nullcheck para makita if nagana si find
        {
            Debug.LogError("null");
            return;
        }

        UpdateBearText();
    }

    void Update()
    {
        UpdateBearText();
    }

    private void UpdateBearText()
    {
        if (bearText != null && miloInventory != null)
        {
            bearText.text = miloInventory.NumberOfBears.ToString();      //number ni coconvert as string (int converted)
        }
    }
}