using UnityEngine;
using System.Collections;

public class BulletManager : MonoBehaviour {

    public static GameObject bullet00;

    public static int bulletCounter;

    void Start() {
        bullet00 = Resources.Load<GameObject>("Prefabs/Bullets/Bullet00");
    }

    void Update() {
        Debug.Log(bulletCounter);
    }


    public static bool canSpawnBullets() {
        return bulletCounter < 1000;
    }
}
