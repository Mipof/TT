using Cinemachine;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private CinemachineBrain _brain;
    private void Update()
    {
        Vector3 cameraPosition = _brain.OutputCamera.transform.position;
        Vector3 lookingAt = new Vector3(cameraPosition.x, transform.position.y, cameraPosition.z);
        transform.LookAt(lookingAt);
    }
}
