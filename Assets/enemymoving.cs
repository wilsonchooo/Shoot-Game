using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymoving : MonoBehaviour
{
    // Start is called before the first frame update
    private float timerbeforemove;
    public float type;
    private Vector2 location;
    private float movetimer;
    void Start()
    {
         location = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch(type)
        {
            case 0:
                timerbeforemove += Time.deltaTime;
                if (timerbeforemove >= 2)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - .01f, transform.position.z);
                }
                break;
            case 1:timerbeforemove += Time.deltaTime;
                if (timerbeforemove >= 2)
                {
                    if(location.x>0)
                    transform.position = new Vector3(transform.position.x-.005f, transform.position.y, transform.position.z);

                    else if (location.x<0)
                    transform.position = new Vector3(transform.position.x + .005f, transform.position.y, transform.position.z);
                }
                break;
            case 2:
                break;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<enemylife>().life -= 10;
            Debug.Log("ouch");
            GameManagement.manager.increasestat(0, -3);
        }
    }

}
