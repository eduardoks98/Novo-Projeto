using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DayNightCycle : MonoBehaviour
{
    public float dayLength = 10.0f;
    public float nightLength = 10.0f;
    public Color manhaColor = new Color(1.0f, 1.0f, 1.0f);
    public Color diaColor = new Color(0.25f, 0.25f, 0.6f);
    public Color noiteColor = new Color(1.0f, 1.0f, 1.0f);
    public Color madrugadaColor = new Color(1.0f, 1.0f, 1.0f);
    public Light2D light2D;
    public bool daytime { get; private set; }
    public float timeRemaining;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (daytime)
        {
            if (timeRemaining < (dayLength / 2))
            {
                light2D.color = diaColor;
            }
        }
        else
        {
            if (timeRemaining < (nightLength / 2))
            {
                light2D.color = madrugadaColor;
            }
        }
        if (timeRemaining <= 0)
        {
            daytime = !daytime;
            if (daytime)
            {
                
                light2D.color = manhaColor;
                timeRemaining = dayLength;
            }
            else
            {
               
                light2D.color = noiteColor;
                timeRemaining = nightLength;
            }
        }
    }
}
