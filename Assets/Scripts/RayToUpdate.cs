using Cinemachine;
using UnityEngine;

public class RayToUpdate : MonoBehaviour
{
    private CinemachineBrain _brain;
    [SerializeField] private string _updateName;

    private void Update()
    {
        if (!_brain)
        {
            GetBrain();
            return;
        }

        Ray ray = _brain.OutputCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (Input.GetMouseButton(0) && hitInfo.transform.name == _updateName)
            {
                print("Update?");
                if (hitInfo.transform.parent.gameObject.TryGetComponent(out Turret turret))
                {
                    turret.UpgradeTurret();
                }
            }
        }
    }

    private void GetBrain()
    {
        _brain = GameManager.Instance.Brain;
    }
}