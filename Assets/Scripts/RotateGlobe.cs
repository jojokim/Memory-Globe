using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGlobe : MonoBehaviour {

    public Transform globe;
    private Touch initTouch = new Touch();

    private float rotX = 0.0f;
    private Vector3 origRot;

    public float rotSpeed = 1f;
    public float dir = -1f;


        // Use this for initialization
    void Start () {
        origRot = globe.transform.eulerAngles;
        rotX = origRot.x;
	}
	
	// Update is called once per frame
	void FixedUpdate () {


        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                initTouch = touch;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                float deltaX = initTouch.position.x - touch.position.x;
                rotX -= deltaX * Time.deltaTime * rotSpeed * dir;
                globe.transform.eulerAngles = new Vector3( 0f, rotX, 0f);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
            }
        }
    }
}
