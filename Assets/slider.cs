using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slider : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider life;
    public Slider speed;
    public Slider dmg;
    public Slider form;


    void Start()
    {
        
    }

    void updateslider()
    {
        life.value = GameManagement.manager.retrievestat(0);
        speed.value = GameManagement.manager.retrievestat(1);
        dmg.value = GameManagement.manager.retrievestat(2);
        form.value = GameManagement.manager.retrievestat(3);

    }

    // Update is called once per frame
    void Update()
    {
        updateslider();
    }
}
