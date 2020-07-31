using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class attack : MonoBehaviour
{
    public GameObject firepoint1;
    public GameObject firepoint2;
    public GameObject firepoint3;
    public GameObject bolt;
    public GameObject explosion;
    public LayerMask mask;

    public Image tnt1;
    public Image tnt2;
    public Image tnt3;

    private int tntcount=2;

    float lazerdistance;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        firepoint1.GetComponentInChildren<lazer>().enabled = false;
        firepoint2.GetComponentInChildren<lazer>().enabled = false;
        firepoint3.GetComponentInChildren<lazer>().enabled = false;


    }

    void lazer(GameObject firepoint)
    {
        LineRenderer lrend = firepoint.GetComponent<LineRenderer>();
        lazerdistance = 10;
        lrend = GetComponent<LineRenderer>();
        lrend.startWidth = .1f;
        lrend.endWidth = .1f;


        Debug.DrawRay(firepoint.transform.position, transform.up * lazerdistance, Color.red);
        Ray ray = new Ray(firepoint.transform.position, transform.up);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, lazerdistance, mask);
        lrend.SetPosition(0, firepoint.transform.position);
        lrend.SetPosition(1, new Vector3(firepoint.transform.position.x, firepoint.transform.position.y + lazerdistance, firepoint.transform.position.z));
        if (hit.collider != null && (hit.collider.gameObject.tag == "enemy" || hit.collider.gameObject.tag == "boss"))
        {
            lrend.SetPosition(1, new Vector3(firepoint.transform.position.x, hit.collider.gameObject.transform.position.y, firepoint.transform.position.z));
            hit.collider.gameObject.GetComponent<enemylife>().life -= .01f;
            Debug.Log(hit.collider.gameObject.GetComponent<enemylife>().life);
            
        }
    }

    void enablelazer(bool enable,GameObject firepoint)
    {
        if(enable)
        {
            firepoint.GetComponentInChildren<lazer>().enabled = true;
            firepoint.GetComponentInChildren<LineRenderer>().positionCount = 2;
        }
           
        else
        {
            firepoint.GetComponentInChildren<lazer>().enabled = false;
            firepoint.GetComponentInChildren<LineRenderer>().positionCount = 0;
        }

    }

    void shoot(GameObject firepoint)
    {
        Instantiate(bolt, new Vector3(firepoint.transform.position.x, firepoint.transform.position.y, firepoint.transform.position.z), Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        float form = GameManagement.manager.retrievestat(3);
        float shoottimer = GameManagement.manager.retrievestat(2);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(GameManagement.manager.retrievestat(4) > 0)
            {

                GameManagement.manager.increasestat(4, -1);
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
                for(int i=0;i<enemies.Length;i++)
                {
                    Destroy(enemies[i].gameObject);
                }
                GameManagement.manager.changeScore(enemies.Length);
                GameObject[] enemiebullets = GameObject.FindGameObjectsWithTag("enemybullet");
                for (int i = 0; i < enemiebullets.Length; i++)
                {
                    Destroy(enemiebullets[i].gameObject);
                }

                GameObject bomb = Instantiate(explosion, new Vector3(0,0,0), Quaternion.identity);
                bomb.GetComponent<Transform>().localScale = new Vector3(bomb.GetComponent<Transform>().localScale.x*10, bomb.GetComponent<Transform>().localScale.y*10, bomb.GetComponent<Transform>().localScale.z*10);

                
                

                switch (tntcount)
                {
                    case 2:
                        GameObject.Find("tnt3").GetComponent<Image>().enabled = false;
                        tntcount--;
                        break;
                    case 1:
                        GameObject.Find("tnt2").GetComponent<Image>().enabled = false;
                        tntcount--;
                        break;

                    case 0:
                        GameObject.Find("tnt1").GetComponent<Image>().enabled = false;
                        break;
                }
            }
        }


        timer += Time.deltaTime;
            switch (form)
            {
                case 0:
                    if (timer>=.6f-shoottimer)
                    {
                        shoot(firepoint1);
                        timer = 0;
                    }
                    break;
                case 1:
                    if (timer >= .6f - shoottimer)
                    {
                        shoot(firepoint1);
                        shoot(firepoint2);
                        timer = 0;
                    }
                    break;
                case 2:
                    if (timer >= .6f - shoottimer)
                    {
                        shoot(firepoint1);
                        shoot(firepoint2);
                        shoot(firepoint3);
                        timer = 0;
                    }
                    break;
                case 3:
                enablelazer(true, firepoint1);
                if (timer >= .6f - shoottimer)
                {
                    shoot(firepoint1);
                    shoot(firepoint2);
                    shoot(firepoint3);
                    timer = 0;
                }
                break;
                case 4:
                    enablelazer(true, firepoint1);
                    enablelazer(true, firepoint2);
                    enablelazer(true, firepoint3);
                    if (timer >= .6f - shoottimer)
                    {
                        shoot(firepoint1);
                        shoot(firepoint2);
                        shoot(firepoint3);
                        timer = 0;
                    }
                    break;
                default:
                    Instantiate(bolt, new Vector3(firepoint1.transform.position.x, firepoint1.transform.position.y, firepoint1.transform.position.z), Quaternion.identity);
                    break;

            }

        
        /*
        if(Input.GetKeyUp(KeyCode.Space))
        {
            enablelazer(false, firepoint1);
            enablelazer(false, firepoint2);
            enablelazer(false, firepoint3);
        }
        */
    }
}
