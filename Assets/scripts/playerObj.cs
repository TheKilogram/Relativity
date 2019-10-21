using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class playerObj : MonoBehaviour
{
    public float velocityX;
    public float velocityY;
    public GameObject startNode;
    private Rigidbody2D rb;
    public GameObject[] boundries;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        //rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        gameObject.transform.position = startNode.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLaunchHit()
    {


        // rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.velocity = new Vector2(velocityX, velocityY);
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Boundry" )//|| collision.gameObject.tag == "BoundryBH")
        {
            
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            rb.velocity = new Vector2(0, 0);
            gameObject.transform.position = startNode.transform.position;
            gameObject.transform.rotation = startNode.transform.rotation;


            boundries = GameObject.FindGameObjectsWithTag("BoundryBH");
            foreach (GameObject boundry in boundries)
            {
                boundry.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                //brb.constraints = RigidbodyConstraints2D.None;
            }
            
        }
        
        else if(collision.gameObject.tag == "Finish")
        {
            //new level
            print("next level");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BoundryBH")
        {

            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            rb.velocity = new Vector2(0, 0);
            gameObject.transform.position = startNode.transform.position;
            gameObject.transform.rotation = startNode.transform.rotation;


            boundries = GameObject.FindGameObjectsWithTag("BoundryBH");
            foreach (GameObject boundry in boundries)
            {
                boundry.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                //brb.constraints = RigidbodyConstraints2D.None;
            }
            
        }
    }
}
