using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI scoreTxt;
    public GameObject gameOverPannal;
    public TextMeshProUGUI gameOverScoreText;

    int score;
    Player player;

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        PauseGame();
    }

    public void ScoreUp()
    {
        score++;
        scoreTxt.text = score.ToString();
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
        score = 0;
        scoreTxt.text = score.ToString();
        gameOverPannal.SetActive(false);
        scoreTxt.gameObject.SetActive(true);

        // destroy current pillars
        Pillar[] pillars = FindObjectsOfType<Pillar>();
        for (int i = 0; i < pillars.Length; i++)
        {
            Destroy(pillars[i].gameObject);
        }

        // position player
        player.transform.position = Vector3.zero;

    }    

    public void PauseGame()
    {
        gameOverPannal.SetActive(true);
        scoreTxt.gameObject.SetActive(false);
        gameOverScoreText.text = score.ToString();
        Time.timeScale = 0f;
    }
}
