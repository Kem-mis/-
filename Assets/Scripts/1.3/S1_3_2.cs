using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class S1_3_2 : MonoBehaviour
{
    public Bag playerBag;
    public Button left, right;

    public GameObject plant1, plant2;
    public GameObject dust;

    public Button blueBtn;
    public Button yellowBtn;

    public Item blueItem;
    public Item yellowItem;

    // Start is called before the first frame update
    void Start()
    {
        left.onClick.AddListener(l);
        right.onClick.AddListener(r);

        blueBtn.onClick.AddListener(blueOnClick);
        yellowBtn.onClick.AddListener(yellowOnClick);

        BagManager.RefreshItem();

        if(Begin.bluePicked) {
            plant1.SetActive(false);
            plant2.SetActive(true);
            blueBtn.enabled = false;
        }
        if(Begin.yellowPicked) {
            dust.SetActive(false);
            yellowBtn.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void blueOnClick() {
        if(plant1.activeSelf) {
            plant1.SetActive(false);
            plant2.SetActive(true);
            blueBtn.enabled = false;
            AddNewItem(blueItem);
            Begin.bluePicked = true;
        }
    }
    
    void yellowOnClick() {
        if(dust.activeSelf) {
            dust.SetActive(false);
            yellowBtn.enabled = false;
            AddNewItem(yellowItem);
            Begin.yellowPicked = true;
        }
    }

    void l()
    {
        SceneManager.LoadScene("1.3-1");
    }

    void r()
    {
        SceneManager.LoadScene("1.3-3");
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
