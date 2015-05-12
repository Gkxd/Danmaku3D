using UnityEngine;
using System.Collections;

public abstract class _BulletUpdate : MonoBehaviour {

    protected Rigidbody rigidbody;
    protected Vector3 direction;


    private GameObject parent;
    private GameObject visual;

    private bool hasInit, hasDestroy;
    private float totalLifeTime;
    private float delay;
    private float timeExisted = 0;
    private float scaleAmount = 1;

    public void init(float lifeTime, float delaySeconds) {
        if (transform.parent == null) {
            Debug.LogError("This must be a child of a bullet object");
            Debug.Break();
        }

        parent = transform.parent.gameObject;

        if (!BulletManager.canSpawnBullets()) {
            GameObject.DestroyImmediate(parent);
        }

        visual = transform.parent.Find("Visual").gameObject;

        visual.SetActive(false);
        parent.GetComponent<Collider>().enabled = false;
        parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        delay = Mathf.Max(delaySeconds, 0);

        rigidbody = parent.GetComponent<Rigidbody>();
        totalLifeTime = lifeTime + delay;

        BulletManager.bulletCounter++;
    }

    protected virtual void initBullet() {}
    protected virtual void moveBullet() {}
    protected virtual void additionalUpdates() {}

    void FixedUpdate() {
        if (!hasDestroy) {
            if (timeExisted > totalLifeTime) {
                hasDestroy = true;
                
                parent.GetComponent<Collider>().enabled = false;
                parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

                BulletManager.bulletCounter--;
            }
            else if (timeExisted > delay) {
                if (!hasInit) {
                    initBullet();
                    hasInit = true;
                    
                    visual.SetActive(true);
                    parent.GetComponent<Collider>().enabled = true;
                    parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                }
                else {
                    moveBullet();
                    additionalUpdates();
                }
            }
            timeExisted += Time.deltaTime;
        }
    }

    void Update() {
        if (hasDestroy) {
            if (scaleAmount < 0.1f) {
                GameObject.DestroyImmediate(parent);
            }
            else {
                scaleAmount = Mathf.Lerp(scaleAmount, 0, 0.2f);
                parent.transform.localScale = new Vector3(1,1,1) * scaleAmount;
            }
        }
    }

    protected void reorientBullet(Vector3 direction) {
        Quaternion rotation = new Quaternion();
        
        rotation.SetLookRotation(direction);
        
        rigidbody.rotation = rotation;
    }
    
    public void setDirection(Vector3 d) {
        direction = d;
    }
}
