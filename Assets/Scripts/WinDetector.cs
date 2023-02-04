using UnityEngine;
using UnityEngine.Events;

public class WinDetector : MonoBehaviour
{
    [SerializeField] private GameObject _enemyParent;
    [SerializeField] private UnityEvent WinCondition;

    private bool _finalWaveStarted;
    

    public void FinalWave()
    {
        _finalWaveStarted = true;
    }


    private void LateUpdate()
    {
        if(!_finalWaveStarted) return;

        if (_enemyParent.transform.childCount == 0)
        {
            WinCondition?.Invoke();
        }
    }
}
