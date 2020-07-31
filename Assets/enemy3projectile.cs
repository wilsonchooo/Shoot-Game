using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3projectile : MonoBehaviour
{
    // Start is called before the first frame update
    private float RotateSpeed = 2.5f;
    private float Radius = 1f;

    private float timer;
    public GameObject center;

    private Vector2 centre;
    private float angle;
    public float speed;
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        centre = GameObject.FindGameObjectWithTag("enemy3attack").transform.position;
        angle += RotateSpeed * Time.deltaTime;
        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
        transform.position = centre + offset;

        if (transform.position.y <= -5.5 || transform.position.x <= -3 || transform.position.x >= 3)
            Destroy(this.gameObject);
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
