using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

    string powerUpName = "";
    Color shapeColor = new Color(Random.value, Random.value, Random.value);
	// Update is called once per frame
	void Update () {
	    //glowing animation
	}

    void Start()
    {
        this.GetComponent<SpriteRenderer>().color = shapeColor;
    }

    void OnCollisionEnter2D(Collision2D coli)
    {
        if (coli.gameObject.CompareTag("Player"))
        {
            coli.gameObject.GetComponent<Flick>().RecievePowerUp(powerUpName);
            Destroy(gameObject);
        }
    }
}
