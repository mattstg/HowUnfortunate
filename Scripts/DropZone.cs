using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DropZone : MonoBehaviour {

    
    public List<GameObject> ShapePrefab;
	// Update is called once per frame
    float timer = 0;
    bool created = false;

	void Update () {
        timer += Time.deltaTime;
        if (timer > GV.BOX_CREATE_TIME)
        {
            Quaternion quat = new Quaternion(0, 0, Random.Range(-10, 10),0);
            GameObject temp = Instantiate(RetrieveRandomShape(), new Vector3(Random.Range(-5, 5), transform.position.y, 0), quat) as GameObject;
            temp.transform.localScale = new Vector3(Random.Range(GV.BOX_SIZE_SMALLEST, GV.BOX_SIZE_LARGEST), Random.Range(GV.BOX_SIZE_SMALLEST, GV.BOX_SIZE_LARGEST), 0);
            temp.GetComponent<Rigidbody2D>().mass = Random.Range(1, 100);
            timer = 0;
            if (Random.Range(0, 1f) < GV.POWER_UP_DROP_CHANCE)
                AttachPowerUp(temp);
        }
            
	}

    private GameObject RetrieveRandomShape()
    {
        return ShapePrefab[Random.Range(0, (int)ShapePrefab.Count)];
    }

    private void AttachPowerUp(GameObject fallingShape)
    {
        fallingShape.AddComponent<PowerUp>();
    }
}
