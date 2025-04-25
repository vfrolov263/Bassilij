using System.Collections;
using UnityEngine;

public class PlayerFigurine : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    private RectTransform target;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetPosition(RectTransform transform)
    {
        rectTransform.position = transform.position;
    }

    public void SetDestination(RectTransform target)
    {
        this.target = target;
    }

    public void Move()
    {
        StartCoroutine(GoNext());
    }

    public float GetReadyTime()
    {
        float distance = Vector2.Distance(rectTransform.position, target.position);
        return distance / speed;
    }

    private IEnumerator GoNext()
    {
        while (!Mathf.Approximately(Vector2.Distance(rectTransform.position, target.position), 0f))
        {
            rectTransform.position += Vector3.Normalize(target.position - rectTransform.position) * speed * Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
}