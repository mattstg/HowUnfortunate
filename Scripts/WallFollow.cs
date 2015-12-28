using UnityEngine;
using System.Collections;

public class WallFollow : MonoBehaviour {
    //I know all these follow scripts coulda be generic, so sue me
    public Transform playerT;
    const float WALL_FOLLOW_MAX = 80f;
	// Update is called once per frame
	void Update () {
        if (transform.position.y < WALL_FOLLOW_MAX)
            transform.position = new Vector3(transform.position.x, playerT.position.y, 0);
	}
}
