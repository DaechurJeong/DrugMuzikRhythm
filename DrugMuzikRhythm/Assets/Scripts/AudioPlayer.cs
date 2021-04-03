using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource m_MyAudioSource;

    bool m_Play;
    bool m_ToggleChange;
    // Start is called before the first frame update
    void Start()
    {
        m_MyAudioSource = GetComponent<AudioSource>();
        m_Play = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Check to see if you just set the toggle to positive
        if (m_Play == true && m_ToggleChange == true)
        {
            //Play the audio you attach to the AudioSource component
            m_MyAudioSource.Play();
            //Ensure audio doesn’t play more than once
            m_ToggleChange = false;
        }
        //Check if you just set the toggle to false
        if (m_Play == false && m_ToggleChange == true)
        {
            //Stop the audio
            m_MyAudioSource.Stop();
            //Ensure audio doesn’t play more than once
            m_ToggleChange = false;
        }
    }

    void OnGUI()
    {
        GUIStyle myToggleStyle = new GUIStyle(GUI.skin.toggle);
        myToggleStyle.normal.textColor = Color.black;
        m_Play = GUI.Toggle(new Rect(10, 10, 100, 30), m_Play, "Play Music", myToggleStyle);
        if(GUI.changed)
        {
            m_ToggleChange = true;
        }
    }
}
