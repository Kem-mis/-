using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S1_1_6 : MonoBehaviour
{
    public Button change;
    public Bag playerBag;
    public Button crossBtn, fruitBtn, cupBtn,dialexBut;

    public GameObject upcross, downcross, fruit, cup;
    public Item cupItem, juicecupItem;
    private bool hascup;
    // Start is called before the first frame update
    void Start()
    {
        crossBtn.onClick.AddListener(crossOnClicked);
        cupBtn.onClick.AddListener(cupOnClicked);
        fruitBtn.onClick.AddListener(fruitOnClicked);

        hascup = false;

        //change.onClick.AddListener(load);
        BagManager.RefreshItem();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerBag.itemList.Contains(juicecupItem))
        {
            Destroy(dialexBut.gameObject);
        }

    }

    void fruitOnClicked()
    {
        if(hascup && downcross.activeSelf)
        {
            RemoveItem(cupItem);
            AddNewItem(juicecupItem);
            fruitBtn.enabled = false;
        }
    }

    void cupOnClicked()
    {
        if(cup.activeSelf)
        {
            cup.SetActive(false);
            AddNewItem(cupItem);
            cupBtn.enabled = false;
            hascup = true;
        }
    }

    void crossOnClicked()
    {
        upcross.SetActive(false);
        fruit.SetActive(false);
        downcross.SetActive(true);
        crossBtn.enabled = false;
    }

    void load()
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
