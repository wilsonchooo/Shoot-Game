using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvas : MonoBehaviour
{
    public Slider life;
    public Slider speed;
    public Slider dmg;
    public Slider form;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        life.value = GameManagement.manager.retrievestat(0);
        speed.value = GameManagement.manager.retrievestat(1);
        dmg.value = GameManagement.manager.retrievestat(2);
        form.value = GameManagement.manager.retrievestat(3);
    }
}
