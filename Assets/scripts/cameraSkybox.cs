using UnityEngine;
using System.Collections;

public class cameraSkybox : MonoBehaviour {

    public float factorRotationSkyBox = 10;

    Skybox sky;
    float rot = 0;

    // Use this for initialization
    void Start () {
        sky = GetComponent<Skybox>();
        rot = sky.material.GetFloat("_Rotation");
    }
	
	// Update is called once per frame
	void Update () {
        //rot = sky.material.GetFloat("_Rotation");
        rot += Camera.main.transform.rotation.z * factorRotationSkyBox;
        rot %= 360;
        sky.material.SetFloat("_Rotation", rot);
    }
}
