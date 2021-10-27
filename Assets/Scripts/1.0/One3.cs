using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class One3 : MonoBehaviour
{
    public Bag playerBag;
    public Button left, right;
    public Button perfumeButton, lipstickButton, axeButton;
    public GameObject perfume, lipstick, axe;
    public Item perfume2, lipstick2, axe2;

    
    public GameObject[] diaryPage = new GameObject[6];
    public GameObject[] notePage = new GameObject[5];
    public GameObject close;
    private Button closeBtn;
    private int diaryPageNum, notePageNum;
    public Button nextDiaryBtn, prevDiaryBtn;

    // Start is called before the first frame update
    void Start()
    {
        closeBtn = close.GetComponent<Button>();
        close.SetActive(false);
        closeBtn.enabled = false;
        closeBtn.onClick.AddListener(closeOnClicked);

        left.onClick.AddListener(l);
        right.onClick.AddListener(r);
        perfumeButton.onClick.AddListener(perfumeClicked);
        lipstickButton.onClick.AddListener(lipstickClicked);
        axeButton.onClick.AddListener(axeClicked);

        if(Begin.perfumePicked == true) 
        {
            perfume.SetActive(false);
            perfumeButton.enabled = false;
        }
        if(Begin.lipstickPicked == true) 
        {
            lipstick.SetActive(false);
            lipstickButton.enabled = false;
        }
        if(Begin.axePicked == true) 
        {
            axe.SetActive(false);
            axeButton.enabled = false;
        }

        nextDiaryBtn.onClick.AddListener(nextDiaryOnClicked);
        prevDiaryBtn.onClick.AddListener(prevDiaryOnClicked);

        for(int i = 0; i < 6; i ++) {
            diaryPage[i].SetActive(false);
        }
        for(int i = 0; i < 5; i ++) {
            notePage[i].SetActive(false);
        }

        Begin.readNote = false;
        Begin.readDiary = false;
        Begin.readingDiary = false;
        Begin.readingNote = false;

        nextDiaryBtn.enabled = false;
        prevDiaryBtn.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {        
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

    void axeClicked()
    {
        if(axe.activeSelf)
        {
            axe.SetActive(false);
            AddNewItem(axe2);
            Begin.axePicked = true;
            axeButton.enabled = false;
        }
    }

    void lipstickClicked()
    {
        if(lipstick.activeSelf)
        {
            lipstick.SetActive(false);
            AddNewItem(lipstick2);
            Begin.lipstickPicked = true;
            lipstickButton.enabled = false;
        }
    }

    void perfumeClicked()
    {
        if(perfume.activeSelf)
        {
            perfume.SetActive(false);
            AddNewItem(perfume2);
            Begin.perfumePicked = true;
            perfumeButton.enabled = false;
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

    void l()
    {
        SceneManager.LoadScene("1.0-2");
    }

    void r()
    {
        SceneManager.LoadScene("1.0-4");
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
}
