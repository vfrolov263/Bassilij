using UnityEngine;

public class MobileControls : MonoBehaviour
{
    public void SetAxis(float direction)
    {
        ArrowsInput.Direction = direction;
    }
}