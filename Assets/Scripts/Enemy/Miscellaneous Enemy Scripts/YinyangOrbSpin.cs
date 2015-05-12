using UnityEngine;
using System.Collections;

public class YinyangOrbSpin : MonoBehaviour {
	void Update () {
        transform.localEulerAngles = Vector3.forward * Time.time * -327.53f;
	}
}
