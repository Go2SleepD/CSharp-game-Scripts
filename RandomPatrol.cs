using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPatrol : MonoBehaviour
{
    public float minX;      //min X coordinate in which obj can move
    public float maxX;      //max X coordinate in which obj can move
    public float minY;      //min Y coordinate in which obj can move
    public float maxY;      //max Y coordinate in which obj can move
    float speed;        //speed of motion
    public float secoundsToMaxDif;      //var to set sec to max difficulty

    Vector2 targetPosition;
    public float minSpeed;
    public float maxSpeed;
    

    void Start()
    {
        targetPosition = GetRandomPosition();       //random target to move from begin
    }

    void Update()
    {
        if ((Vector2)transform.position != targetPosition)      //check where is obj right now
        {
            speed = Mathf.Lerp(minSpeed, maxSpeed, GetDificulty());     //mathf.learp( min Value, max Value, percent) set speed, which changes by difficulty
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);       //move to target's coordinates
        }
        else
        {
            targetPosition = GetRandomPosition();       //if obj n pos - set new pos. 
        }
    }
    Vector2 GetRandomPosition()     //method to set random position on coordinates
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);
    }

    float GetDificulty()        //method to grow dif
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secoundsToMaxDif);
    }

    
}
