using UnityEngine;


public class TurretSlotManager : MonoBehaviour
{
    [SerializeField] private CameraEnum _camera;

    public CameraEnum GetCamera()
    {
        return _camera;
    }
}