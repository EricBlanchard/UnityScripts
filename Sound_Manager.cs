using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//These are the enums that you can use to split up the clips
public enum clip_type
{
    Music
}

[Serializable]
public struct Audio_Entry {

    public string name;
    public AudioClip clip;
    public clip_type genre;
}

public class Sound_Manager : Singleton<Sound_Manager> {

    public List<AudioSource> audio_sources = new List<AudioSource>();

    //The music player should have a private source so there is always one available
    public AudioSource music_player;

    //Name the clips and drag them in here
    public List<Audio_Entry> audio_clips = new List<Audio_Entry>();

    //Troll through the list of sounds for the song and drop that beat
    public void Play_Music(string music_clip)
    {
        for (int i = 0; i < audio_clips.Count; i++)
        {
            if (music_clip == audio_clips[i].name)
            {
                music_player.clip = audio_clips[i].clip;
            }
        }
        music_player.Play();
    }
    
    public void Play_Event(clip_type genre)
    {
        List<AudioClip> genre_clips = new List<AudioClip>();
        for (int i = 0; i < audio_clips.Count; i++)
        {
            if (audio_clips[i].genre == genre)
            {
                genre_clips.Add(audio_clips[i].clip);
            }
        }
        int index = UnityEngine.Random.Range(0, genre_clips.Count);
        AudioSource temp_source = Get_Free_Source();
        temp_source.clip = genre_clips[index];
        temp_source.Play();
    }

    //Call this bad boy whenever we're looking for an audiosource to play something
    public AudioSource Get_Free_Source()
    {
        for (int i = 0; i < audio_sources.Count; i++)
        {
            if (!audio_sources[i].isPlaying){
                return audio_sources[i];
            }
        }
            return null;
    }
}
