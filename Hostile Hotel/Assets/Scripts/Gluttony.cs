using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gluttony : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] InteractableObject skeletonPlate;

    void Update()
    {
        if (skeletonPlate.ReceivedItem)
        {
            animator.SetBool("Smells Lure", true);
        }

        // if arrived at lure, stop walking and start eating
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("Caught Player", true);
        }
    }
}
