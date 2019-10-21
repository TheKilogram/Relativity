using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    public void fromTheStart()
    {
        SceneManager.LoadScene(2);
    }
    public void loadByName(string name)
    {
        SceneManager.LoadScene(name);
    }
}
