using UnityEngine;
using System.Collections;

// adiciona o componente solicitado ao gameobject onde este script
// sera adicionado
[RequireComponent(typeof(AudioSource))]
public class PlayerBehaviour : MonoBehaviour {

	// 1º Passo: declaração das variáveis e atributos:

	// Variáveis de movimentação [1º grupo de variáveis]:
	public float speed; // determina a velocidade de deslocamento
	private float direction; // irá capturar a direção de deslocamento

	// Variáveis de disparo [2º grupo de variáveis]
	public GameObject[] bullets; // a bullet que será disparada
	public Transform spawnPoint; // o ponto de origem da bullet
    public SpriteRenderer playerSprite;
    public Sprite[] naveSprite;

	// variáveis para controlar a cadência de tiro (fireRate) [3º grupo de variáveis]:
	private float fireRate = 0.3f; // taxa de disparo (determina o tempo entre um disparo e outro)
	private float currentTime; // contador que irá contar o tempo decorrente entre um disparo e outro

	// variáveis para trabalhar com os sons [4º grupo de cariáveis]:
	public AudioClip[] shotSounds; // som do disparo do tiro pricipal
	private AudioSource playerAudio; // gerenciador de audio

    private int index = 0; // corresponde ao indice dos arrays:

    
	// Use this for initialization
	void Start () {
	
		// inicializar componentes:
		currentTime = 0;
		// capturar os componentes necessários:
		playerAudio = GetComponent<AudioSource>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
	
		// 6º Passo: incrementar o valor de 'currentTime':
		currentTime += Time.deltaTime;

        // chama método que troca o tipo do tiro:
        SwitchBullets();
        playerSprite.sprite = naveSprite[index];
	}

	// 3º Passo: chamar o FixedUpdate
	void FixedUpdate(){

		// 4º Passo: chamar os métodos necessários:

		// método Move (movimenta o player): [1ª método criado]
		Move();

		// método Fire (dispara a bullet): [2º método criado]
		Fire();


	}

	// 2º Passo: criar método responsável por movimentar o player:
	void Move(){

		// capturar a direção de deslocamento:
		direction = Input.GetAxis("Horizontal");

		// movimentar o player:
		transform.Translate(new Vector2(direction, 0) * speed * Time.deltaTime);

	}

	// 5º Passo: criar o método de disparo:
	void Fire(){

		// se for pressionada a tecla espaço E o tempo decorrido for maior que o fire rate:
		if(Input.GetKey(KeyCode.Space) && currentTime > fireRate){

			// instancia objeto 'bullet' no jogo
			// Instanciar (objeto, neste ponto de origem, com a rotação do proprio objeto)
			Instantiate(bullets[index], spawnPoint.position, bullets[index].transform.rotation);

			// cada vez que for disparado uma bullet, o currentTime é zerado:
			currentTime = 0;

			// 8º Passo: reproduzir o som de disparo:
			playerAudio.PlayOneShot(shotSounds[index], 0.4f);

		}

	}// fim Fire

    // método para trocar o tipo de tiro:
    void SwitchBullets()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            index = 0; // primeiro indice do array
            // Neste projeto, o GO presente neste indice é
            // o BulletType1
            //playerSprite.sprite = Nave_0;
            fireRate = 0.3f;

        }else if (Input.GetKeyDown(KeyCode.E))
        {
            index = 1; // psegundo indice do array
            // Neste projeto, o GO presente neste indice é
            // o BulletType2
            fireRate = 0.7f;
        }else if (Input.GetKeyDown(KeyCode.W))
        {
            index = 2;
            fireRate = 0.05f;
        }
    }

    

}
