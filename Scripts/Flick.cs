using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class Flick : MonoBehaviour {

    public bool isDragging = false;
    float timeMouseHeldDown = 0;
    public GameObject gameObject;
    const float nanobots = 1f;
    bool canLaunch = false;
    float numberOfColis = 0;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
       // if(timeMouseHeldDown != 0)
           // Debug.Log("Timer: " + timeMouseHeldDown);
        if (isDragging)
            timeMouseHeldDown += Time.deltaTime;
        else
            timeMouseHeldDown = 0; 
	}

    void OnMouseDown()
    {
        isDragging = true;
    }

    public void Launch(Vector2 launchPos)
    {
        if (numberOfColis > 0)
        {
            if (timeMouseHeldDown != 0)
                gameObject.GetComponent<Rigidbody2D>().AddForce(nanobots * ((launchPos - new Vector2(0, 0)) / timeMouseHeldDown), ForceMode2D.Impulse);
        }
        else
        {
            timeMouseHeldDown = 0;
            isDragging = false;
        }
        
    }

    void OnCollisionEnter2D(Collision2D coli)
    {
        if (coli.gameObject.CompareTag("Box"))
            numberOfColis++;
            
    }

    void OnCollisionExit2D(Collision2D coli)
    {
        if (coli.gameObject.CompareTag("Box"))
            numberOfColis--;
    }


}
