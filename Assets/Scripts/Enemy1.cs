using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Enemy1 : EnemyBehaviour {

   // private AudioSource enemyAudio;

    // Use this for initialization
    void Start () {
       // enemyAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        
        DestroyEnemy();

	}

   

    void FixedUpdate()
    {
        MoveDown();
       
    }
    /*
    public override void PlaySound()
    {
       /* if (health == 0)
        {
            enemyAudio.PlayOneShot(enemySound, 0.5f);
        }
       
    }*/

}
