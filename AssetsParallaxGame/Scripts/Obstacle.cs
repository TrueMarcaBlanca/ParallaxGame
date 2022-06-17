using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private CharacterController2D player;
    [SerializeField] private float damage;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.ApplyDamage(damage, transform.position);
            Destroy(gameObject);
        }
    }
}
