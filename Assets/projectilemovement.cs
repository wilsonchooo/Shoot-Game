using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectilemovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y > 5.5)
            Destroy(this.gameObject);


        transform.position = new Vector3(transform.position.x, transform.position.y + .05f, transform.position.z);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="enemy" || collision.gameObject.tag=="boss")
        {
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<enemylife>().life--;
        }

        if(collision.gameObject.tag=="box")
        {
            Destroy(this.gameObject);
        }

        
    }
}
