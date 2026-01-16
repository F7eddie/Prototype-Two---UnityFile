using UnityEngine;
using TMPro;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public GameObject spawnA;
    public GameObject spawnB;
    public GameManager gameManager;

    public TextMeshProUGUI timerText;

    public PlayerOneController player1;
    public PlayerTwoController player2;

    [SerializeField] private float gameTime = 60f;
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private float spawnX = -40f;
    [SerializeField] private int countdownTime = 5;

    private Coroutine spawnCoroutine;

    void Awake()
    {
        if (!gameManager) gameManager = FindObjectOfType<GameManager>();
        if (!player1) player1 = FindObjectOfType<PlayerOneController>();
        if (!player2) player2 = FindObjectOfType<PlayerTwoController>();
    }

    void Start()
    {
        StartCoroutine(GameFlow());
    }

    IEnumerator GameFlow()
    {
        for (int i = countdownTime; i > 0; i--)
        {
            timerText.text = $"Starting in\n{i}";
            yield return new WaitForSeconds(1f);
        }

        timerText.text = $"Time\n{gameTime:00}";

        player1.canMove = true;
        player2.canMove = true;

        spawnCoroutine = StartCoroutine(SpawnAnimals());

        float timeLeft = gameTime;

        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1f);
            timeLeft--;
            timerText.text = $"Time\n{timeLeft:00}";
        }

        EndGame();
    }

    IEnumerator SpawnAnimals()
    {
        while (true)
        {
            SpawnAnimal();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    void SpawnAnimal()
    {
        if (!spawnA || !spawnB || animalPrefabs.Length == 0) return;

        float randomZ = Random.Range(
            spawnA.transform.position.z,
            spawnB.transform.position.z
        );

        Vector3 spawnPos = new Vector3(spawnX, 0f, randomZ);
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Instantiate(
            animalPrefabs[animalIndex],
            spawnPos,
            animalPrefabs[animalIndex].transform.rotation
        );
    }

    void EndGame()
    {
        if (spawnCoroutine != null)
            StopCoroutine(spawnCoroutine);

        timerText.text = "Game\nOver";

        player1.canMove = false;
        player2.canMove = false;

        gameManager.endGame();
    }
}
