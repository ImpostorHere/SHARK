using System.Collections;
using System.Collections.Generic;

using System;
using UnityEngine;

using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState CurrentGameState;
    public int Score;

    [Header("Game UI")]
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HiScoreText;
    public Slider HpBar;
    public TextMeshProUGUI HpText;

    [Header("Game Start UI")]
    public TextMeshProUGUI StartText;

    [Header("Game Over UI")]
    public GameObject LosePanel;
    public TextMeshProUGUI FinalScoreText;
    public string LoseMessage = "Your score is : ";
    public const string HI_SCORE_KEY = "Highscore";
    public int HighScore
    {
        get
        {
            return PlayerPrefs.GetInt(HI_SCORE_KEY);
        }
        set
        {
            PlayerPrefs.SetInt(HI_SCORE_KEY, value);
        }
    }

    //StartScreenManager

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
        FoodController.OnEaten += OnEatenHandler;
        PlayerController.OnDie += LoseState;

        if(PlayerPrefs.HasKey(HI_SCORE_KEY) == false)
        {
            HighScore = 0;
        }
    }

    private void OnDestroy()
    {
        FoodController.OnEaten -= OnEatenHandler;
        PlayerController.OnDie -= LoseState;
    }

    void OnEatenHandler()
    {
        Score++;
        ScoreText.text = "Score :" + Score.ToString();
        if(Score > HighScore)
        {
            HighScore = Score;
        }
        HiScoreText.text = "Highscore :" + HighScore.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        ScoreText.text = "Score :" + Score.ToString();
        HiScoreText.text = "Highscore:" + HighScore.ToString();
        UpdateGameState(GameState.Start);
        LosePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateGameState(GameState newState)
    {
        CurrentGameState = newState;

        if (CurrentGameState == GameState.Start)
        {
            StartText.gameObject.SetActive(true);
            StartCoroutine(DelayToGameplayCo());
        }
        else if (CurrentGameState == GameState.GamePlay)
        {
            StartText.gameObject.SetActive(false);
            FishCloner.Instance.CloneObject();
            BombCloner.Instance.CloneObject();
        }
        else if (CurrentGameState == GameState.GameEnd)
        {
            LosePanel.SetActive(true);

            FinalScoreText.text = LoseMessage + Score.ToString();

            StartText.gameObject.SetActive(false);
            ScoreText.gameObject.SetActive(false);

            StartCoroutine(StopForResultCo());
        }
    }
    IEnumerator DelayToGameplayCo()
    {
        yield return new WaitForSeconds(2f);
        UpdateGameState(GameState.GamePlay);
    }
    IEnumerator StopForResultCo()
    {
        yield return new WaitForSeconds(5f);
        UpdateGameState(GameState.Result);
    }

    /// <summary>
    /// Update tampilan HP Bar berdasarkan value dari Player HP
    /// </summary>
    /// <param name="currentHp"></param>
    /// <param name="maxHp"></param>
    public void UpdateHpBarUI(int currentHp, int maxHp)
    {
        HpBar.value = (float)currentHp / (float)maxHp;
        HpText.text = currentHp + " / " + maxHp;
    }
    public void LoseState()
    {
        UpdateGameState(GameState.GameEnd);
    }

    public void OnClick_Menu()
    {
        SceneManager.LoadScene("Start_Screen");
    }

    public void OnClick_Retry()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
public enum GameState
{
    none,Start,GamePlay,GameEnd,Result
}
