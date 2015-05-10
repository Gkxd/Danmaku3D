using UnityEngine;
using System.Collections;

public abstract class _DirectionalBulletBehavior : _BulletBehavior {
    protected Vector3 direction;

    public _DirectionalBulletBehavior(Vector3 p, Vector3 d) : base(p) {
        direction = d;
    }

    public void setDirection(Vector3 d) {
        direction = d;
    }
}