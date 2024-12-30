using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorSprite :MonoBehaviour
{
    

 
    public Color colorA = Color.red;
    public Color colorB = Color.blue;
    public float firerate = 1.1f;
    float nextfire = 0.0f;

    bool toggle = false;

    bool discolight = false;
     private SpriteRenderer sprite;
   public float Timing = 0f;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
       
    }

    void Update()
    {
       
        if (Timing > 0)
        {
            if (discolight && Time.time > nextfire)
            {

                toggle = !toggle; // flip toggle between true and false
                sprite.color = toggle ? colorB : colorA; // if toggle is true, use colorB
                nextfire = Time.time + firerate;
            }
            Timing -= Time.deltaTime;
        }
        else
        {
            if (Timing <= 0)
            {
                
                discolight = false;
            }
            
        }

    }


    public void StartDiscolight(float timer, SpriteRenderer sr, Color color1, Color color2, float changeRate)
    {
        sprite = sr;
        discolight = true;
        Timing = timer;
        colorA = color1;
        colorB = color2;
        firerate = changeRate;
    }

    public void StopDiscolight()
    {
        Timing = 0f;
        sprite.color = Color.white;
    }
}

