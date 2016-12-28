using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

    float speedMetersSec = 0;
    public float factorMovement = 60;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        speedMetersSec = -Camera.main.transform.localRotation.z * Time.deltaTime * factorMovement;
        transform.Translate(new Vector3(speedMetersSec, 0, 0));
    }

}
