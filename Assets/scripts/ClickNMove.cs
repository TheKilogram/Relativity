using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickNMove : MonoBehaviour
{
    GameObject player;
    GameObject start;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        start = GameObject.FindGameObjectWithTag("Start");
    }
    /*
    // Update is called once per frame
    void Update()
    {
        
    }
    */

    void OnMouseDrag()
    {
        if (player.transform.position == start.transform.position)
        { 
            if (!(gameObject.GetComponentInChildren<ParticleSystem>() == null))
            {
                ParticleSystem partsys = gameObject.GetComponentInChildren<ParticleSystem>();
                if (!partsys.isPlaying)
                {
                    partsys.Play();
                }
            }
            
            Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPos = Camera.main.ScreenToWorldPoint(mousePos);
            gameObject.transform.position = objPos;
            gameObject.GetComponentInChildren<SpriteRenderer>().enabled = true;
        }
    }
    private void OnPointerUp()
    {
        ParticleSystem partsys = gameObject.GetComponentInChildren<ParticleSystem>();
        if (partsys.isPlaying)
        {
            partsys.Stop();
        }
        
    }
    
}
