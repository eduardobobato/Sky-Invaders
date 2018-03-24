using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class ExplosionBehaviour : MonoBehaviour {
    private SpriteRenderer explosion;
	// Use this for initialization
	void Start () {
        explosion = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(explosion.sprite.name == "explosion_32")
        {
            Destroy(gameObject);
        }
	}
}
