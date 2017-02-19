using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AddLocation : MonoBehaviour {

    public Text inputText;
    public Button button;
    public GameObject pinObj;
    public GameObject Globe;
    public int generatedObjCount = 0;


    void CreatePin(float lat, float lon)
    {
        string a = "pin" + generatedObjCount;
        var pin = Instantiate(pinObj, new Vector3(0, 0, 0), Quaternion.Euler(0, -lon + Globe.transform.eulerAngles.y, lat - 90), Globe.transform) ;
        
       

        generatedObjCount++;
    }

    // Use this for initialization
    void Start () {
        //CreatePin(0.0f, 0.0f);
    }

    public void onClick()
    {
        float lat = (float)AddressConverter.Locate(inputText.text).Latitude;
        float lon = (float)AddressConverter.Locate(inputText.text).Longitude;
        CreatePin(lat, lon);
    }
}