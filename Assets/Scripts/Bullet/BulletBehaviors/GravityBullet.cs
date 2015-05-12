using UnityEngine;
using System.Collections;

public class GravityBullet : _BulletUpdate {
    public float velocity;
    public float acceleration;
    public Vector3 gravityDirection;

    protected override void initBullet() {
        rigidbody.velocity = velocity * direction;
        
        reorientBullet(direction);
    }
    
    protected override void moveBullet() {
        rigidbody.velocity += acceleration * gravityDirection * Time.deltaTime;
        
        reorientBullet(rigidbody.velocity);
    }
}
