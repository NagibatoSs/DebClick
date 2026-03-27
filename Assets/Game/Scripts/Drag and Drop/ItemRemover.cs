using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemRemover : MonoBehaviour
{
    [SerializeField] private float _transparency = 0.5f;
    private Image img;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        img = collision.gameObject.GetComponent<Image>();
        img.color = new Color(img.color.r, img.color.g, img.color.b, _transparency);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var item = collision.gameObject.GetComponent<DragItem>();
        if (!item.IsDraggable)
            Destroy(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        img.color = new Color(img.color.r, img.color.g, img.color.b, 1);
    }


}
