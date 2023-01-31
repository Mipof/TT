using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [ContextMenu("Stop")]
    public void StopTime()
    {
        Time.timeScale = 0;
    }

    [ContextMenu("Start")]
    public void StartTime()
    {
        Time.timeScale = 1;
    }

    [ContextMenu("Routine")]
    public void StartRoutine()
    {
        StartCoroutine(Routine());
    }

    IEnumerator Routine()
    {
        print("Empieza timer");
        yield return new WaitForSeconds(2);
        print("tiempo terminado");
    }
}
