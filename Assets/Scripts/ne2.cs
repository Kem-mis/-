using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ne2 : MonoBehaviour
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
        yield return new WaitForSeconds(124f);
        SceneManager.LoadScene("0.0");
    }
}
