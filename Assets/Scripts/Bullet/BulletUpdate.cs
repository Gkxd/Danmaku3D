using UnityEngine;
using System.Collections;

public class BulletUpdate : MonoBehaviour {

    private _BulletBehavior behavior;
    private Rigidbody r;
    private GameObject visual;
    
    private bool hasInit, hasDestroy;
    private float totalLifeTime;

    private float delay;
    private float timeExisted = 0;
    private float scaleAmount = 1;

    public void init(_BulletBehavior b, float lifeTime, float delaySeconds) {

        if (!BulletManager.canSpawnBullets()) {
            GameObject.DestroyImmediate(gameObject);
            return;
        }
        
        
        visual = transform.Find("Visual").gameObject;
        visual.SetActive(false);
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        behavior = b;
        delay = Mathf.Max(delaySeconds, 0);

        r = GetComponent<Rigidbody>();
        totalLifeTime = lifeTime + delay;

        BulletManager.bulletCounter++;
    }

    void FixedUpdate() {
        if (!hasDestroy) {
            if (timeExisted > totalLifeTime) {
                hasDestroy = true;
                
                GetComponent<Collider>().enabled = false;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

                BulletManager.bulletCounter--;
            }
            else if (timeExisted > delay) {
                if (!hasInit) {
                    behavior.initBullet(this);
                    hasInit = true;
                    
                    visual.SetActive(true);
                    GetComponent<Collider>().enabled = true;
                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                }
                else {
                    behavior.moveBullet(this, Time.deltaTime);
                    behavior.additionalUpdates(this, Time.deltaTime);
                }
            }
            timeExisted += Time.deltaTime;
        }
    }

    void Update() {
        if (hasDestroy) {
            if (scaleAmount < 0.1f) {
                GameObject.DestroyImmediate(gameObject);
            }
            else {
                scaleAmount = Mathf.Lerp(scaleAmount, 0, 0.2f);
                transform.localScale = new Vector3(1,1,1) * scaleAmount;
            }
        }
    }

    public Rigidbody getRigidBody() {
        return r;
    }
}
