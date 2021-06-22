using System;
using TMPro;
using UnityEngine;

public class LoseMessageUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI[] otherUItextElements;
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnPlayerDeath()
    {
        int kills = FindObjectOfType<KilledZombiesUI>().KilledZombies;
        SetPlayerScoreMessage(kills);
        DeactivateOtherUI();
        animator.SetTrigger("PlayerDied");
    }

    private void DeactivateOtherUI()
    {
        foreach (var element in otherUItextElements)
        {
            element.gameObject.SetActive(false);
        }
    }

    private void SetPlayerScoreMessage(int kills)
    {
        string scoreMessage = String.Format("YOU KILLED {0} ZOMBIES", kills);
        scoreText.text = scoreMessage;
    }
}
