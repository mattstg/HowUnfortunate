using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
    //andoird fix Input.GetTouch(0).position.
    Vector2 mousePosition = new Vector2(0,0);
    public Camera camera;
    public Vector3 cameraFix = new Vector2(0,3.8f);

	public Flick player;
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0)) 
        {
            Debug.Log("Mouse Position: " + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position));
            mousePosition = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position);
        }
        if (Input.GetMouseButtonUp(0))
            RaiseMouse();
        
	}

    void RaiseMouse()
    {
        Debug.Log("THIS");
        Debug.Log(player.isDragging);
        if (player.isDragging)
        {
            player.LaunchCheck(mousePosition);
            player.isDragging = false;
        }
    }
}
