using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSounds : MonoBehaviour
{private AudioSource source;
public AudioClip[] sounds;

    // Start is called before the first frame update
    void Start()
    {
		source = GetComponent<AudioSource>();   
		int randSound = Random.Range(0, sounds.Length);
		source.clip = sounds[randSound];
		source.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
