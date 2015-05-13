using UnityEngine;
using System.Collections;

public class ButterflyBob : MonoBehaviour {

    void Update () {
        float bobHeight = Mathf.Sin(Time.time * 6);
        transform.localPosition = Vector3.up * -0.2f * bobHeight;
    }
}
