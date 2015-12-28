using UnityEngine;
using System.Collections;

public class CameraRotationFix : MonoBehaviour {
    public Transform playerTrans;
	void Update () {
        transform.position = playerTrans.position + new Vector3(0,0,-1);
	}
}
