using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class S1_1_2 : MonoBehaviour
{
    Sequence s;
    public Bag playerBag;
    public Button left, right;
    public Button plantBtn;
    public Button clothBtn;

    public GameObject plant1, plant2;
    public GameObject cloth1, cloth2;
    public GameObject cloth11, cloth22;
    public GameObject anicup, aniknife;
    public GameObject puzzle2;

    public Item cupItem, cup2Item;
    public Item puzzleItem;

    private bool showingCloth;

    // Start is called before the first frame update
    void Start()
    {
        s = DOTween.Sequence();
        left.onClick.AddListener(l);
        right.onClick.AddListener(r);
        plantBtn.onClick.AddListener(plantOnClicked);
        clothBtn.onClick.AddListener(clothOnClicked);

        showingCloth = false;

        if(Begin.plantClicked)
        {
            plant1.SetActive(false);
            plant2.SetActive(true);
            plantBtn.enabled = false;
        }
        // if(Begin.clothPicked)
        // {
        //     cloth1.SetActive(false);
        //     clothBtn.enabled = false;
        // }
        if(Begin.puzzle2Picked)
        {
            cloth1.SetActive(false);
            cloth11.SetActive(true);
            clothBtn.enabled = false;
        }

        BagManager.RefreshItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void clothOnClicked()
    {
        // todo 判断有剪刀的情况
        // if(!showingCloth) {
        //     showingCloth = true;
        //     StartCoroutine(showCloth());
        // }
        if(Begin.scissorsPicked && !Begin.puzzle2Picked)
        {
            StartCoroutine(showCloth());
        }
    }

    IEnumerator showCloth()
    {
        cloth1.SetActive(false);
        cloth2.SetActive(true);
        s.Append(cloth2.transform.DOScale(new Vector3(2f, 2f, 2f), 1));
        s.Join(cloth2.transform.DOMove(new Vector3(cloth2.transform.position.x + 3f, cloth2.transform.position.y - 2f, 0f), 1));
        s.Join(cloth22.transform.DOScale(new Vector3(2f, 2f, 2f), 1));
        s.Join(cloth22.transform.DOMove(new Vector3(cloth22.transform.position.x + 3f, cloth22.transform.position.y - 2f, 0f), 1));
        yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(0.5f);
        cloth2.SetActive(false);
        cloth22.SetActive(true);
        puzzle2.SetActive(true);
        s.Append(puzzle2.transform.DOScale(new Vector3(5f, 5f, 5f), 1));
        s.Join(puzzle2.transform.DOMove(new Vector3(puzzle2.transform.position.x + 5f, puzzle2.transform.position.y + 3f, 0f), 1));
        yield return new WaitForSeconds(1f);
        puzzle2.SetActive(false);
        AddNewItem(puzzleItem);
        s.Append(cloth22.transform.DOScale(new Vector3(1f, 1f, 1f), 1));
        s.Join(cloth22.transform.DOMove(new Vector3(cloth2.transform.position.x - 3f, cloth2.transform.position.y + 2f, 0f), 1));
        yield return new WaitForSeconds(1f);
        cloth11.SetActive(true);
        cloth22.SetActive(false);
        Begin.puzzle2Picked = true;
        clothBtn.enabled = false;
        //showingCloth = false;
    }

    void plantOnClicked()
    {
        if(plant1.activeSelf && Begin.knifePicked && Begin.cupPicked)
        {
            aniknife.SetActive(true);
            anicup.SetActive(true);
            StartCoroutine(aniknif());
            StartCoroutine(anicu());
            plant1.SetActive(false);
            plant2.SetActive(true);
            Begin.plantClicked = true;
            plantBtn.enabled = false;
        }
        // else if(plant2.activeSelf && Begin.cupPicked && !Begin.rubberPicked) 
        // {
        //     Begin.rubberPicked = true;
        //     RemoveItem(cupItem);
        // }
    }

    IEnumerator aniknif()
    {
        s.Append(aniknife.transform.DOMove(new Vector3(aniknife.transform.position.x + 1f, aniknife.transform.position.y, 0f), 1.5f));
        yield return new WaitForSeconds(1.5f);
        aniknife.SetActive(false);
    }

    IEnumerator anicu()
    {
        s.Append(anicup.transform.DOMove(new Vector3(anicup.transform.position.x - 0.1f, anicup.transform.position.y + 0.1f, 0f), 1.5f));
        yield return new WaitForSeconds(1.5f);
        anicup.SetActive(false);
        RemoveItem(cupItem);
        AddNewItem(cup2Item);
    }

    void l()
    {
        SceneManager.LoadScene("1.1-1");
    }

    void r()
    {
        SceneManager.LoadScene("1.1-3");
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
