using UnityEngine;

public class Tongue_attack : MonoBehaviour
{

    LineRenderer line;
    Vector3 originalpos = new Vector3(540.6785f, -6.339138f, 1.0f);
   
    public void tongue (GameObject go)
    {
        line.SetPosition(0, go.transform.position);
    }

    public void tongueoriginalpos ()
    {
        line.SetPosition(0, originalpos);
    }
}
