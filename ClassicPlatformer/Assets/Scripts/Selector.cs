using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selector : MonoBehaviour
{
    //mobile controls
    public bool moveLeft;
    public bool moveRight;

    public string levelChoice;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.GetInt("farthestLevel");
    }
    //public int farthestLevel = PlayerPrefs.GetInt("farthestLevel"); 

    // Update is called once per frame
    void Update()
    {
        //move
        if ( transform.position.x > - 5 && (moveLeft || Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            //level Image spaced 6 units apart
            transform.position = new Vector2(transform.position.x - 11, transform.position.y);
            moveLeft = false;
        }

        else if (transform.position.x < 1 && (moveRight || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            transform.position = new Vector2(transform.position.x + 11, transform.position.y);
            moveRight = false;
        }

        else if (transform.position.x > 1 && (moveRight || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            transform.position = new Vector2(transform.position.x + 11, transform.position.y);
            moveRight = false;
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            Select();
        }

        //update Numlevels * 11
        //GetKeyDown used coz user mustnt hold only Tap


    }

    public void Select()
    {
        SceneManager.LoadScene(levelChoice);
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        levelChoice = collision.name;
    }
}
