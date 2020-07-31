using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenechanger : MonoBehaviour
{
    // Start is called before the first frame update
   public void ChangeScene()
    {
        GameManagement.manager.nextScene();
    }
}
