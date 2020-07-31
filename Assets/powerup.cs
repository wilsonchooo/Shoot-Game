using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    // Start is called before the first frame update
    private int type;
    public int typetest;
    void Start()
    {
        if (gameObject.name == "life_powerup")
            type = 0;
        if (gameObject.name == "speed_powerup")
            type = 1;
        if (gameObject.name == "damage_powerup")
            type = 2;
        if (gameObject.name == "form_powerup")
            type = 3;

    }

    // Update is called once per frame
    void Update()
    {


            transform.position = new Vector3(transform.position.x, transform.position.y - .005f, transform.position.z);
     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Destroy(this.gameObject);
            //Debug.Log(type);
            switch (typetest)
            {
                case 0:
                    GameManagement.manager.increasestat(0, 1);
                    break;
                case 1:

                    GameManagement.manager.increasestat(1, .3f);
                    break;
                case 2:

                    GameManagement.manager.increasestat(2, .1f);
                    break;
                case 3:

                    GameManagement.manager.increasestat(3, 1);
                    break;
                default:
                    break;
            }
            
            //collision.gameObject.GetComponent<playerstats>().life++;
        }
    }
}
