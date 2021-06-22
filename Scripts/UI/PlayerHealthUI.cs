using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField]
    private Image playerGreenHealthBar;
    [SerializeField]
    private TextMeshProUGUI playerHealthText;

    private void Start()
    {
        FindObjectOfType<PlayerMovement>().GetComponent<Health>().OnChangedHealth += PlayerHealthUI_OnChangedHealth;
    }

    private void PlayerHealthUI_OnChangedHealth(int currentPlayerHealth, int maximumPlayerHealth)
    {
        float fillingAmount = (float)currentPlayerHealth / (float)maximumPlayerHealth;
        playerGreenHealthBar.fillAmount = fillingAmount;
        playerHealthText.text = string.Format("{0}/{1}", currentPlayerHealth, maximumPlayerHealth);
    }
}
