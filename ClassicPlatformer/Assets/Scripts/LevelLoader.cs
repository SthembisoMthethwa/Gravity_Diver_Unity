using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public int thisLevel;
    //public int farthestLevel;
    private Selector selector;
    //private EndLevel endLevel;


    // Start is called before the first frame update
    void Start()
    {
        selector = FindObjectOfType<Selector>();
        //endLevel = FindObjectOfType<EndLevel>();

        PlayerPrefs.GetInt("farthestLevel");
    }

    // Update is called once per frame
    void Update()
    {
        //if (endLevel.levelValue < thisLevel)
        //{
        //    this.tag = "off";
        //    GetComponent<Renderer>().enabled = false;
        //}
        //else
        //{
        //    this.tag = "on";
        //    GetComponent<Renderer>().enabled = true;
        //}
    }
}
