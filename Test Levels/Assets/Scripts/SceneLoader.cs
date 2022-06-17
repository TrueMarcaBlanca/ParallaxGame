using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private string sceneName;
    public Ally ally;
    float time;
    float timeDelay;

    void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;
        time = 0f;
        timeDelay = 2f;
    }

    void Update()
    {
        if (ally.life < 0)
        {
            time = time + 1f * Time.deltaTime;

            if (time > timeDelay)
            {
                if(sceneName == "StaticLevel")
                {
                    time = 0f;
                    SceneManager.LoadScene("AnimationLevel");
                }
                if(sceneName == "AnimationLevel")
                {
                    time = 0f;
                    SceneManager.LoadScene("LayerLevel");
                }
                if(sceneName == "LayerLevel")
                {
                    time = 0f;
                    SceneManager.LoadScene("RasterLevel");
                }
                if(sceneName == "RasterLevel")
                {
                    time = 0f;
                    SceneManager.LoadScene("SpriteLevel");
                }
            }
            
        }
    }

}
