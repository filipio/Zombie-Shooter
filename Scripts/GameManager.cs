using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private SimpleAudioEvent loseSound;
    [SerializeField]
    private CameraController cameraController;
    [SerializeField]
    private LoseMessageUI loseMessageUI;

    private void Awake()
    {
        FindObjectOfType<KilledZombiesUI>().PlayerKilledAllZombies += PlayerWon;
        FindObjectOfType<PlayerMovement>().GetComponent<Health>().OnDied += PlayerLost;
    }

    private void PlayerWon()
    {
        Debug.Log("YOU WON!");
    }

    private void PlayerLost()
    {
        loseSound.Play(GetComponent<AudioSource>());
        cameraController.OnPlayerDeath();
        loseMessageUI.OnPlayerDeath();
    }
}
