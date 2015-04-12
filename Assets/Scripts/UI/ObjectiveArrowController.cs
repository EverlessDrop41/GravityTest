using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectiveArrowController : MonoBehaviour {

    public Transform Objective;
    public RectTransform Arrow;

    public float Xoffset = 50;
    public float Yoffset = 50;

    void Update()
    {
        Vector3 ObjectiveScreenPos = Camera.main.WorldToScreenPoint(Objective.position);

        Vector3 ArrowWorldPos = Camera.main.ScreenToWorldPoint(Arrow.transform.position);

        Vector3 ArrowDirection = Objective.position - transform.position;
        float ArrowAngle = Mathf.Atan2(ArrowDirection.y, ArrowDirection.x) * Mathf.Rad2Deg;

        //Arrow.rotation = Quaternion.Euler(new Vector3(0,0,Mathf.Abs(ArrowAngle))); 
        Arrow.eulerAngles = new Vector3(Arrow.rotation.x, Arrow.rotation.y, ArrowAngle - 90);

        MoveArrowTo(ObjectiveScreenPos);
    }

    public void MoveArrowTo(Vector3 ScreenPosition)
    {
        float xMove = ScreenPosition.x;
        float yMove = ScreenPosition.y;

        if (ScreenPosition.x > Screen.width - Xoffset)
        {
            xMove = Screen.width - Xoffset;
        }
        else if (ScreenPosition.x < Xoffset)
        {
            xMove = Xoffset;
        }

        if (ScreenPosition.y > Screen.height - Yoffset)
        {
            yMove = Screen.height - Yoffset;
        }
        else if (ScreenPosition.y < Yoffset)
        {
            yMove = Yoffset;
        }

        Arrow.position = new Vector3(xMove, yMove);
    }
}
