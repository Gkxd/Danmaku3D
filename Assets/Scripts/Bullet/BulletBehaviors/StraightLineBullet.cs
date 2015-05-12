using UnityEngine;
using System.Collections;

public class StraightLineBullet : _BulletUpdate {
    public float velocity;
    public float acceleration;

    protected override void initBullet() {
        rigidbody.velocity = velocity * direction;
        
        reorientBullet(direction);
    }

    protected override void moveBullet() {
        rigidbody.velocity += acceleration * direction * Time.deltaTime;
        
        reorientBullet(direction);
    }
}
