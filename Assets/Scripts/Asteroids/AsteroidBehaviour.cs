using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class AsteroidBehaviour : MonoBehaviour {

    public Transform Target;
    public float Speed = 5;

    private Rigidbody2D RB;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();

        Vector3 dir = Target.position - transform.position; //Find the Direction
        float rotZ = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg; //Turn the direction into an angle

        RB.MoveRotation(-rotZ);

        RB.AddForceAtPosition(transform.up * Speed, transform.up); 
    }

    void Update()
    {
        RB.AddForceAtPosition(transform.up * Speed, transform.up);
    }
}
