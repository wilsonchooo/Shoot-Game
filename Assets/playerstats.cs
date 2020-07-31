using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerstats : MonoBehaviour
{
    // Start is called before the first frame update
    public float life;
    public float speed;
    public float dmg;
    public float form;
    void Start()
    {
        life = 5;
        speed = 1;
        dmg = .1f;
        form = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(life >=10)
        {
            life = 10;
        }

        if (speed >= 3)
        {
            speed = 3;
        }

        if(dmg>=.5f)
        {
            dmg = .5f;
        }
        if(form>=4)
        {
            form = 4;
        }


        if (life<=0)
        {
            Destroy(this.gameObject);
            //change scene to defeat screen..
        }
    }
}
