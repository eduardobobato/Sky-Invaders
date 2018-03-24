using UnityEngine;
using System.Collections;

public class BulletType3 : BulletBehaviour {

    public float speedUp = 0.02f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DestroyBullet();
        speed += speedUp;
    }

    void FixedUpdate()
    {
        Move();
    }
}
