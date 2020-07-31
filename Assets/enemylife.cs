using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemylife : MonoBehaviour
{
    public float life;
    public GameObject life_powerup;
    public GameObject speed_powerup;
    public GameObject damage_powerup;
    public GameObject form_powerup;
    public GameObject deathanimation;

    float timer;
    public int pointvalue;
    private bool died;
    private float deathtimer;
    private GameObject death;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -5.5 || transform.position.x <= -3 || transform.position.x >= 3)
        {
            Destroy(this.gameObject);
            
        }
        if (life<=0)
        {
            if(this.gameObject.tag=="boss")
            {
                
                GameObject bomb = Instantiate(deathanimation, new Vector3(0, 0, -9), Quaternion.identity);
                bomb.GetComponent<Transform>().localScale = new Vector3(bomb.GetComponent<Transform>().localScale.x * 20, bomb.GetComponent<Transform>().localScale.y * 20, bomb.GetComponent<Transform>().localScale.z * 20);
                timer += Time.deltaTime;
                Debug.Log(timer);
                if (timer>=2)
                {
                    
                    GameManagement.manager.resetscore();
                    GameManagement.manager.resetstats();
                    GameManagement.manager.nextScene();
                    Destroy(this.gameObject);
                }
                


            }
            else
            {
                Destroy(this.gameObject);
                GameManagement.manager.changeScore(pointvalue);
                float random = Random.Range(0, 100);

                if (random <= 11)
                {
                    float randomdrop = Random.Range(0, 4);
                    Debug.Log(randomdrop);
                    switch (randomdrop)
                    {
                        case 0:
                            Instantiate(life_powerup, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                            break;
                        case 1:
                            Instantiate(speed_powerup, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                            break;
                        case 2:
                            Instantiate(damage_powerup, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                            break;
                        case 3:
                            Instantiate(form_powerup, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                            break;
                        default: break;
                    }
                }
                Instantiate(deathanimation, transform.position, Quaternion.identity);
            }

        }
    }
           
}
