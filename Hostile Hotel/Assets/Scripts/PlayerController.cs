using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float speed;
    [SerializeField] Animator animator;

    bool hasCandle;

    void Update()
    {
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
        
        if (player.GetComponent<Rigidbody2D>().velocity.magnitude > 0) // player is moving
        {
            if (Input.GetAxisRaw("Horizontal") > 0) // player moving right
            {
                animator.SetBool("Moving Right", true);
                animator.SetBool("Moving Left", false);
            }
            else
            {
                animator.SetBool("Moving Left", true);
                animator.SetBool("Moving Right", false);
            }
        }
        else
        {
            animator.SetBool("Moving Left", false);
            animator.SetBool("Moving Right", false);
        }

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
