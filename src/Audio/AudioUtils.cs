using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SnowdramaUtils
{
    public class AudioUtils{
        public static void PlayOneShot2DClip(string name, AudioClip clip, float volume = 1, GameObject parent = null)
        {
            //we null check here so we don't need to null check every audio clip
            if(clip != null)
            {
                GameObject go = new GameObject();
                go.name = name;
                AudioSource source = go.AddComponent<AudioSource>();
                go.AddComponent<OneShotAudio>();
                if(parent != null)
                {
                    go.transform.parent = parent.transform;
                }
                source.volume = volume;
                source.spatialBlend = 0;
                source.clip = clip;
                source.Play();
            }
            else
            {
                Debug.LogError("Clip Played Was Null: " + name);
            }
        }
        public static void PlayOneShot3DClip(string name, AudioClip clip, float volume = 1, GameObject parent = null, float spatialBlend = 0.25f)
        {
            if (clip != null)
            {
                GameObject go = new GameObject();
                go.name = name;
                AudioSource source = go.AddComponent<AudioSource>();
                go.AddComponent<OneShotAudio>();
                if (parent != null)
                {
                    go.transform.parent = parent.transform;
                }
                source.volume = volume;
                source.spatialBlend = spatialBlend;
                source.clip = clip;
                source.Play();
            }
            else
            {
                Debug.LogError("Clip Played Was Null: " + name);
            }
        }
    }
}