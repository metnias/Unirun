using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Handler : MonoBehaviour
{
    public int score = 1;
    private bool stepped = false;
    public GameObject[] hazards;

    private void OnEnable()
    {
        stepped = false;
        int c = hazards.Length / 2;
        for (int i = 0; i < hazards.Length; i++)
        {
            if (Random.value < 0.3f && c > 0)
            {
                hazards[i].SetActive(true);
                c--;
            }
            else hazards[i].SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (stepped) return;
        stepped = true;
        GameManager.Instance().AddScore(score);
    }
}
