using UnityEngine;
using TMPro;

public class Cow : MonoBehaviour
{
    public GameManager gameManager;

    public int player1Hits;
    public int player2Hits;
    public bool cowTaken;

    private TextMeshProUGUI player1Text;
    private TextMeshProUGUI player2Text;

    private Camera player1Camera;
    private Camera player2Camera;

    private const int hitsToWin = 3;

    void Awake()
    {
        AssignTexts();
        AssignCameras();

        if (!gameManager)
            gameManager = FindObjectOfType<GameManager>();

        UpdateCowText();
    }

    void AssignTexts()
    {
        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();

        if (texts.Length < 2)
        {
            Debug.LogWarning("Cow prefab needs 2 TextMeshProUGUI components as children.");
            return;
        }

        player1Text = texts[0];
        player2Text = texts[1];

        player2Text.transform.localScale = new Vector3(-1f, 1f, 1f);
    }

    void AssignCameras()
    {
        Camera[] cameras = Camera.allCameras;

        if (cameras.Length < 2)
        {
            Debug.LogWarning("Need at least two cameras in the scene.");
            return;
        }

        player1Camera = cameras[0];
        player2Camera = cameras[1];
    }

    void OnCollisionEnter(Collision collision)
    {
        if (cowTaken) return;

        if (collision.gameObject.CompareTag("Player1Pizza"))
        {
            player1Hits++;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Player2Pizza"))
        {
            player2Hits++;
            Destroy(collision.gameObject);
        }

        UpdateCowText();

        if (player1Hits >= hitsToWin)
            Win("Player1Pizza");

        if (player2Hits >= hitsToWin)
            Win("Player2Pizza");
    }

    void UpdateCowText()
    {
        if (player1Text)
            player1Text.text = $"Player 1: {player1Hits}";

        if (player2Text)
            player2Text.text = $"Player 2: {player2Hits}";
    }

    void Win(string pizzaTag)
    {
        cowTaken = true;
        gameManager.AddPoint(pizzaTag);
        Destroy(gameObject, 0.5f);
    }

    void Update()
    {
        FaceCamera(player1Text, player1Camera, false);
        FaceCamera(player2Text, player2Camera, true);
    }

    void FaceCamera(TextMeshProUGUI text, Camera cam, bool flip)
    {
        if (!text || !cam) return;

        Vector3 dir = text.transform.position - cam.transform.position;
        text.transform.rotation = Quaternion.LookRotation(dir);

        if (flip)
            text.transform.Rotate(0f, 180f, 0f);
    }
}
