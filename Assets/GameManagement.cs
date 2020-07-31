using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManagement manager;
    int sceneNum;
    public int score;


    float life;
    float speed;
    float dmg;
    float form;
    float bombs;
    void Awake()
    {
        if(manager ==null)
        {
            manager = this;
            DontDestroyOnLoad(this);
        }
        else if(manager !=this){
            Destroy(gameObject);
        }
    }
    void Start()
    {
        sceneNum = 0;
        life = 10;
        speed = 1;
        dmg = .1f;
        form = 0;
        bombs = 3;


    }

    public void increasestat(int stat,float amount)
    {
        if(stat ==0)
        {
            life += amount;
            Debug.Log("Life:" +life);

}
        if (stat == 1)
        {
            speed += amount;
            Debug.Log(speed);
        }
        if (stat == 2)
        {
            dmg += amount;
            Debug.Log(dmg);
        }
        if (stat == 3)
        {
            form += amount;
            Debug.Log(form);
        }

        if(stat==4)
        {
            bombs += amount;
            Debug.Log("bomb");
        }

        if(life>=10)
        {
            life = 10;
        }

        if (speed >= 3)
        {
            speed = 3;
        }

        if (dmg >= .5f)
        {
            dmg = .5f;
        }
        if (form >= 4)
        {
            form = 4;
        }

        if(life<=0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            score = 0;
            resetstats();
            SceneManager.LoadScene(0);
            
        }
    }

    public int returnscore()
    {
        return score;
    }

    public void resetstats()
    {
        life = 5;
        speed = 1;
        dmg = .1f;
        form = 0;
    }

    public int returnscene()
    {
        return sceneNum;
    }
    public float retrievestat(int stat)
    {
        if (stat == 0)
        {
            return life;
        }
        if (stat == 1)
        {
            return speed;
        }
        if (stat == 2)
        {
            return dmg;
        }
        if (stat == 3)
        {
            return form;
        }

        if(stat == 4)
        {
            return bombs;
        }

        return 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            increasestat(1, 3);
            increasestat(2, .5f);
            increasestat(3, 4);
            score = 140;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            score = 80;
        }
    }

    public void nextScene()
    {

        sceneNum++;
        if(sceneNum>3)
        {
            sceneNum = 0;
        }
        SceneManager.LoadScene(sceneNum);
    }

    public void resetscore()
    {
        score = 0;
    }
    

    public void changeScore(int changeAmount)
    {
        Text scoreText = GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
        scoreText.text = "Score: " + score.ToString();
        score += changeAmount;
        Debug.Log(score);

        if(sceneNum==1 && score >=80)
        {
            Debug.Log("Scene is uspposed to change here");
            nextScene();
        }

        else if(sceneNum ==2 && score >=200)
        {
            nextScene();
        }
    }
}
