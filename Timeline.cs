using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Timeline : MonoBehaviour
{
    [SerializeField] GameObject uI;
    [SerializeField] AudioClip speechSFX;
    [SerializeField] float speechSFXVol = 0.9f;
    PlayableDirector timeline;
    PlayerHealth player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
        player = FindObjectOfType<PlayerHealth>();
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
        yield return new WaitForSeconds(1f);
        AudioSource.PlayClipAtPoint(speechSFX, player.transform.position, speechSFXVol);
    }
}
