using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnowdramaUtils
{
    public class OneShotAudio : MonoBehaviour
    {
        AudioSource source;
        // Start is called before the first frame update
        void Start()
        {
            source = this.GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            if(!source.isPlaying)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
