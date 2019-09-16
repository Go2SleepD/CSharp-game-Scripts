using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragAndDrop : MonoBehaviour
{
    bool MoveAllowed;
    Collider2D col;

    public GameObject selectionEffect;
    public GameObject deathEffect;

    private Menu m;

    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        m = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);        //puts toch in touch var. 0 stores 1st touch
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);     //needs to convert pixls position to UNITY position

            if(touch.phase == TouchPhase.Began)     //finger touches the screen
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if (col == touchedCollider)     //check toucj on obj's collider
                {
                    source.Play();
                    Instantiate(selectionEffect, transform.position, Quaternion.identity);
                    MoveAllowed = true;     //allows to move obj
                }
            }

            if (touch.phase == TouchPhase.Moved)        //finger move on screen
            {
                if(MoveAllowed)
                {
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                }
            }

            if (touch.phase == TouchPhase.Ended)        //finger off the screen
            {
                MoveAllowed = false;
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Planets")
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            m.GameOver();
        }
    }

}
