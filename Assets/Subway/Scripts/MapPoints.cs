using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MapPoints : MonoBehaviour
{
    public AudioClip[] clips;
    public Texture[] images;
    public RawImage map;
    private String[] clipNames;

    private void Start()
    {
        clipNames = new String[clips.Length];
        for (int i = 0; i < clips.Length; i++)
        {
            clipNames[i] = clips[i].name.ToString();
        }
    }
    
    public void ChangeLights(String clip)
    {
        // case switch: if the clip's name is clip1, then change the lights to the first set
        int ind_clip = Array.IndexOf(clipNames, clip);
        
        map.texture = images[ind_clip];   
    }
}
