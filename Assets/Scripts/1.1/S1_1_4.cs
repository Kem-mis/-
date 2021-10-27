using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class S1_1_4 : MonoBehaviour
{
    Sequence s;
    public Bag playerBag;
    public Button left, right;
    public Button mirrorBtn, puzzleBtn;
    public GameObject frost, pz;
    public Item puzzle;
    // Start is called before the first frame update
    void Start()
    {
        s = DOTween.Sequence();
        left.onClick.AddListener(l);
        right.onClick.AddListener(r);
        mirrorBtn.onClick.AddListener(mirrorOnClicked);
        puzzleBtn.onClick.AddListener(puzzleOnClicked);

        BagManager.RefreshItem();

        if(Begin.mirrorClicked)
        {
            frost.SetActive(true);
            mirrorBtn.enabled = false;
        }
        if(Begin.puzzle4Picked)
        {
            puzzleBtn.enabled = false;
        }
    }

    void mirrorOnClicked()
    {
        frost.SetActive(true);
        Begin.mirrorClicked = true;
        mirrorBtn.enabled = false;
    }

    void puzzleOnClicked()
    {
        if(Begin.mirrorClicked){
            StartCoroutine(p4());
            puzzleBtn.enabled = false;
            Begin.puzzle4Picked = true;
        }
    }

    IEnumerator p4()
    {
        pz.SetActive(true);
        s.Append(pz.transform.DOScale(new Vector3(3f, 3f, 3f), 1));
        yield return new WaitForSeconds(1f);
        pz.SetActive(false);
        AddNewItem(puzzle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void l()
    {
        SceneManager.LoadScene("1.1-3");
    }

    void r()
    {
        SceneManager.LoadScene("1.1-1");
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
