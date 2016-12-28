using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    float speedMetersSec = 0;
    public float factorMovement = 50;

    bool isground = false;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        speedMetersSec = Camera.main.transform.localRotation.z * factorMovement * Time.deltaTime;

        GetComponent<Rigidbody>().AddForce(new Vector3(speedMetersSec, 0, 0));

        if (name == "Player1")
        {
            if (Input.GetKeyDown(KeyCode.Space) && isground)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0, 0);
                GetComponent<Rigidbody>().AddForce(new Vector3(0, 400, 0));
                isground = false;
            }
        }
        else if (name == "Player2")
        {
            if (Input.GetKeyDown(KeyCode.RightControl) && isground)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0, 0);
                GetComponent<Rigidbody>().AddForce(new Vector3(0, 400, 0));
                isground = false;
            }
        }
        else if (name == "Player3")
        {
            if (Input.GetKeyDown(KeyCode.RightShift) && isground)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0, 0);
                GetComponent<Rigidbody>().AddForce(new Vector3(0, 400, 0));
                isground = false;
            }
        }
        else if (name == "Player4")
        {
            if (Input.GetKeyDown(KeyCode.Keypad0) && isground)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0, 0);
                GetComponent<Rigidbody>().AddForce(new Vector3(0, 400, 0));
                isground = false;
            }
        }
    }

    // Comprobamos la colision con el checkPoint
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "checkpoint")
        {
            Destroy(other.gameObject);
            Scores score = GameObject.Find("GameManager").GetComponent<Scores>();
            if (name=="Player1")
                score.player1Score += 1;
            else if (name == "Player2")
                score.player2Score += 1;
            else if (name == "Player3")
                score.player3Score += 1;
            else if (name == "Player4")
                score.player4Score += 1;

            GetComponent<AudioSource>().Play();
        }
            
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "controlDerecha")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().AddForce(new Vector3(-150, 0, 0));
        }
        else if (other.gameObject.name == "controlIzquierda")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().AddForce(new Vector3(150, 0, 0));
        }
        else if (other.gameObject.name == "nieve")
            isground = true;
        else if (other.gameObject.tag == "Player")
        {
            PlayerMovement plmov = other.gameObject.GetComponent<PlayerMovement>();
            if (plmov.isGround())
            {
                isground = true;
            }
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.name == "controlDerecha")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().AddForce(new Vector3(-275, 0, 0));
        }
        else if (other.gameObject.name == "controlIzquierda")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().AddForce(new Vector3(275, 0, 0));
        }
    }

    bool isGround()
    {
        return isground;
    }
}
