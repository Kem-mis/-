using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Begin : MonoBehaviour
{
    public Button Play;
    public Button Quit;
    //副本转换
    public static bool go0, go1, go2, go3;

    // 1.0-1
    public static bool drawerOpen;
    public static bool hairPicked, diaryPicked;
    public static bool bustlePicked, bustleFound;
    public static bool diary2Picked;

    // 1.0-2
    public static bool dressPicked, lightPicked, shoe1Picked, woodPicked;
    public static bool fireplaceBurned;
    public static bool hatPainted;
    public static bool shoe2Picked;

// 好像！大约！可能好了！
// 我玩了一下前面的，好像1.0火炉里鞋子/1.1镜子里的碎片拾取的时候不会消失（？
// 但是看了一眼代码，明明写了setactive的&如果切到别的场景再切回来也没问题（挠头
// 然后。1.2我不知道咋玩，1.2和1.3就没测（
// 你看一眼！1.3应该没啥问题（狗头
// 溜了爱你 =3=
// （笑死 我也想截个图，结果一按那个键，截到你电脑里了x
// （快点给我返图！！

// 呜呜呜呜返图这就来！

    // 1.0-3
    public static bool perfumePicked, lipstickPicked, axePicked;

    // 1.0-4
    public static bool hatPicked;

    // 1.1-1
    public static bool puzzle1Picked;

    // 1.1-2
    public static bool plantClicked;
    public static bool clothPicked;
    public static bool puzzle2Picked;
    
    // 1.1-3
    public static bool cupPicked, forkPicked, knifePicked, scissorsPicked, rubberPicked;
    public static bool wireFixed;

    //1.1-4
    public static bool mirrorClicked, puzzle4Picked;

    //1.2
    public static bool cloth2Picked;
    public static bool rodPicked, hammerPicked;
    public static bool sculpPicked, machineClicked;
    public static bool hang1Clicked, hang2Clicked;

    // 1.3-2
    public static bool bluePicked;
    public static bool yellowPicked;

    // 1.3-3
    public static bool scissors13Picked;
    public static bool swordPicked;
    public static bool needlePicked;
    public static bool greenClothGet, greenClothPicked, curtainCut;
    public static bool blueGlassPicked, yellowGlassPicked, RedGlassPicked;

    // 1.3-4
    public static bool featherPicked;

    // 1.3-6
    public static bool wireOnSocket;

    // props
    public static bool readDiary, readNote;
    
    public static bool readingDiary, readingNote;
    public static bool useBlue, useYellow, useRed;
    public static bool useBlueGlass, useYellowGlass, useRedGlass;
    
    // Start is called before the first frame update
    void Start()
    {
        go0 = go1 = go2 = go3 = false;
        // 1.0-1
        hairPicked = false;
        diaryPicked = false;
        diary2Picked = false;
        drawerOpen = false;
        bustlePicked = false;
        bustleFound = false;

        // 1.0-2
        dressPicked = lightPicked = shoe1Picked = false;
        fireplaceBurned = false;
        shoe2Picked = false;

        // 1.0-3
        perfumePicked = false;
        lipstickPicked = false;
        axePicked = false;

        //1.0-4
        hatPainted = false;
        hatPicked = false;

        //1.1-1
        puzzle1Picked = false;

        //1.1-2
        plantClicked = false;
        clothPicked = false;
        rubberPicked = false;
        puzzle2Picked = false;

        // 1.1-3
        cupPicked = forkPicked = knifePicked = scissorsPicked = false;
        wireFixed = false;

        // 1.1-4
        mirrorClicked = false;
        puzzle4Picked = false;

        // 1.2
        cloth2Picked = false;
        rodPicked = false;
        hammerPicked = false;
        sculpPicked = false;
        machineClicked = false;
        hang1Clicked = hang2Clicked = false;

        BagManager.PropClear();
        Play.onClick.AddListener(change);
        Quit.onClick.AddListener(quitOnClicked);

        // 1.3-2
        bluePicked = false;
        yellowPicked = false;

        // 1.3-3
        needlePicked = false;
        swordPicked = false;
        scissors13Picked = false;
        greenClothGet = greenClothPicked = false;
        curtainCut = false;

        // 1.3-4
        featherPicked = false;

        // 1.3-6
        wireOnSocket = false;

        // prop
        readDiary = readNote = false;
        useBlue = useYellow = useRed = false;
        readingDiary = readingNote = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void change()
    {
        SceneManager.LoadScene("video");
    }

    void quitOnClicked()
    {
        Application.Quit();
    }
}
