using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S1_1_5 : MonoBehaviour
{
    public Button stageBtn;
    // Start is called before the first frame update
    void Start()
    {
        stageBtn.onClick.AddListener(stageOnClicked);

        BagManager.RefreshItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void stageOnClicked()
    {
        SceneManager.LoadScene("1.1-6");
    }
}
