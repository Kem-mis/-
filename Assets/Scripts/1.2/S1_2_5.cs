using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S1_2_5 : MonoBehaviour
{
    public Button stageBtn;
    public Button roomBtn;
    // Start is called before the first frame update
    void Start()
    {
        stageBtn.onClick.AddListener(stageOnClicked);
        roomBtn.onClick.AddListener(roomOnClicked);

        BagManager.RefreshItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void roomOnClicked()
    {
        Debug.Log("room clicked");
        SceneManager.LoadScene("1.2-1");
    }

    void stageOnClicked()
    {
        Debug.Log("stage clicked");
        SceneManager.LoadScene("1.2-6");
    }
}
