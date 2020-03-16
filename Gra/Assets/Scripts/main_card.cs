using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_card : MonoBehaviour
{
    [SerializeField] private SceneController controller;
    [SerializeField] private GameObject Card_back;
 
    public void OnMouseDown()
    {
        if(Card_back.activeSelf && controller.canReveal)
        {
            Card_back.SetActive(false);
            controller.CardRelevated(this);
        }
    }


    private int ID;
    public int id
    {
        get { return ID; }
    }

    public void ChangeCard(int id, Sprite image)
    {
        ID = id;
        GetComponent<SpriteRenderer>().sprite = image;
        
    }

    public void UnReveal()
    {
        Card_back.SetActive(true);
    }

    
}
