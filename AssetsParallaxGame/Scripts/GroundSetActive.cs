using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSetActive : MonoBehaviour
{

    [SerializeField] private BoxCollider2D ground;
    [SerializeField] private PlayerMovement player;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (ground.enabled)
            {
                ground.enabled = false;

                player.isFar = false;
                player.isNear = true;
            }
            else
            {
                ground.enabled = true;

                player.isNear = false;
                player.isFar = true;
            }
        }
    }

}
