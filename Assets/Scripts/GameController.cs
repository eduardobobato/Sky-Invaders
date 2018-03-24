using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] enemies; // array de inimigos
    public GameObject[] spawnPoints; // pontos de spawn

    public float timeToSpawn = 2;
    private float currentTime = 0;
    private int index;

    public Text healthText;
    public Text scoreText;
    public Text gameOverText;

    private static int playerHealth;
    private static int scorePoints;
    private AudioSource audioSource;


	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawn");
        playerHealth = 100;
        scorePoints = 0;

        gameOverText.gameObject.SetActive(false);
        Time.timeScale = 1; // jogo corre no tempo normal

    }
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        SpawnEnemy();
        SetPlayerHealth();
        SetScorePoints();
        GameOver();
        Restart();
        

    }

    void SpawnEnemy()
    {
        // gerar um valor aleatório para a variavel index:
        index = Random.Range(0, spawnPoints.Length);
        int aux = Random.Range(0, enemies.Length);

        // instanciar um inimigo (inicialmente na posição zero)
        // do array de inimigos:
        if(currentTime > timeToSpawn)
        {
            Instantiate(enemies[aux],
                spawnPoints[index].transform.position,
                enemies[aux].transform.rotation);

            currentTime = 0;
        }
    }

    public static void AddPoints(int points)
    {
        // alterar pontos no placar
        scorePoints += points;
    }

    public static void ApplyDamage(int damage)
    {
        playerHealth -= damage;

        if(playerHealth < 0)
        {
            playerHealth = 0;
        }
    }

    void SetPlayerHealth()
    {
        healthText.text = "Health: " + playerHealth + "%";
    }

    void SetScorePoints()
    {
       
            scoreText.text = "Your Score: " + scorePoints + " pts"; 
        
    }

    void GameOver()
    {
        if (playerHealth == 0)
        {

    
            SetGameOverText();
            gameOverText.gameObject.SetActive(true);
            Time.timeScale = 0; // 'congela' o tempo de jogo
        }
    }

    void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R) && playerHealth == 0)
        {
            SceneManager.LoadScene("Main");
        }
    }

    void SetGameOverText()
    {
        gameOverText.text = "Game Over" +
                            "\nYour Score: " + scorePoints + " pts";
                          
    }
}
