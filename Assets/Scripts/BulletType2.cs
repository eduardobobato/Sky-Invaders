using UnityEngine;
using System.Collections;

public class BulletType2 : BulletBehaviour {

    // 1º passo: declaração das variáveis
    private Vector3 theScale; // a escala da bullet
    private float currentTime = 0; // contador de tempo decorrido

    private float offsetX;


    // Use this for initialization
    void Start(){

        // 2º Passo: capturar a escala local da bullet:
        theScale = transform.localScale;
        speed /= 2; // speed = speed / 2;
    }
	
	// Update is called once per frame
	void Update () {
        // 3º passo: chamar método que destroi a bullet
        DestroyBullet();

        // 6º passo: alterar continuamente o valor do contador:
        currentTime += Time.deltaTime;
    }

    void FixedUpdate()
    {
        // 4º Passo: chamar método que movimenta a bullet
        Move();

        //  7º passo: chamar o método que altera a escala da bullet
        ChangeScale();
    }

    // 5º passo: criar método para alterar a escala da bullet:
    void ChangeScale()
    {
        if (currentTime > 1)
        {
            // altera a escala em x e y do theScale
            theScale.x *= 2f;
            theScale.y *= 1.5f;


            offsetX = theScale.x / 2;
            //ransform.position = new Vector2((transform.position.x - offsetX), 
              //                                transform.position.y);

            // atribui theScale como novo valor para o localScale:
            transform.localScale = theScale;

            // zerar o contador
            currentTime = 0;

        }
    }
        

}
