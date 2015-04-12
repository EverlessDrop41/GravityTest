using UnityEngine;
using System.Collections;

public class GravityField : MonoBehaviour {

    public float Radius;
    public float Strength;

    public bool Draw = true;

    public LayerMask layersToCatch;

    public void FixedUpdate()
    {
        Collider2D[] SurroundingBodies = Physics2D.OverlapCircleAll(transform.position, Radius, layersToCatch);

        foreach (Collider2D coll in SurroundingBodies)
        {
            Rigidbody2D objRb = coll.gameObject.GetComponent<Rigidbody2D>();
            Vector2 dir = transform.position - objRb.gameObject.transform.position;

            objRb.AddForce(dir * Strength);
        }

        if (Draw)
            DrawCircle(GetComponent<LineRenderer>());
    }

    void DrawCircle(LineRenderer lr)
    {
        // Calculate each point (theta) in the circle
        // And set its position in the LineRenderer
        int i = 0;
        for (float theta = 0f; theta < (2 * Mathf.PI); theta += 0.1f)
        {
            // Calculate position of point
            float x = (Radius) * Mathf.Cos(theta);
            float y = (Radius) * Mathf.Sin(theta);

            // Set the position of this point
            Vector3 pos = new Vector3(x, y, -1);
            lr.SetPosition(i, pos);
            i++;
        }
    }

}
