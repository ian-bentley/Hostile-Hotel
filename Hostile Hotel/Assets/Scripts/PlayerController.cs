using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float speed;

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.A))
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * speed, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(1 * speed, 0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1 * speed);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1 * speed);
        }
        */

        player.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
    }
}
