using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

    public GameObject decor;
    public GameObject checkPoint;

    float timeRespawnNextCheckPoint;
    float contTimeCheck = 0;

    float timeRespawnNextDecor;
    float contTimeDecorRight = 0;
    float contTimeDecorLeft = 0;

    Vector3 initPosDecorRight;
    Vector3 initPosDecorLeft;
    Vector3 initCheckPosition;

    // Use this for initialization
    void Start () {
        initPosDecorRight = decor.transform.position;
        initPosDecorLeft = new Vector3(-30, initPosDecorRight.y, initPosDecorRight.z);
        initCheckPosition = checkPoint.transform.position;

        timeRespawnNextDecor = Random.Range(2, 4);
        timeRespawnNextCheckPoint = Random.Range(10, 18);
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.transform.rotation.eulerAngles.z > 5 && Camera.main.transform.rotation.eulerAngles.z < 45)
        {
            contTimeDecorRight += Time.deltaTime;
            contTimeCheck += Time.deltaTime;

            if (contTimeDecorRight >= timeRespawnNextDecor)
            {
                contTimeDecorRight = 0;
                timeRespawnNextDecor = Random.Range(5 / Camera.main.transform.rotation.eulerAngles.z, 22 / Camera.main.transform.rotation.eulerAngles.z);
                Instantiate(decor, initPosDecorRight, Quaternion.identity);
            }

            if (contTimeCheck >= timeRespawnNextCheckPoint)
            {
                contTimeCheck = 0;
                timeRespawnNextCheckPoint = Random.Range(10, 18);
                GameObject check = (GameObject)Instantiate(checkPoint, initCheckPosition, Quaternion.identity);
                check.name = checkPoint.name;
            }
        }
        else if (Camera.main.transform.rotation.eulerAngles.z < 355 && Camera.main.transform.rotation.eulerAngles.z > 324)
        {
            contTimeDecorLeft += Time.deltaTime;

            if (contTimeDecorLeft >= timeRespawnNextDecor)
            {
                contTimeDecorLeft = 0;
                timeRespawnNextDecor = Random.Range(180 / Camera.main.transform.rotation.eulerAngles.z, 230 / Camera.main.transform.rotation.eulerAngles.z);
                Instantiate(decor, initPosDecorLeft, Quaternion.identity);
            }
        }
    }
}
