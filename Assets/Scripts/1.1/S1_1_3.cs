using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class S1_1_3 : MonoBehaviour
{
    Sequence s;
    public Bag playerBag;
    public Button left, right;

    public Button cupBtn;
    public Button forkBtn;
    public Button knifeBtn;
    public Button scissorsBtn;
    public Button wireBtn;

    public GameObject cup;
    public GameObject fork;
    public GameObject knife;
    public GameObject scissors;
    public GameObject wire1, wire2;
    public GameObject puzzle3;

    public Item cupItem;
    public Item forkItem;
    public Item knifeItem;
    public Item scissorsItem;
    public Item puzzleItem;

    // Start is called before the first frame update
    void Start()
    {
        s = DOTween.Sequence();
        left.onClick.AddListener(l);
        right.onClick.AddListener(r);

        cupBtn.onClick.AddListener(cupOnClicked);
        forkBtn.onClick.AddListener(forkOnClicked);
        knifeBtn.onClick.AddListener(knifeOnClicked);
        scissorsBtn.onClick.AddListener(scissorsOnClicked);
        wireBtn.onClick.AddListener(wireOnClicked);

        if(Begin.cupPicked) {
            cup.SetActive(false);
            cupBtn.enabled = false;
        }
        if(Begin.forkPicked) {
            fork.SetActive(false);
            forkBtn.enabled = false;
        }
        if(Begin.knifePicked) {
            knife.SetActive(false);
            knifeBtn.enabled = false;
        }
        if(Begin.scissorsPicked) {
            scissors.SetActive(false);
            scissorsBtn.enabled = false;
        }
        if(Begin.wireFixed) {
            wire1.SetActive(false);
            wire2.SetActive(true);
            wireBtn.enabled = false;
        }

        BagManager.RefreshItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void l()
    {
        SceneManager.LoadScene("1.1-2");
    }

    void r()
    {
        SceneManager.LoadScene("1.1-4");
    }
    
    void cupOnClicked() {
        if(cup.activeSelf) {
            cup.SetActive(false);
            AddNewItem(cupItem);
            Begin.cupPicked = true;
            cupBtn.enabled = false;
        }
    }

    void forkOnClicked() {
        if(fork.activeSelf) {
            fork.SetActive(false);
            AddNewItem(forkItem);
            Begin.forkPicked = true;
            forkBtn.enabled = false;
        }
    }

    void knifeOnClicked() {
        if(knife.activeSelf) {
            knife.SetActive(false);
            AddNewItem(knifeItem);
            Begin.knifePicked = true;
            knifeBtn.enabled = false;
        }
    }

    void scissorsOnClicked() {
        if(scissors.activeSelf) {
            scissors.SetActive(false);
            AddNewItem(scissorsItem);
            Begin.scissorsPicked = true;
            scissorsBtn.enabled = false;
        }
    }

    void wireOnClicked() {
        if(wire1.activeSelf && Begin.plantClicked) {
            wire2.SetActive(true);
            wire1.SetActive(false);
            Begin.wireFixed = true;
            wireBtn.enabled = false;
            StartCoroutine(p3());
        }
    }

    IEnumerator p3()
    {
        puzzle3.SetActive(true);
        s.Append(puzzle3.transform.DOScale(new Vector3(3f, 3f, 3f), 1));
        s.Join(puzzle3.transform.DOMove(new Vector3(puzzle3.transform.position.x, puzzle3.transform.position.y, 0f), 1));
        yield return new WaitForSeconds(1f);
        puzzle3.SetActive(false);
        AddNewItem(puzzleItem);
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
