using UnityEngine;

public class SetSlow : MonoBehaviour
{

    private float _slow;
    
    public void SlowTarget(GameObject target)
    {
        if (target.TryGetComponent(out FollowWaypoint waypoint))
        {
            waypoint.SetNewSpeedMultiplier(_slow);
        }
    }

    public void SetNewSlow(float slow)
    {
        _slow = slow;
    }
}
