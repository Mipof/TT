using UnityEngine;

public class AdjustGameSpeed : MonoBehaviour
{
    public void SpeedChanged(float speed)
    {
        Time.timeScale = speed;
    }
}
