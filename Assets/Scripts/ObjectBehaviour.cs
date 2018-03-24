using UnityEngine;
using System.Collections;

public class ObjectBehaviour : MonoBehaviour {

    private Vector3 theScale; // armazenará a escala do objeto
    private float scaleY; // o valor da escala do eixo Y
    public int health; // total de vida do objeto

	// Use this for initialization
	void Start () {

        // captura a escala do objeto;
        theScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
	    // se a 'vida' do objeto for igual a zero:
        if(health == 0)
        {
            // o objeto é destruído
            Destroy(gameObject);
        }

        // capturar a escala em y do objeto:
        scaleY = transform.localScale.y;
       

	}

    // aplicar dano ao objeto:
    void ApplyDamage(int damage)
    {
        // subtrai o valor de 'damage' da 'vida' do objeto:
        health -= damage;

        if(transform.localScale.y > 0.3)
        {
            // alterar o valor de 'scaleY', subtraindo 0.3f do 
            // seu valor (seja ele qual for)
            scaleY -= 0.3f;
            // atribuir novo valor para a variavel 'theScale';
            theScale = new Vector3(transform.localScale.x,
                                   scaleY,
                                   transform.localScale.z);

            // atribuir a escala do objeto o valor de 'theScale'
            transform.localScale = theScale;
        }

        // se a 'vida' do objeto se tornar negativa:
        if (health < 0)
        {
            health = 0; // zera a vida, para evitar problemas...
        }
    }
}
