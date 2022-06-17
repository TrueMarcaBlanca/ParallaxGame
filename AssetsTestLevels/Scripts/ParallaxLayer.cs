using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    public float multiplier;
    public bool horizontalOnly;
    public bool infiniteHPosition;
    public bool infiniteVPosition;
    public bool isInfinite;

    public GameObject cam;

    private Vector3 startpos;
    private Vector3 startCamerapos;
    private float length;


    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        startCamerapos = cam.transform.position;

        if (isInfinite)
        {
            length = GetComponent<SpriteRenderer>().bounds.size.x;
        }

        CalculateStartPos();
    }

    void CalculateStartPos()
    {
        float distX = (cam.transform.position.x - transform.position.x) * multiplier;
        float distY = (cam.transform.position.y - transform.position.y) * multiplier;

        Vector3 temp = new Vector3(startpos.x, startpos.y);

        if (infiniteHPosition)
        {
            temp.x = transform.position.x + distX;
        }
        if (infiniteVPosition)
        {
            temp.y = transform.position.y + distY;
        }

        startpos = temp;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = startpos;

        if (horizontalOnly)
        {
            pos.x += multiplier * (cam.transform.position.x - startCamerapos.x);
            pos.z = transform.position.z;
        }
        else
        {
            pos.x += multiplier * (cam.transform.position.x - startCamerapos.x);
            pos.y += multiplier * (cam.transform.position.y - startCamerapos.y);
            pos.z = transform.position.z;
        }


        transform.position = pos;

        if (isInfinite)
        {
            float temp = cam.transform.position.x * (1 - multiplier);

            if (temp > startpos.x + length)
            {
                startpos.x += length;
            }
            else if (temp < startpos.x - length)
            {
                startpos.x -= length;
            }
        }

        //transform.position = new Vector3(startpos.x + (multiplier * cam.transform.position.x), transform.position.y, transform.position.z);
    }
}
