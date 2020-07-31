using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyshooting : MonoBehaviour
{
    public GameObject enemyfirepoint1;
    public GameObject bolt;
    public bool boss;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(boss)
        {
            if(timer>=.4f)
            {
                Instantiate(bolt, new Vector3(enemyfirepoint1.transform.position.x, enemyfirepoint1.transform.position.y, enemyfirepoint1.transform.position.z), Quaternion.identity);
                timer = 0;
            }
        }
        else
        {
            if (timer >= 1.5f)
            {
                Instantiate(bolt, new Vector3(enemyfirepoint1.transform.position.x, enemyfirepoint1.transform.position.y, enemyfirepoint1.transform.position.z), Quaternion.identity);
                timer = 0;
            }
        }
       
    }
}
