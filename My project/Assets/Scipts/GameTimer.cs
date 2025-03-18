using UnityEngine;
using TMPro; 

public class GameTimer : MonoBehaviour
{
    private float elapsedTime = 0f;
    private bool isRunning = true;
    public TextMeshProUGUI timerText; 

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime; 
            timerText.text = "Time: " + elapsedTime.ToString("F2") + "s"; 
        }
    }

    public void StopTimer()
    {
        isRunning = false; 
    }
}
