using UnityEngine;
using System.Collections;

public class Camerabehavior : MonoBehaviour {

    public float maxTimeStop = 3;
    public float minTimeStop = 1;

    public float maxZRotation = 45;
    public float minZRotation = -36;

    public float velocidad=4;
    bool inicio=true;
    
    int direccion;
    bool inclinacionDerecha=true;

    public float tiempoAtras = 20;
    public float tiempoA=0;
    //Solo en Z y sera desde 
    float angleWanted = 0;

	// Use this for initialization
	void Start () {
        inicio = false;
        inclinacionDerecha = true;
        angleWanted = Random.Range(8, maxZRotation);
        transform.localEulerAngles = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        tiempoA += Time.deltaTime;
        if (inicio)
        {
            if (transform.eulerAngles.z < 1  && inclinacionDerecha)
            {
                direccion = Random.Range(0, 2);
                if (direccion < 1 && tiempoA >= tiempoAtras && GameObject.Find("checkpoint") == null)
                {
                    inclinacionDerecha = false;
                }
                else
                {
                    inclinacionDerecha = true;
                }
                if (inclinacionDerecha)
                {
                    angleWanted = Random.Range(8, maxZRotation);
                }
                else
                {
                    angleWanted = Random.Range(minZRotation, -8);
                    angleWanted = 360 + angleWanted;
                }
                inicio = false;
                transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            if (transform.eulerAngles.z >= 359 && !inclinacionDerecha)
            {
                direccion = Random.Range(0, 2);
                tiempoA = 0;
                Debug.Log("REINICIO TIEMPO " + tiempoA);
                if (direccion < 1 && tiempoA>=tiempoAtras)
                {
                    inclinacionDerecha = false;
                }
                else
                {
                    inclinacionDerecha = true;
                }
                if (inclinacionDerecha)
                {
                    angleWanted = Random.Range(8, maxZRotation);
                }
                else
                {
                    angleWanted = Random.Range(minZRotation, -8);
                    angleWanted = 360 + angleWanted;
                }
                inicio = false;
                transform.localEulerAngles = new Vector3(0, 0, 0);
                
            }
            else if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < maxZRotation && inicio)
            {
                transform.Rotate(Vector3.back * Time.deltaTime*velocidad);
            }
           else if (  transform.eulerAngles.z < 359 && !inclinacionDerecha && inicio)
            {
                transform.Rotate(Vector3.forward * Time.deltaTime * velocidad);
            }
        }
        if (angleWanted > transform.eulerAngles.z && angleWanted < maxZRotation && inclinacionDerecha &&!inicio)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime*velocidad);
        }
       if ( !inclinacionDerecha && !inicio)
        {
            transform.Rotate(Vector3.back * Time.deltaTime*velocidad);
        }

        //Cuando ya lleva tiempo en el angulo
        if (transform.eulerAngles.z >= angleWanted && inclinacionDerecha)
        {
            inicio = true;
        }
        if (transform.eulerAngles.z <=angleWanted && !inclinacionDerecha)
        {
            inicio = true;
        }
                
    }
}
