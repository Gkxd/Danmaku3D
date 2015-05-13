using UnityEngine;
using System.Collections;

public class ButterflyWingAnimation : MonoBehaviour {
	
    public bool reverse;

	void Update () {
        float wingAngle = Mathf.Sin(Time.time * 6) * (reverse ? -1 : 1);
        transform.localEulerAngles = Vector3.forward * 30 * wingAngle;
	}
}
