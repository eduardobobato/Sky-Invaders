using UnityEngine;
using System.Collections;


public abstract class EnemyBehaviour : MonoBehaviour {

    public int health = 10; // a 'vida' do inimigo
    public int bonusHealth; // o bonus de vida do inimigo
    public int damage = 10; // quanto de dano que este inimigo irá causar
    public float speed; // velocidade de deslocamento do inimigo
    public int scorePoints; // quantos pontos este inimigo dará ao ser morto
    public AudioClip enemySound;
    private Vector2 finalPos;
    public GameObject explosion;

	public void ApplyDamage(int damage)
    {
        health -= damage; 

        if (health < 0)
        {
            health = 0;
        }
    }

    public void DestroyEnemy()
    {
        if (health == 0)
        {
           
            GameController.AddPoints(scorePoints);
            //GameController.PlayenemyAudio(enemySound);
            Instantiate(explosion, gameObject.transform.position,explosion.transform.rotation);
            Destroy(gameObject);
            
        }
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Shield")
        {
            coll.gameObject.SendMessage("ApplyDamage", damage,
            SendMessageOptions.DontRequireReceiver);
            Instantiate(explosion, gameObject.transform.position, explosion.transform.rotation);
            Destroy(gameObject);
        }
        else if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.SendMessage("AddHealth", bonusHealth,
            SendMessageOptions.DontRequireReceiver);
        }
        else if (coll.gameObject.tag == "Ground" ||
                 coll.gameObject.tag == "Player")
        {
            GameController.ApplyDamage(damage);
            Instantiate(explosion, gameObject.transform.position, explosion.transform.rotation);
            Destroy(gameObject);
        }

    }


    public void MoveDown()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    


}
