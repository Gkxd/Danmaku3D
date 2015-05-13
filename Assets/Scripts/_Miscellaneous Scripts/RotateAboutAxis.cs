using UnityEngine;
using System.Collections;

public class RotateAboutAxis : MonoBehaviour {

    public Vector3 axis = Vector3.forward;
    public float rotationsPerSecond = 1;

	void Update () {
        transform.localEulerAngles = Vector3.forward * Time.time * 360 * rotationsPerSecond;
	}
}
