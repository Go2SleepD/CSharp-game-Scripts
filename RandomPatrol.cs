using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPatrol : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    float speed;
    public float secoundsToMaxDif;

    Vector2 targetPosition;
    public float minSpeed;
    public float maxSpeed;
    

    void Start()
    {
        targetPosition = GetRandomPosition();
    }

    void Update()
    {
        if ((Vector2)transform.position != targetPosition)
        {
            speed = Mathf.Lerp(minSpeed, maxSpeed, GetDificulty());     //mathf.learp( min Value, max Value, percent)
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            targetPosition = GetRandomPosition();
        }
    }
    Vector2 GetRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);
    }

    float GetDificulty()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secoundsToMaxDif);
    }

    
}
