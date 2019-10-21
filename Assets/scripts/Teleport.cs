using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject teleOut;
    public GameObject player;
    private Animator animator;
    private Animator animatorOut;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animatorOut = teleOut.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.position = teleOut.transform.position;
            //Animation ani = GetComponent<Animation>();
            //ani.Play();
            animator.SetTrigger("TeleInHit");
            animatorOut.SetTrigger("TeleInHit");
        }
    }
}
