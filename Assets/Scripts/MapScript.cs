using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MapScript : MonoBehaviour {

    string url = "";

    public float lat = 0.0f;
    public float lon = 0.0f;
    LocationInfo locInfo;
    public int zoom = 10;
    public int mapWidth = 640;
    public int mapHeigth = 640;
    public enum mapType {  roadmap, satellite, hybrid, terrain };
    public mapType mapSelected;
    public int scale;

    private bool loadingMap = false;

    private IEnumerator mapCoroutine;

    IEnumerator Start()
    {
        string url = "https://maps.googleapis.com/maps/api/staticmap?center=40.714728,-73.998672&zoom=12&size=400x400&maptype=hybrid&key=AIzaSyCFgxL3Z7mr8gv2SY8bhwr_nTovIZglFZI";
        
        string url2 = "https://maps.googleapis.com/maps/api/staticmap?center=" + lat + "," + lon + "&zoom=" + zoom + "&size=" + mapWidth + "x" + mapHeigth +
            "&maptype=" + mapSelected + "&key=AIzaSyCFgxL3Z7mr8gv2SY8bhwr_nTovIZglFZI";

        WWW www = new WWW(url2);
        yield return www;
        RawImage img = GetComponent<RawImage>();
        img.texture = www.texture;
        
        //GetGoogleMap(lat, lon);
    }


    IEnumerator GetGoogleMap(float lat, float lon)
    {
        Debug.Log("yes");
        string url2 = "https://maps.googleapis.com/maps/api/staticmap?center=" + lat + "," + lon + "&zoom=" + zoom + "&size=" + mapWidth + "x" + mapHeigth +
                 "&maptype=" + mapSelected + "&key=AIzaSyCFgxL3Z7mr8gv2SY8bhwr_nTovIZglFZI";

        WWW www = new WWW(url2);
        yield return www;
        RawImage img = GetComponent<RawImage>();
        img.texture = www.texture;
    }

    /*
	// Use this for initialization
	void Start () {
        
	}
	*/
	// Update is called once per frame
	void Update () {
        GetGoogleMap(lat, lon);
    }
}
