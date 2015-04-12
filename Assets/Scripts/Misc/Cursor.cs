using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour {

    public void Move(float x, float y)
    {
        transform.position = new Vector2(transform.position.x + x, transform.position.y + y);
    }
}
