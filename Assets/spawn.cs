using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject spawnpoint1;
    public GameObject spawnpoint2;
    public GameObject spawnpoint3;
    public GameObject bossspawn;

    bool bossspawned;
    private GameObject spawned;
    private GameObject spawned2;
    private float timer;
    void Start()
    {
        Instantiate(enemy1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        bossspawned = false;
    }

    void spawner(float multiplier, float statmultiplier)
    {
        if (timer >= 1.5*multiplier)
        {
            spawned = Instantiate(enemy1, new Vector2(Random.Range(-2.75f, 2.75f), 4.6f), Quaternion.identity);
            float random = Random.Range(0, 100);
            if (random < 25)
            {
                float leftorright = Random.Range(0, 2);
                if (leftorright == 0)
                {
                    spawned2 = Instantiate(enemy2, new Vector2(-2.3f, Random.Range(0, 6)), Quaternion.identity);
                }

                else if (leftorright == 1)
                {
                    spawned2 = Instantiate(enemy2, new Vector2(2.3f, Random.Range(0, 6)), Quaternion.identity);
                    Debug.Log("Spawned right");
                }
                if(GameManagement.manager.returnscene() == 2)
                {
                    if (random < 10)
                    {
                        spawned2.GetComponent<SpriteRenderer>().color = Color.red;
                        spawned2.GetComponent<enemylife>().life += 5 * statmultiplier;
                        spawned.GetComponent<SpriteRenderer>().color = Color.red;
                        spawned.GetComponent<enemylife>().life += 2 * statmultiplier;

                        spawned.GetComponent<enemylife>().pointvalue = 2;
                        spawned2.GetComponent<enemylife>().pointvalue = 4;

                    }
                }

            }
            timer = 0;
        }
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if (GameManagement.manager.returnscore() < 20)
        {
            spawner(1, 1);
        }
        else if (GameManagement.manager.returnscore()>=20 && GameManagement.manager.returnscore() < 50)
        {
            spawner(.8f, 1.5f);
        }

        else if (GameManagement.manager.returnscore() >= 50 && GameManagement.manager.returnscore() <80)
        {
            spawner(.5f, 2f);
        }

        else if (GameManagement.manager.returnscore() >= 80 && GameManagement.manager.returnscore() < 150)
        {
            spawner(.4f, 2f);
        }
        else if (GameManagement.manager.returnscore() >= 150)
        {

            spawner(1.5f, 1f);
            if (!bossspawned)
            {
                Instantiate(enemy3, bossspawn.transform.position, Quaternion.identity);
            }

            bossspawned = true;
        }



    }
}
