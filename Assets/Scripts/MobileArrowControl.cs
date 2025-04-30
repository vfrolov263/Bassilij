using UnityEngine;
using UnityEngine.EventSystems;

public class MobileArrowControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private float direction;

    public void OnPointerDown(PointerEventData eventData)
    {
        ArrowsInput.Direction = direction;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ArrowsInput.Direction = 0f;
    }
}