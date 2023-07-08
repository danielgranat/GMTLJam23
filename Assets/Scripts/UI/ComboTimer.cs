using UnityEngine;
using UnityEngine.UI;

public class ComboTimer : MonoBehaviour
{
    [SerializeField] private Image countdownCircleTimer;
    [SerializeField] private GameSystem Game;

    private void Update()
    {
        if (Game.ComboExpiration > 0)
        {
            if(countdownCircleTimer.gameObject.activeSelf == false)
                countdownCircleTimer.gameObject.SetActive(true);
            countdownCircleTimer.fillAmount = Game.ComboExpiration;
        }
        else
        {
            countdownCircleTimer.gameObject.SetActive(false);
        }
    }
}
