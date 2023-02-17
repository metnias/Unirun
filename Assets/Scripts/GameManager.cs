using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance() => instance;
    private static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(gameObject);
    }

    public const string JMP = "Fire1";

    private int score = 0;
    public void AddScore(int bonus)
    {
        if (isGameover) return;
        score += bonus;
        // update score text
    }

    public static bool IsGameover() => instance.isGameover;
    private bool isGameover = false;

    void Update()
    {
        if (isGameover)
        {
            if (Input.GetButtonDown(JMP))
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }
    }

    public void OnPlayerDead()
    {
        isGameover = true;
    }
}
