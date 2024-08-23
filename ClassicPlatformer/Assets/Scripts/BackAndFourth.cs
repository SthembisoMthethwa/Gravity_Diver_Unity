using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndFourth : MonoBehaviour
{
    public double amountToMove;
    public float speed;
    private float startx;
    private float starty;
    public int direction;

    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        //direction = 0;
        startx = gameObject.transform.position.x;
        starty = gameObject.transform.position.y;
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < startx + amountToMove && direction ==0)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x +
                speed, gameObject.transform.position.y);
        }
        else if (gameObject.transform.position.x >= startx + amountToMove && direction == 0)
        {
            direction = 1;
        }
        else if (gameObject.transform.position.x > startx && direction == 1)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x -
                speed, gameObject.transform.position.y);
        }
        else if (gameObject.transform.position.x <= startx && direction ==1)
        {
            direction = 0;
        }
        
        //Up n Down
        //
        if (gameObject.transform.position.y < starty + amountToMove && direction == 3)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, 
            gameObject.transform.position.y + speed);
        }
        else if (gameObject.transform.position.y >= starty + amountToMove && direction == 3)
        {
            direction = 2;
        }
        else if (gameObject.transform.position.y > starty && direction == 2)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x,
            gameObject.transform.position.y - speed);
        }
        else if (gameObject.transform.position.y <= starty && direction == 2)
        {
            direction = 3;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.parent = gameObject.transform;
        }   
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.parent = null;
        }
    }
}
