using UnityEngine;

public class LevelPrepare : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemies"), LayerMask.NameToLayer("Enemies"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Drop"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Bullets"), LayerMask.NameToLayer("Drop"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Drop"), LayerMask.NameToLayer("Drop"));
    }
}
