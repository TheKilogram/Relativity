using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private GameObject[] influ;
    public int sign;
    public float maxDist;
 

    // Start is called before the first frame update
    void Start()
    {
       influ = GameObject.FindGameObjectsWithTag("Player");
    }
    

    // Update is called once per physics step. You need this insted of update() 
    //becaise update is called once per frame witch is not conststant
    void FixedUpdate()
    {
        foreach (GameObject influencedObj in influ)
            {
            Rigidbody2D objRb = influencedObj.GetComponent<Rigidbody2D>();
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();

            Vector2 dir = new Vector2(gameObject.transform.position.x - influencedObj.transform.position.x, gameObject.transform.position.y - influencedObj.transform.position.y);
            float dist = dir.magnitude;
            float forceMag = 0.0f;
           
            if (dist < maxDist)
            {
                forceMag = sign * ((rb.mass * objRb.mass) / Mathf.Pow(dist, 2));
            }
            

            Vector2 f = dir.normalized * forceMag;
            objRb.AddForce(f);
        }
    }

    public void LaunchHit()
    {
        Rigidbody2D brb = gameObject.GetComponent<Rigidbody2D>();
        brb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        
    }
    public void offHit()
    {
        print("hello");
        Rigidbody2D brb = gameObject.GetComponent<Rigidbody2D>();
        brb.constraints = RigidbodyConstraints2D.None;
    }
}
