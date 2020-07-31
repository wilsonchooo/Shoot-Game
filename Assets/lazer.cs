using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer : MonoBehaviour
{
    // Start is called before the first frame update
    private LineRenderer lrend;
    private float lazerdistance;
    public LayerMask mask;
    void Start()
    {
        lrend = GetComponent<LineRenderer>();
        lazerdistance = 10;
        lrend.startWidth = .1f;
        lrend.endWidth = .1f;
    }

    public void lazershoot(bool shoot)
    {
        if(shoot)
        {
            Debug.DrawRay(transform.position, transform.up * lazerdistance, Color.red);
            Ray ray = new Ray(transform.position, transform.up);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, lazerdistance, mask);
            lrend.SetPosition(0, transform.position);
            lrend.SetPosition(1, new Vector3(transform.position.x, transform.position.y + lazerdistance, transform.position.z));
            if (hit.collider != null && hit.collider.gameObject.tag == "enemy")
            {
                lrend.SetPosition(1, new Vector3(transform.position.x, hit.collider.gameObject.transform.position.y, transform.position.z));
                hit.collider.gameObject.GetComponent<enemylife>().life -= .01f;
                Debug.Log(hit.collider.gameObject.GetComponent<enemylife>().life);
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        
            //if(GetComponentInParent<playerstats>().form)
            Debug.DrawRay(transform.position, transform.up * lazerdistance, Color.red);
            Ray ray = new Ray(transform.position, transform.up);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, lazerdistance, mask);
            lrend.SetPosition(0,transform.position);
            lrend.SetPosition(1, new Vector3(transform.position.x,transform.position.y + lazerdistance,transform.position.z));
            if (hit.collider != null && hit.collider.gameObject.tag == "enemy")
            {
                lrend.SetPosition(1, new Vector3(transform.position.x, hit.collider.gameObject.transform.position.y,transform.position.z));
                hit.collider.gameObject.GetComponent<enemylife>().life -= .01f;
                //Debug.Log(hit.collider.gameObject.GetComponent<enemylife>().life);
            }
            
    }


}
