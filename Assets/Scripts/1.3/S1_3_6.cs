using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S1_3_6 : MonoBehaviour
{
    // public Button basementBtn;
    // pb: 键盘上的键，要挂的button写在注释了
    public Button numBtn0;  // 0
    public Button numBtn1;  // 1
    public Button numBtn2;  // 2
    public Button numBtn3;  // 3
    public Button numBtn4;  // 4
    public Button numBtn5;  // 5
    public Button numBtn6;  // 6
    public Button numBtn7;  // 7
    public Button numBtn8;  // 8
    public Button numBtn9;  // 9
    public Button backBtn;  // 退格（1左边
    public Button enterBtn; // 确认（4左边
    public Button slashBtn; // 斜杠（7左边
    public Button quesBtn;  // ？（左下角
    public Button starBtn;  // 星号（7下面
    public Button sharpBtn; // 井号（9下面
    public Button bettyBut;

    // pb: 放大的键盘，绿灯和红灯的图要放在没有灯的上面
    public GameObject betty;
    public GameObject noLight;
    public GameObject redLight;
    public GameObject greenLight, greenLight2;

    // pb: 开着的门
    public GameObject doorOpened, doorLocked;

    // pb: scene里加一个button，图片改成叉叉，当成*GameObject*挂在close那里
    public GameObject close;
    private Button closeBtn;

    // pb: 锁上加一个button，点击放大
    public Button lockBtn;

    // pb: 插在插座上的线
    public GameObject wireOn;
    // pb: 不在插座上的线
    public GameObject wireOff;
    // pb: 插座的按钮
    public Button socketBtn;

    public GameObject lockSmall;
    public GameObject pswBg, pswGameOb;
    private Text pswText;

    //aka
    public GameObject[] diaryPage = new GameObject[6];
    public GameObject[] notePage = new GameObject[5];
    //public GameObject close;
    //public Button closeBtn;
    private int diaryPageNum, notePageNum;
    public Button nextDiaryBtn, prevDiaryBtn;



    private string psw;
    private const string correctPsw = "412369";

    // Start is called before the first frame update
    void Start()
    {
        closeBtn = close.GetComponent<Button>();
        close.SetActive(false);
        closeBtn.enabled = false;

        pswText = pswGameOb.GetComponent<Text>();
        
        psw = "";

        //aka
        nextDiaryBtn.onClick.AddListener(nextDiaryOnClicked);
        prevDiaryBtn.onClick.AddListener(prevDiaryOnClicked);
        //closeBtn.onClick.AddListener(closeOnClicked);
        Begin.readNote = false;
        Begin.readDiary = false;
        Begin.readingDiary = false;
        Begin.readingNote = false;
        nextDiaryBtn.enabled = false;
        prevDiaryBtn.enabled = false;

        numBtn0.onClick.AddListener(btn0OnClick);
        numBtn1.onClick.AddListener(btn1OnClick);
        numBtn2.onClick.AddListener(btn2OnClick);
        numBtn3.onClick.AddListener(btn3OnClick);
        numBtn4.onClick.AddListener(btn4OnClick);
        numBtn5.onClick.AddListener(btn5OnClick);
        numBtn6.onClick.AddListener(btn6OnClick);
        numBtn7.onClick.AddListener(btn7OnClick);
        numBtn8.onClick.AddListener(btn8OnClick);
        numBtn9.onClick.AddListener(btn9OnClick);
        backBtn.onClick.AddListener(backOnClick);
        enterBtn.onClick.AddListener(checkPsw);
        slashBtn.onClick.AddListener(slashOnClick);
        quesBtn.onClick.AddListener(quesOnClick);
        starBtn.onClick.AddListener(starOnClick);
        sharpBtn.onClick.AddListener(sharpOnClick);

        lockBtn.onClick.AddListener(lockOnClicked);
        closeBtn.onClick.AddListener(closeOnClick);

        socketBtn.onClick.AddListener(socketOnClick);

        noLight.SetActive(false);
        redLight.SetActive(false);
        greenLight.SetActive(false);

        if(Begin.wireOnSocket) {
            wireOn.SetActive(true);
            wireOff.SetActive(false);
        }
        else {
            wireOn.SetActive(false);
            wireOff.SetActive(true);
        }

        BagManager.RefreshItem();
    }

    // Update is called once per frame
    void Update()
    {
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

    void btn0OnClick() {
        if(!pswBg.activeSelf) {
            // Debug.Log("display");
            pswBg.SetActive(true);
            pswGameOb.SetActive(true);

        }
        if(psw.Length < 6) {
            psw += '0';
            pswText.text = psw;
        }
    }
    void btn1OnClick() {
        if(!pswBg.activeSelf) {
            // Debug.Log("display");
            pswBg.SetActive(true);
            pswGameOb.SetActive(true);

        }
        if(psw.Length < 6) {
            psw += '1';
            pswText.text = psw;
        }
    }
    void btn2OnClick() {
        if(!pswBg.activeSelf) {
            // Debug.Log("display");
            pswBg.SetActive(true);
            pswGameOb.SetActive(true);

        }
        if(psw.Length < 6) {
            psw += '2';
            pswText.text = psw;
        }
    }
    void btn3OnClick() {
        if(!pswBg.activeSelf) {
            // Debug.Log("display");
            pswBg.SetActive(true);
            pswGameOb.SetActive(true);

        }
        if(psw.Length < 6) {
            psw += '3';
            pswText.text = psw;
        }
    }
    void btn4OnClick() {
        if(!pswBg.activeSelf) {
            // Debug.Log("display");
            pswBg.SetActive(true);
            pswGameOb.SetActive(true);

        }
        if(psw.Length < 6) {
            psw += '4';
            pswText.text = psw;
        }
    }
    void btn5OnClick() { 
        if(!pswBg.activeSelf) {
            // Debug.Log("display");
            pswBg.SetActive(true);
            pswGameOb.SetActive(true);

        }
        if(psw.Length < 6) {
            psw += '5';
            pswText.text = psw;
        }
    }
    void btn6OnClick() {
        if(!pswBg.activeSelf) {
            // Debug.Log("display");
            pswBg.SetActive(true);
            pswGameOb.SetActive(true);

        }
        if(psw.Length < 6) {
            psw += '6';
            pswText.text = psw;
        }
    }
    void btn7OnClick() {
        if(!pswBg.activeSelf) {
            // Debug.Log("display");
            pswBg.SetActive(true);
            pswGameOb.SetActive(true);

        }
        if(psw.Length < 6) {
            psw += '7';
            pswText.text = psw;
        }
    }
    void btn8OnClick() {
        if(!pswBg.activeSelf) {
            // Debug.Log("display");
            pswBg.SetActive(true);
            pswGameOb.SetActive(true);

        }
        if(psw.Length < 6) {
            psw += '8';
            pswText.text = psw;
        }
    }
    void btn9OnClick() {
        if(!pswBg.activeSelf) {
            // Debug.Log("display");
            pswBg.SetActive(true);
            pswGameOb.SetActive(true);

        }
        if(psw.Length < 6) {
            psw += '9';
            pswText.text = psw;
        }
    }
    void slashOnClick() {
        if(!pswBg.activeSelf) {
            // Debug.Log("display");
            pswBg.SetActive(true);
            pswGameOb.SetActive(true);

        }
        if(psw.Length < 6) {
            psw += '/';
            pswText.text = psw;
        }
    }
    void quesOnClick() {
        if(!pswBg.activeSelf) {
            // Debug.Log("display");
            pswBg.SetActive(true);
            pswGameOb.SetActive(true);

        }
        if(psw.Length < 6) {
            psw += '?';
            pswText.text = psw;
        }
    }
    void starOnClick() {
        if(!pswBg.activeSelf) {
            // Debug.Log("display");
            pswBg.SetActive(true);
            pswGameOb.SetActive(true);

        }
        if(psw.Length < 6) {
            psw += '*';
            pswText.text = psw;
        }
    }
    void sharpOnClick() {
        if(!pswBg.activeSelf) {
            // Debug.Log("display");
            pswBg.SetActive(true);
            pswGameOb.SetActive(true);

        }
        if(psw.Length < 6) {
            psw += '#';
            pswText.text = psw;
        }
    }

    void backOnClick() {
        if(psw.Length > 0) {
            psw = psw.Remove(psw.Length - 1, 1);
            pswText.text = psw;
        }
    }

    void checkPsw() {
        if(psw == correctPsw) {
            disableBtn();
            StartCoroutine(rightPsw());
            pswBg.SetActive(false);
            pswGameOb.SetActive(false);
        }
        else {
            disableBtn();
            StartCoroutine(wrongPsw());
        }
        psw = "";
        pswText.text = psw;
    }

    void disableBtn() {
        numBtn0.enabled = false;
        numBtn1.enabled = false;
        numBtn2.enabled = false;
        numBtn3.enabled = false;
        numBtn4.enabled = false;
        numBtn5.enabled = false;
        numBtn6.enabled = false;
        numBtn7.enabled = false;
        numBtn8.enabled = false;
        numBtn9.enabled = false;

        backBtn.enabled = false;
        enterBtn.enabled = false;
        slashBtn.enabled = false;
        quesBtn.enabled = false;
        starBtn.enabled = false;
        sharpBtn.enabled = false;
    }

    IEnumerator rightPsw() {
        greenLight.SetActive(true);
        yield return new WaitForSeconds(1f);
        greenLight2.SetActive(true);
        greenLight.SetActive(false);
        noLight.SetActive(false);
        redLight.SetActive(false);
        Destroy(bettyBut.gameObject);
        // enableBtn();
        // pb: 开门？进下一关？
        yield return new WaitForSeconds(1f);
        greenLight2.SetActive(false);
        pswGameOb.SetActive(false);
        pswBg.SetActive(false);
        close.SetActive(false);
        closeBtn.enabled = false;
        doorOpened.SetActive(true);
        doorLocked.SetActive(false);
        betty.SetActive(true);
    }

    IEnumerator wrongPsw() {
        redLight.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        redLight.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        redLight.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        redLight.SetActive(false);
        enableBtn();
    }

    void enableBtn() {
        numBtn0.enabled = true;
        numBtn1.enabled = true;
        numBtn2.enabled = true;
        numBtn3.enabled = true;
        numBtn4.enabled = true;
        numBtn5.enabled = true;
        numBtn6.enabled = true;
        numBtn7.enabled = true;
        numBtn8.enabled = true;
        numBtn9.enabled = true;

        backBtn.enabled = true;
        enterBtn.enabled = true;
        slashBtn.enabled = true;
        quesBtn.enabled = true;
        starBtn.enabled = true;
        sharpBtn.enabled = true;
    }

    void lockOnClicked() {
        if(Begin.wireOnSocket) {
            lockSmall.SetActive(false);
            lockBtn.enabled = false;
            psw = "";
            noLight.SetActive(true);
            close.SetActive(true);
            closeBtn.enabled = true;
            enableBtn();
        }
    }

    void closeOnClick() {
        redLight.SetActive(false);
        greenLight.SetActive(false);
        noLight.SetActive(false);
        disableBtn();
        close.SetActive(false);
        closeBtn.enabled = false;

        //aka
        if(Begin.readingDiary) {
            diaryPage[diaryPageNum].SetActive(false);
            Begin.readingDiary = false;
            close.SetActive(false);
            closeBtn.enabled = false;
            prevDiaryBtn.enabled = false;
            nextDiaryBtn.enabled = false;
        }
        else if(Begin.readingNote) {
            notePage[notePageNum].SetActive(false);
            Begin.readingNote = false;
            close.SetActive(false);
            closeBtn.enabled = false;
            prevDiaryBtn.enabled = false;
            nextDiaryBtn.enabled = false;
        }
        
    }

    void socketOnClick() {
        if(Begin.wireOnSocket) {
            wireOn.SetActive(false);
            wireOff.SetActive(true);
        }
        else {
            wireOn.SetActive(true);
            wireOff.SetActive(false);
        }
        Begin.wireOnSocket = !Begin.wireOnSocket;
    }
}
