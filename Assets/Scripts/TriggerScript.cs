using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerScript : MonoBehaviour
{
    public GameObject animatecamera;
    public PlayableDirector timeline;
    public GameObject FPScamera;
    public float timeincutscene;
    bool cutsceneactivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!cutsceneactivated)
        {
            timeline.Play();
            animatecamera.SetActive(true);
            FPScamera.SetActive(false);
            cutsceneactivated = true;

            StartCoroutine(returncamera());
        }
    }

    private IEnumerator returncamera()
    {
        yield return new WaitForSeconds(timeincutscene);

        animatecamera.SetActive(false);
        FPScamera.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        cutsceneactivated = false;
    }
}
