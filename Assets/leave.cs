using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leave : MonoBehaviour
{
    // Start is called before the first frame update
    float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>=.5f)
        {
            GetComponent<Animator>().enabled = false;
            Destroy(this.gameObject);
            timer = 0;
        }
        
    }
}
