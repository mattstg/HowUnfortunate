using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class Flick : MonoBehaviour {

    public string activePowerUp = "";
    public bool isDragging = false;
    float timeMouseHeldDown = 0;
    public GameObject gameObject;
    const float nanobots = 1f;
    public float bonusFlickForce = 0;
    public float maxForceMagnitude { get { return GV.MAX_FLICK_FORCE + bonusFlickForce; } }
    bool canLaunch = false;
    float numberOfColis = 0;
    float remainingAirJumps = 0;
    float maxAirJumps = 1;
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

    public void LaunchCheck(Vector2 launchPos)
    {
        if (numberOfColis > 0)
        {
            Launch(launchPos);
        } else if (remainingAirJumps > 0) {
            --remainingAirJumps;
            Launch(launchPos);
        }
        
        timeMouseHeldDown = 0;
        isDragging = false;
        
    }

    void Launch(Vector2 launchPos)
    {
        if (timeMouseHeldDown != 0)
        {
            Vector2 launchVelo = nanobots * ((launchPos - new Vector2(0, 0)) / timeMouseHeldDown);
            if (Mathf.Abs(launchVelo.magnitude) > maxForceMagnitude)
                launchVelo = launchVelo.normalized * maxForceMagnitude;
            gameObject.GetComponent<Rigidbody2D>().AddForce(launchVelo, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D coli)
    {
        if (coli.gameObject.CompareTag("Box"))
        {
            remainingAirJumps = maxAirJumps;
            numberOfColis++;
        }
            
    }

    void OnCollisionExit2D(Collision2D coli)
    {
        if (coli.gameObject.CompareTag("Box"))
            numberOfColis--;
    }

    public void RecievePowerUp(string powerUpName)
    {
        activePowerUp = powerUpName;
    }


}
