using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timelineManager : MonoBehaviour
{

    public Text subtitles;
    [TextArea(5,10)]
    public string[] subtitleStrings;
    int currentSubtitleIndex;

    void Start()
    {
        subtitles.text = "";
        currentSubtitleIndex = 0;
    }


    void Update()
    {
        
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
}
