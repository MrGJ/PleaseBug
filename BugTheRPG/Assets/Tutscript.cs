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

    // Start is called before the first frame update
    void Start()
    {
        pan1.SetActive(false);
        pan2.SetActive(false);
        pan3.SetActive(false);
        pan4.SetActive(false);
        pan5.SetActive(false);
        StartCoroutine(TutNonsense());
    }

    // Update is called once per frame
    IEnumerator TutNonsense()
    {
        yield return new WaitForSeconds(1f);
        pan1.SetActive(true);
        yield return new WaitForSeconds(5f);
        pan1.SetActive(false);
        pan2.SetActive(true);
        yield return new WaitForSeconds(5f);
        pan2.SetActive(false);
        pan3.SetActive(true);
        yield return new WaitForSeconds(5f);
        pan3.SetActive(false);
        pan4.SetActive(true);
        yield return new WaitForSeconds(5f);
        pan4.SetActive(false);
        pan5.SetActive(true);
        yield return new WaitForSeconds(5f);
        pan5.SetActive(false);
    }
}
