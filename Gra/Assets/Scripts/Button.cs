using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject targetObj;
    [SerializeField] private string targetMessage;
    public Color hilgightColor = Color.cyan;

    public void OnMouseOver()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        if(sprite!=null)
        {
            sprite.color = hilgightColor;
        }
    }

    public void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        if (sprite != null)
        {
            sprite.color = Color.white;
        }
    }

    private void OnMouseDown()
    {
        transform.localScale = new Vector3(0.6f, 0.6f, 1);

        if(targetObj!=null)
        {
            targetObj.SendMessage(targetMessage);
        }
    }
}
