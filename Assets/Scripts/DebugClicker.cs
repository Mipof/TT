using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class DebugClicker : MonoBehaviour
{
    private CinemachineBrain _brain;
    
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
            print(hitInfo.transform.name);
        }
    }

        private void GetBrain()
        {
            _brain = GameManager.Instance.Brain;
        }
}
