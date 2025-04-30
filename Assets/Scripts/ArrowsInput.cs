using UnityEngine;

public static class ArrowsInput
{
    public static float Direction
    {
        get
        {
            return Mathf.Approximately(direction, 0f) ? Input.GetAxis("Horizontal") : direction;
        }
        set
        {
            direction = value;
        }
    }

    private static float direction;
}
