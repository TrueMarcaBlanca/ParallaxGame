using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement player;

    void Awake()
    {
        animator.SetBool("isEnd", false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.isEnd = true;
            player.runSpeed = 0.0f;
            animator.SetBool("isEnd", true);
        }
    
    }
}
