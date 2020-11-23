using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutscript : MonoBehaviour
{
    public GameObject pan1;
    public GameObject pan2;
    public GameObject pan3;
    public GameObject pan4;
    public GameObject pan5;
    public GameObject pan6;

    public bool tutEnd;

    public MainMenu menuScript;

    void Start()
    {
        pan1.SetActive(false);
        pan2.SetActive(false);
        pan3.SetActive(false);
        pan4.SetActive(false);
        pan5.SetActive(false);
        pan6.SetActive(false);
    }
    public void TutStart()
    {
        StartCoroutine(TutNonsense());
    }

    IEnumerator TutNonsense()
    {
        yield return new WaitForSeconds(1f);
        pan1.SetActive(true);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Mouse0));
        pan1.SetActive(false);
        pan2.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Mouse0));
        pan2.SetActive(false);
        pan3.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Mouse0));
        pan3.SetActive(false);
        pan4.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Mouse0));
        pan4.SetActive(false);
        pan5.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Mouse0));
        pan5.SetActive(false);
        pan6.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        pan6.SetActive(false);
        tutEnd = true;
    }

    IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        while (!Input.GetKeyDown(keyCode))
            yield return null;
    }
}
