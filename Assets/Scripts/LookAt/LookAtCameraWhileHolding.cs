using Cinemachine;
using UnityEngine;

public class LookAtCameraWhileHolding : MonoBehaviour
{
    [SerializeField] private CinemachineBrain _brain;

    private bool _ready = true;
    private void Awake()
    {
        if (!_brain)
        {
            _brain = GameManager.Instance.Brain;
        }
    }

    private void Update()
    {
        if (!_brain || !_ready) return;
        Vector3 cameraPosition = _brain.OutputCamera.transform.position;
        Vector3 lookingAt = new Vector3(transform.position.x, cameraPosition.y, cameraPosition.z);
        transform.LookAt(lookingAt);
    }

    public void Stop()
    {
        _ready = false;
    }
}
