using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 12f;
    public Transform lPos, rPos;

    void Start()
    {

    }
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        if (transform.position.x > rPos.position.x)
        {
            speed = -12;
        }
        else if (transform.position.x < lPos.position.x)
        {
            speed = +12;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(lPos.position, rPos.position);
    }
}
