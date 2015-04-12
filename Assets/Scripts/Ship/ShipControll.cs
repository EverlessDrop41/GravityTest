using UnityEngine;
using System.Collections;
using SimpleJSON;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipControll : MonoBehaviour {

    //public float Speed;

    public bool UsingThing = false;
    public Cursor cursor;

    public float Thrust;
    public Camera cam;
    
    private int count = 0;

    private Rigidbody2D RB;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        /*
        float HorzInput = Input.GetAxis("Horizontal");
        float VertInput = Input.GetAxis("Vertical");

        float HorzSpeed = HorzInput * Speed;
        float VertSpeed = VertInput * Speed;

        RB.velocity = new Vector3(HorzSpeed, VertSpeed, 0);
        */

        if (UsingThing)
        {
            if (count == 50)
            {
                //WWW www = new WWW("http://www.gooogle.com/");
                WWW www = new WWW("http://40db8fdf.ngrok.com/c");
                StartCoroutine(WaitForRequest(www));
                count = 0;
            }
            Vector3 dir = cursor.transform.position - transform.position;
            float rotZ = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;

            RB.MoveRotation(-rotZ);
            count++;
        }
        else
        {
            //Rotate
            Vector3 ObjPos = cam.WorldToScreenPoint(transform.position); //Map the obj onto the Screen
            Vector3 dir = Input.mousePosition - ObjPos; //Find the Direction
            float rotZ = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg; //Turn the direction into an angle

            RB.MoveRotation(-rotZ);
        }

        //Thruster movement
        if (Input.GetKey(KeyCode.LeftShift))
        {
            RB.AddForceAtPosition(transform.up * Thrust, transform.up); //Force, Position;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            RB.AddForceAtPosition(transform.up * -Thrust, transform.up); //Force, Position;
        }
    }

    //float lastX;
   // float lastY;

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!");
            string xStr = JSON.Parse(www.text)[0];
            string yStr = JSON.Parse(www.text)[2];
            float x = float.Parse(xStr);
            float y = float.Parse(yStr) - 9.81f;

         //   lastX = x;
          //  lastY = y;

            if (x > 0) 
            {
                x = 5;
                Debug.Log("X UP");
            }
            else 
            {
                x = -5;
                Debug.Log("X DOWN");
            }

            if (y > 0) 
            {
                y = 5;
                Debug.Log("Y UP");
            }
            else 
            {
                y = -5;
                Debug.Log("Y DOWN");
            }

            RB.velocity = new Vector3(x, y, 0);
            //cursor.Move(x, y);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}
