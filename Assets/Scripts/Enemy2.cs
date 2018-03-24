using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Enemy2 : EnemyBehaviour {

    //private AudioSource enemyAudio;

	// Use this for initialization
	void Start () {
        //enemyAudio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
       // PlaySound();
        DestroyEnemy();
        
	}

    void FixedUpdate()
    {
        MoveDown();
    }

    public void AddHealth(int bonus)
    {
        health += bonus;
    }

   /* public override void PlaySound()
    {

        if(health == 0 && !enemyAudio.isPlaying)
        enemyAudio.PlayOneShot(enemySound, 0.3f);
       
    } */

}
