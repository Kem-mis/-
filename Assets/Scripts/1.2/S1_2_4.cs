using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class S1_2_4 : MonoBehaviour
{
    public Bag playerBag;
    public Button left, right;
    public Button hammerBtn;
    public GameObject hammer;
    public Item hammerItem;
    // Start is called before the first frame update
    void Start()
    {
        left.onClick.AddListener(l);
        right.onClick.AddListener(r);
        hammerBtn.onClick.AddListener(hammerOnClicked);

        if(Begin.hammerPicked)
        {
            hammerBtn.enabled = false;
            hammer.SetActive(false);
        }

        BagManager.RefreshItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void hammerOnClicked()
    {
        if(hammer.activeSelf)
        {
            hammerBtn.enabled = false;
            hammer.SetActive(false);
            Begin.hammerPicked = true;
            AddNewItem(hammerItem);
        }
    }

    void l()
    {
        SceneManager.LoadScene("1.2-3");
    }

    void r()
    {
        SceneManager.LoadScene("1.2-1");
    }

    public void AddNewItem(Item thisItem)
    {
        if (!playerBag.itemList.Contains(thisItem))
        {
            playerBag.itemList.Add(thisItem);
            thisItem.itemHeld = 1;
        }
        else
        {
            thisItem.itemHeld += 1;
        }

        BagManager.RefreshItem();
    }

    public void RemoveItem(Item thisItem)
    {
        if(playerBag.itemList.Contains(thisItem))
        {
            playerBag.itemList.Remove(thisItem);
        }
        BagManager.RefreshItem();
    }
}
