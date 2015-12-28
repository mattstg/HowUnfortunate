using UnityEngine;
using System.Collections;

public class DropZone : MonoBehaviour {

    const float BOX_SIZE_SMALLEST = 150f;
    const float BOX_SIZE_LARGEST  = 300f;
    const float BOX_CREATE_TIME = 1f;
    public GameObject boxPrefab;
	// Update is called once per frame
    float timer = 0;
    bool created = false;

	void Update () {
        timer += Time.deltaTime;
        if (timer > BOX_CREATE_TIME)
        {

            Quaternion quat = new Quaternion(0, 0, Random.Range(-10, 10),0);
            GameObject temp = Instantiate(boxPrefab, new Vector3(Random.Range(-5, 5), transform.position.y, 0), quat) as GameObject;
            temp.transform.localScale = new Vector3(Random.Range(BOX_SIZE_SMALLEST, BOX_SIZE_LARGEST), Random.Range(BOX_SIZE_SMALLEST, BOX_SIZE_LARGEST), 0);
           
            temp.GetComponent<Rigidbody2D>().mass = Random.Range(1, 100);
            timer = 0;
        }
            
	}
}
