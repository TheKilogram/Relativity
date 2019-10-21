using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcPath : MonoBehaviour
{
    public GameObject startPoll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject pollPrev = Instantiate(startPoll);
        pollPrev.transform.position = new Vector2(startPoll.transform.position.x,startPoll.transform.position.y);
        var clones = GameObject.FindGameObjectsWithTag("clone");
        foreach(var clone in clones)
        {
            Destroy(clone);

        }

       
        for(int i = 0; i < 100; i++)
        {
            GameObject pollNext = pollPrev;
            pollNext.tag = "clone";
            pollNext.transform.position = new Vector2(pollPrev.transform.position.x + 0.1f,pollPrev.transform.position.y);
            
            if(pollNext)
            Instantiate(pollNext);
            pollPrev = pollNext;
        }
    }
    
}
