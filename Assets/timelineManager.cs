using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class timelineManager : MonoBehaviour
{
    public UnityEvent[] events;

    public Text subtitles;
    [TextArea(5,10)]
    public string[] subtitleStrings;
    public int currentSubtitleIndex;
    public int currentEventIndex;
    Animation timelineAnimation;

    private void Awake()
    {
        timelineAnimation = GetComponent<Animation>();
        ClearSubtitles();
        currentSubtitleIndex = -1;
        currentEventIndex = -1;
    }

    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            ResumeTimeline();
        }
    }


    public void ClearSubtitles()
    {
        subtitles.text = "";
    }

    public void NextSubtitles()
    {
        subtitles.text = subtitleStrings[++currentSubtitleIndex];
    }

    public void SetSubtitles(int i)
    {
        currentSubtitleIndex = i;
        subtitles.text = subtitleStrings[currentSubtitleIndex];
    }

    public void NextEvent()
    {
        events[++currentEventIndex].Invoke();
    }

    public void CallEvent(int i)
    {
        currentEventIndex = i;
        events[currentEventIndex].Invoke();
    }

    public void PauseTimeline()
    {
        timelineAnimation.enabled = false;
    }

    public void ResumeTimeline()
    {
        timelineAnimation.enabled = true;
    }
}
