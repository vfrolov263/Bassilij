using UnityEngine;

public class PlayerLocker : MonoBehaviour
{
    public bool Locked { get; private set; }
    [SerializeField]
    GameObject controlsPannel;
    private bool isMobile;
    private int lockers;

    private void Start()
    {
        isMobile = controlsPannel == null ? false : controlsPannel.activeSelf;
    }

    public void SetLock(bool locked)
    {
        if (locked)
            lockers++;
        else
            lockers--;

        if (lockers < 0)
            lockers = 0;

        Locked = lockers > 0; // locked?

        if (controlsPannel != null)
            controlsPannel.SetActive(!Locked && isMobile);

        if (Locked)
            ArrowsInput.Direction = 0f;
    }
}
