using Cinemachine;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private bool X;
    [SerializeField] private bool Y;
    [SerializeField] private bool Z;
    [Space(10)] [SerializeField] private bool _lookAllTime;
    [SerializeField] private int _off;
    
    private CinemachineBrain _brain;
    [SerializeField] private CameraEnum _camera;
    

    private void Awake()
    {
        if (!_brain)
        {
            _brain = GameManager.Instance.Brain;
        }
    }

    public void SetCamera(CameraEnum cameraEnum)
    {
        _camera = cameraEnum;
    }

    private void Update()
    {
        if (!_brain)
        {
            GetCamera();
            return;
        }

        if (_lookAllTime)
        {
            LookAt();
        }
        else
        {
            if(GameManager.Instance.ActualCamera == _camera)
            {
                LookAt();
            }
            else
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
                transform.Rotate(new Vector3(0,0,0));
            }
        }
    }

    private void LookAt()
    {
        Vector3 cameraPosition = _brain.OutputCamera.transform.position;
        Vector3 lookingAt = new Vector3();
        if (X) lookingAt += new Vector3(cameraPosition.x, 0, 0);
        else lookingAt += new Vector3(transform.position.x, 0, 0);
        if (Y) lookingAt += new Vector3(0, cameraPosition.y - _off, 0);
        else lookingAt += new Vector3(0, transform.position.y, 0);
        if (X) lookingAt += new Vector3(0, 0, cameraPosition.z);
        else lookingAt += new Vector3(0, 0, transform.position.z);
        transform.LookAt(lookingAt);
    }

    private void GetCamera()
    {
        _brain = GameManager.Instance.Brain;
    }
}
