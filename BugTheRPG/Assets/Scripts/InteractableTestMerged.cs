using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableTestMerged : MonoBehaviour
{
    public Text textConverse;
    public Text interactHint;
    public GameObject dialougeUi;
    public bool converseDone;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        dialougeUi.SetActive(false);
        interactHint.text = "";
        textConverse.text = "";
        converseDone = false;
    }

    public void OnTriggerEnter(Collider other)
    {

        Debug.Log("Triggered");
        if (other.CompareTag("Bloop"))
        {
            interactHint.text = "Press E to Interact";
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Triggered the E");
            other.gameObject.GetComponent<PartyMovementController>().enabled = false;
            interactHint.text = "";
            StartCoroutine(TestConverse());

            //if (converseDone == true)
           // {
            //    other.GetComponent<PartyMovementController>().enabled = true;
                
           // }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        interactHint.text = "";
    }

    public IEnumerator TestConverse()
    {
        Debug.Log("Triggered Converse");
        dialougeUi.SetActive(true);

        textConverse.text = "Hi, I'm Steve The Sphere";

        yield return new WaitForSecondsRealtime(5);

        textConverse.text = "I haven't got much to say";

        yield return new WaitForSecondsRealtime(5);

        textConverse.text = "Nice meeting you";

        yield return new WaitForSecondsRealtime(5);

        textConverse.text = "";

        dialougeUi.SetActive(false);

        player.GetComponent<PartyMovementController>().enabled = true;
        
    }
}
