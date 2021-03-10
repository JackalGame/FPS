using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Timeline : MonoBehaviour
{
    [SerializeField] GameObject uI;
    PlayableDirector timeline;
    
    
    // Start is called before the first frame update
    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }

    public void PlayTimeline()
    {
        StartCoroutine(TimelineSequence());
    }

    IEnumerator TimelineSequence()
    {
        timeline.Play();
        uI.SetActive(false);
        yield return new WaitForSeconds(10.5f);
        uI.SetActive(true);
    }
}
