using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> dropObjects;
    [SerializeField]
    private List<string> dropTags;
    [SerializeField]
    private TMP_Text warrningMsg;
    [SerializeField]
    private string fullInventoryMsg;
    [SerializeField]
    private string dropPointUnavailableMsg;
    private GameObject currentItem;
    private int itemsLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        itemsLayer = LayerMask.NameToLayer("Items");
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != itemsLayer)
            return;

        string tag = collision.gameObject.tag;

        if (currentItem != null)
        {
            if (tag == "DropPoint")
            {
                SpriteRenderer dropPointSprite = collision.GetComponent<SpriteRenderer>();
                if (dropPointSprite != null) Destroy(dropPointSprite);
                currentItem.SetActive(true);
                currentItem = null;
            }
            else if (warrningMsg.text == "")
            {
                warrningMsg.text = fullInventoryMsg;
                Invoke("HideMsg", 2f);
            }
        }
        else 
        {
            if (tag != "DropPoint")
            {
                currentItem = dropObjects[dropTags.IndexOf(tag)];
                Destroy(collision.gameObject);
            }
        }
    }

    private void HideMsg()
    {
        warrningMsg.text = "";
    }
}