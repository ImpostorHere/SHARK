using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState CurrentGameState;
    public int Score;

    [Header("Game UI")]
    public TextMeshProUGUI ScoreText;
    public Slider HpBar;

    [Header("Game Start UI")]
    public TextMeshProUGUI StartText;

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
    }
    void OnEatenHandler()
    {
        Score++;
        ScoreText.text = "Score :" + Score.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        ScoreText.text = "Score :" + Score.ToString();
        UpdateGameState(GameState.Start);
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
            FishCloner.Instance.CloneFish();
            BombCloner.Instance.CloneBomb();
        }
    }
    IEnumerator DelayToGameplayCo()
    {
        yield return new WaitForSeconds(2f);
        UpdateGameState(GameState.GamePlay);
    }

    /// <summary>
    /// Update tampilan HP Bar berdasarkan value dari Player HP
    /// </summary>
    /// <param name="currentHp"></param>
    /// <param name="maxHp"></param>
    public void UpdateHpBarUI(int currentHp, int maxHp)
    {
        HpBar.value = (float)currentHp / (float)maxHp;
    }
}
public enum GameState
{
    none,Start,GamePlay,GameEnd,Result
}
