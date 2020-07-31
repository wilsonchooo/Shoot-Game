using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float speed = GameManagement.manager.retrievestat(1);
        if(Input.GetKey(KeyCode.W))
        {
            if (transform.position.y <= 4.5)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + (.03f*speed), transform.position.z);
            }
            
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x >= -2.6f)
            {
                transform.position = new Vector3(transform.position.x - (.02f*speed), transform.position.y, transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.S))
            if (transform.position.y >= -4.5)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - (speed*.03f), transform.position.z);
            }
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x <= 2.6f)
            {
                transform.position = new Vector3(transform.position.x + (speed*.02f), transform.position.y, transform.position.z);
            }
        }


    }
}
