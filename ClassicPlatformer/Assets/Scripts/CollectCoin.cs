using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public GameObject Sparkle;
    private Player player;
    public AudioSource earn;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Collect coin and destroy
        if (other.tag == "Player")
        {
            earn.Play();
            //incrase score 
            player.coins++;
           // Instantiate(Sparkle, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
