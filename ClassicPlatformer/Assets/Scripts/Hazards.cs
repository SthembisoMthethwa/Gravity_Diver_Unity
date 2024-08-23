using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazards : MonoBehaviour
{
    private Player player;
    //public GameObject Blood;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.Death();

            //Use same coordinate for player to Blood
            //Instantiate(player.Blood, player.transform.position, player.transform.rotation);

            //restart to point(_) if spiked
            //player.transform.position = new Vector2(player.startx, player.starty);


        }
    }
 
}
