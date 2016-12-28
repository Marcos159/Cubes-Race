using UnityEngine;
using System.Collections;

public class ControlPosicion : MonoBehaviour
{
    public GameObject[] arrayPlayers = new GameObject [4];

    public float primeroV=300;
    public float segundoV=350;
    public float terceroV = 400;
    public float cuartoV = 450;

    GameObject temp;

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        for (int i=1; i<4;i++)
        {
            for(int j=0; j< 3; j++)
            {
               
                if (arrayPlayers[j].transform.position.x < arrayPlayers[j+1].transform.position.x)
                {
                    temp = arrayPlayers[j];
                    arrayPlayers[j] = arrayPlayers[j + 1];
                    arrayPlayers[j + 1] = temp;
                }
            }
        }
        
		Debug.Log("PRIMERO "+arrayPlayers[0].name+ " SEGUNDO "+arrayPlayers[1].name+ " TERCERO "+arrayPlayers[2].name + " CUARTO "+arrayPlayers[3].name);
        arrayPlayers[0].GetComponent<PlayerMovement>().factorMovement = primeroV;
		arrayPlayers[1].GetComponent<PlayerMovement>().factorMovement = segundoV;
        arrayPlayers[2].GetComponent<PlayerMovement>().factorMovement = terceroV;
        arrayPlayers[3].GetComponent<PlayerMovement>().factorMovement = cuartoV;
    }
}