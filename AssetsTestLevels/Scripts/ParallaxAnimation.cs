using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxAnimation : MonoBehaviour
{
    [SerializeField] private Vector2 speed;

    private Vector2 offset;

    private Material material;

    private Rigidbody2D player;

    // Start is called before the first frame update
    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        offset = (player.velocity.x * 0.1f) * speed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
