using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float smoothTime = 0.3f;
    private float camWidthSize;
    private Vector2 camMinPos, camMaxPos;
    private Vector3 velocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camWidthSize = Camera.main.orthographicSize * Camera.main.aspect;
        GameObject tilemap = GameObject.FindWithTag("Tilemap");
        Bounds tilemapBounds = tilemap.GetComponent<CompositeCollider2D>().bounds;
        camMinPos = tilemapBounds.min;
        camMaxPos = tilemapBounds.max;
        camMinPos.x += camWidthSize;
        camMinPos.y += Camera.main.orthographicSize;
        camMaxPos.x -= camWidthSize;
        camMaxPos.y -= Camera.main.orthographicSize;
        Debug.Log(camMinPos);
        Debug.Log(camMaxPos);
    }

    // Update is called once per frame
    void Update()
    {
       // Vector3 newPosition = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);

        Vector3 newPosition = Vector3.Distance(transform.position, target.position) < 0.15f ? target.position :
            Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);

        CheckBounds(ref newPosition);

        // if (Vector3.Distance(transform.position, target.position) < 0.15f)
        //     newPosition = target.position;

        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
    }

    void CheckBounds(ref Vector3 position)
    {
        if (position.x < camMinPos.x)
            position.x = camMinPos.x;
        else if (position.x > camMaxPos.x)
            position.x = camMaxPos.x;

        if (position.y < camMinPos.y)
            position.y = camMinPos.y;
        else if (position.y > camMaxPos.y)
            position.y = camMaxPos.y;
    }
}
