using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class TesteBehaviour : MonoBehaviour {

    public float speed;
    public AudioClip sound;
    private AudioSource audioS;
    public int health;
    private bool played = false;


	// Use this for initialization
	void Start () {
        audioS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        Death();
	}

    void FixedUpdate()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void ApplyDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
    }

    void Death()
    {
        if (health == 0)
        {
            if (!played)
            {
                audioS.PlayOneShot(sound, 1);
                played = true;
            }
            Destroy(gameObject, 0.6f);
        }
    }
}
