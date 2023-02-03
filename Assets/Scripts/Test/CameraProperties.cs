using UnityEngine;

public class CameraProperties : MonoBehaviour
{
    [SerializeField] private CameraEnum _camera;

    public CameraEnum GetCameraEnum()
    {
        return _camera;
    }
}
