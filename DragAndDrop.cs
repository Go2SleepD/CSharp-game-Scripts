using UnityEngine;
using UnityEngine.SceneManagement;      //this lib needs to control scenes

public class DragAndDrop : MonoBehaviour
{
    bool MoveAllowed;          //check to allow to move planets
    Collider2D col;

    public GameObject selectionEffect;      
    public GameObject deathEffect;

    private Menu m;

    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        m = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();      //finds Menu
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);        //puts toch in touch var. 0 stores 1st touch
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);     //needs to convert pixls position of screen to UNITY position coordinates

            if(touch.phase == TouchPhase.Began)     //finger touches the screen
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if (col == touchedCollider)     //check touch on obj's collider
                {
                    source.Play();      //play selection sound
                    Instantiate(selectionEffect, transform.position, Quaternion.identity);      //adds first touch (select) effect
                    MoveAllowed = true;     //allows to move obj
                }
            }

            if (touch.phase == TouchPhase.Moved)        //finger move on screen
            {
                if(MoveAllowed)
                {
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);     //change position on where is finger right now
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
        if (collision.tag == "Planets")     //check if planets collide this each over
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);      //adds death effect 
            m.GameOver();       //loads GameOver method from Menu script
        }
    }

}
