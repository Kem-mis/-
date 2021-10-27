using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class S1_2_1 : MonoBehaviour
{
    public Bag playerBag;
    public Button left, right;
    public Button doorBtn,diadoorBut;

    //aka
    public GameObject[] diaryPage = new GameObject[6];
    public GameObject[] notePage = new GameObject[5];
    public GameObject close;
    public Button closeBtn;
    private int diaryPageNum, notePageNum;
    public Button nextDiaryBtn, prevDiaryBtn;


    public Item diary, perfume, diary2;
    // Start is called before the first frame update
    void Start()
    {
        left.onClick.AddListener(l);
        right.onClick.AddListener(r);
        doorBtn.onClick.AddListener(doorOnClicked);

        //aka
        nextDiaryBtn.onClick.AddListener(nextDiaryOnClicked);
        prevDiaryBtn.onClick.AddListener(prevDiaryOnClicked);
        closeBtn.onClick.AddListener(closeOnClicked);
        Begin.readNote = false;
        Begin.readDiary = false;
        Begin.readingDiary = false;
        Begin.readingNote = false;
        nextDiaryBtn.enabled = false;
        prevDiaryBtn.enabled = false;

        if (!Begin.go2)
        {
            BagManager.PropClear();
            //todo 香水，Andrew记事本和雷欧妮日记要留着
            if (Begin.diaryPicked) AddNewItem(diary);
            if (Begin.perfumePicked) AddNewItem(perfume);
            if (Begin.diary2Picked) AddNewItem(diary2);
            Begin.go2 = true;
        }

        BagManager.RefreshItem();
    }

    // Update is called once per frame
    void Update()
    {
        if (Begin.cloth2Picked)
        {
            Destroy(diadoorBut.gameObject);
        }

        //aka
        if(Begin.readNote == true) {
            Begin.readNote = false;
            Begin.readingNote = true;
            notePage[0].SetActive(true);
            notePageNum = 0;
            nextDiaryBtn.enabled = true;
            prevDiaryBtn.enabled = false;
            close.SetActive(true);
            closeBtn.enabled = true;
        }
        if(Begin.readDiary == true) {
            Begin.readingDiary = true;
            Begin.readDiary = false;
            diaryPage[0].SetActive(true);
            diaryPageNum = 0;
            nextDiaryBtn.enabled = true;
            prevDiaryBtn.enabled = false;
            close.SetActive(true);
            closeBtn.enabled = true;
        }

    }

    //aka
    void nextDiaryOnClicked() {
        if(Begin.readingDiary && diaryPageNum < 5) {
            diaryPageNum ++;
            diaryPage[diaryPageNum].SetActive(true);
            diaryPage[diaryPageNum - 1].SetActive(false);
            if(diaryPageNum == 5) {
                nextDiaryBtn.enabled = false;
            }
            else if(diaryPageNum == 1) {
                prevDiaryBtn.enabled = true;
            }
        }
        else if(Begin.readingNote && notePageNum < 4) {
            notePageNum ++;
            notePage[notePageNum].SetActive(true);
            notePage[notePageNum - 1].SetActive(false);
            if(notePageNum == 4) {
                nextDiaryBtn.enabled = false;
            }
            else if(notePageNum == 1) {
                prevDiaryBtn.enabled = true;
            }
        }
    }
    void prevDiaryOnClicked() {
        if(Begin.readingDiary && diaryPageNum > 0) {
            diaryPageNum --;
            diaryPage[diaryPageNum].SetActive(true);
            diaryPage[diaryPageNum + 1].SetActive(false);
            if(diaryPageNum == 0) {
                prevDiaryBtn.enabled = false;
            }
            else if(diaryPageNum == 4) {
                nextDiaryBtn.enabled = true;
            }
        }
        else if(Begin.readingNote && notePageNum > 0) {
            notePageNum --;
            notePage[notePageNum].SetActive(true);
            notePage[notePageNum + 1].SetActive(false);
            if(notePageNum == 0) {
                prevDiaryBtn.enabled = false;
            }
            else if(notePageNum == 3) {
                nextDiaryBtn.enabled = true;
            }
        }
    }
    void closeOnClicked() {
        if(Begin.readingDiary) {
            diaryPage[diaryPageNum].SetActive(false);
            Begin.readingDiary = false;
        }
        else if(Begin.readingNote) {
            notePage[notePageNum].SetActive(false);
            Begin.readingNote = false;
        }
        close.SetActive(false);
        closeBtn.enabled = false;
        prevDiaryBtn.enabled = false;
        nextDiaryBtn.enabled = false;
    }



    void doorOnClicked()
    {
        if(Begin.cloth2Picked)
        {
            SceneManager.LoadScene("1.2-5");
        }
    }

    void l()
    {
        SceneManager.LoadScene("1.2-4");
    }

    void r()
    {
        SceneManager.LoadScene("1.2-2");
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
