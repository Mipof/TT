using System.Collections;
using UnityEngine;

public class Tongue_attack : MonoBehaviour
{

    [SerializeField] private LineRenderer _line;
    [SerializeField] private float _delay;
    private Vector3 originalpos = new Vector3(540.6785f, -6.339138f, 1.0f);
   
    public void TongueAtack (Transform _transform)
    {
        _line.SetPosition(0, _transform.position);
        StartCoroutine(DelayForTongue(_delay));
    }

    IEnumerator DelayForTongue(float delay)
    {
        yield return new WaitForSeconds(delay);
        TongueOriginalPos();
    }

    public void TongueOriginalPos()
    {
        _line.SetPosition(0, originalpos);
    }
}
