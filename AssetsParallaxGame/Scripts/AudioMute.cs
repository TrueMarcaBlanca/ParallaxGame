using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMute : MonoBehaviour
{
    [SerializeField] private AudioSource playerSource;
    public bool changeMute;

    // Start is called before the first frame update
    void Start()
    {
        playerSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (changeMute)
        {
            playerSource.mute = !playerSource.mute;
            changeMute = false;
        }
    }
}
