using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class S1_3_4 : MonoBehaviour
{
    public Bag playerBag;
    public Button left, right;

    public Button featherBtn;
    public GameObject feather;
    public Item featherItem;

    // Start is called before the first frame update
    void Start()
    {
        left.onClick.AddListener(l);
        right.onClick.AddListener(r);

        featherBtn.onClick.AddListener(featherOnClicked);

        if(Begin.featherPicked) {
            feather.SetActive(false);
            featherBtn.enabled = false;
        }

        BagManager.RefreshItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void featherOnClicked() {
        Begin.featherPicked = true;
        feather.SetActive(false);
        featherBtn.enabled = false;
        AddNewItem(featherItem);
    }

    void l()
    {
        SceneManager.LoadScene("1.3-3");
    }

    void r()
    {
        SceneManager.LoadScene("1.3-1");
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
