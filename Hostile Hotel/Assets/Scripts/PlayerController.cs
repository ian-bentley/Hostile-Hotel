using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float speed;

    bool hasCandle;

    void Update()
    {
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
        if (Input.GetKeyDown(KeyCode.E)) Debug.Log("E");
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Altar")
        {
            if (hasCandle && Input.GetKeyDown(KeyCode.E))
            {
                other.gameObject.GetComponent<Altar>().HasCandle = true;
                hasCandle = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Candle")
        {
            Destroy(other.gameObject);
            hasCandle = true;
        }
    }
}
