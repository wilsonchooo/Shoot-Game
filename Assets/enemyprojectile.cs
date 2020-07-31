using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyprojectile : MonoBehaviour
{
    // Start is called before the first frame update
    public int type;
    private float type2timer;
    public GameObject player;
    public float type2speed;
    private Vector3 playerloc;
    private Vector3 movedirection;
    void Start()
    {
        playerloc = player.transform.position;


        GameObject play = GameObject.FindGameObjectWithTag("Player");
        movedirection = (play.transform.position - transform.position).normalized * type2speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -5.5 || transform.position.x <= -3 || transform.position.x >= 3)
            Destroy(this.gameObject);
        //Debug.Log(movedirection);
        switch (type)
        {
            case 0: transform.position = new Vector3(transform.position.x, transform.position.y - .04f, transform.position.z);
                break;
            case 1: type2timer += Time.deltaTime;
                if(type2timer >=1)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(movedirection.x, movedirection.y);
                    break;
                }
                break;
            default: break;
            
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Debug.Log("yikes");
            GameManagement.manager.increasestat(0, -1);
        }
    }
}
