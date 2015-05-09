using UnityEngine;
using System.Collections;

public class BillboardQuad : MonoBehaviour {

    private GameObject mainCamera;

    void Start() {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update() {
        transform.LookAt(mainCamera.transform);
        transform.forward *= -1;
    }
}
