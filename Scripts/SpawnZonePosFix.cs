using UnityEngine;
using System.Collections;

public class SpawnZonePosFix : MonoBehaviour {

    public Transform playerT;
	// Update is called once per frame
    void Start()
    {
        
    }

	void Update () {
        transform.position = new Vector3(0, playerT.position.y + 22, 0);
	}
}
