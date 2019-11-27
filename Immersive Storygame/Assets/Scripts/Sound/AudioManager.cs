using UnityEngine.Audio;
//Dit hieronder is voor het onderste gedeelte, de public void
using System;
using UnityEngine;

[System.Serializable]
public class Sound {
    public AudioClip clip;
    public string name;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
 
    [HideInInspector]
    public AudioSource source;
}

//volg de video :)
//Maak eerst een nieuw object aan en maak dat een audio manager
public class AudioManager : MonoBehaviour 
{

    public Sound [] sounds;

    //use this for initialization
    //Ik heb dit veranderd naar Awake zoals in de video
    void Awake ()
    {
        foreach (Sound s in sounds)
        {
            //s.source is later toegevoegd om te zoeken naar die s sound hierboven
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    //update is called once per frame
    //KIJK HIER, ik heb update in comments gezet aangezien hij een nieuwe manier gebruikt om dingen aan te sturen
    //void update (){
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
