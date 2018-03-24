using UnityEngine;
using System.Collections;

public class Enemy3 : EnemyBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    void Update()
    {
        DestroyEnemy();
    }



    void FixedUpdate()
    {
        MoveDown();

    }
}
