﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class white3 : MonoBehaviour
{
    public GameObject video;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playVideo());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator playVideo()
    {
        video.SetActive(true);
        yield return new WaitForSeconds(4.5f);
        SceneManager.LoadScene("2.0");
    }
}