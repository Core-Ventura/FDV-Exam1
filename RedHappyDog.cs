using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedHappyDog : MonoBehaviour
{
    Animator animator;
    public DogPlayerController player;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.animator.GetBool("isHappy") == true)
        {
            animator.SetBool("isRedHappy", true);
        } else
        {
            animator.SetBool("isRedHappy", false);
        }
    }
}
