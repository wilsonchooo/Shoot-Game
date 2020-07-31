using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawncenter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject center;
    private float random;
    private float timer;
    private GameObject instantiated;
    void Start()
    {
        timer = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer>=4)
        {
            timer = 0;
            if (instantiated == null)
            {
                instantiated = Instantiate(center, transform.position, Quaternion.identity);
            }


        }
    }
}
