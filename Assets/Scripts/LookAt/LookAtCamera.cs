using Cinemachine;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private bool X;
    [SerializeField] private bool Y;
    [SerializeField] private bool Z;
    
    private CinemachineBrain _brain;
    

    private void Awake()
    {
        if (!_brain)
        {
            _brain = GameManager.Instance.Brain;
        }
    }

    private void Update()
    {
        if (!_brain)
        {
            GetCamera();
            return;
        }
        
        Vector3 cameraPosition = _brain.OutputCamera.transform.position;
        Vector3 lookingAt = new Vector3();
        if (X) lookingAt += new Vector3(cameraPosition.x, 0, 0);
        else lookingAt += new Vector3(transform.position.x, 0, 0); 
        if (Y) lookingAt += new Vector3(0,cameraPosition.y,  0);
        else lookingAt += new Vector3(0,transform.position.y,  0);
        if (X) lookingAt += new Vector3(0,0,cameraPosition.z);
        else lookingAt += new Vector3(0,0,transform.position.z);
        
        print(lookingAt);
        transform.LookAt(lookingAt);
    }

    private void GetCamera()
    {
        _brain = GameManager.Instance.Brain;
    }
}
