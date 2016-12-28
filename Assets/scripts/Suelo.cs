using UnityEngine;
using System.Collections;

public class Suelo : MonoBehaviour {

    public float factorMovement = 40;

    float offSetTexture = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        offSetTexture -= Camera.main.transform.localRotation.z * Time.deltaTime * factorMovement;
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(
            offSetTexture, 0));
    }
}
