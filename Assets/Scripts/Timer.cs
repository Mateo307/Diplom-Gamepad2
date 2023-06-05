using UnityEngine;
using TMPro;
 
public class Timer : MonoBehaviour
{
    public float totalTime = 150.0f; // 2.5 minutes in seconds
    public float intervalTime = 30.0f; // 30 seconds in seconds
    private float currentTime = 0.0f;
    private int counter = 0;
    public TMP_Text timerText;
    
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= 150.0f && counter <= 3)
        {
            if (currentTime >= (150.0f + intervalTime * (counter + 1)))
            {
                counter++;
                // Add 1 to variable every 30 seconds, up to 3 times
                // Do something with variable here
                Debug.Log("Counter: " + counter);
            }
        }
        // Update the timer text
        int minutes = Mathf.FloorToInt(currentTime / 60.0f);
        int seconds = Mathf.FloorToInt(currentTime - minutes * 60.0f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}