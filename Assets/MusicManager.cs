using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    void Awake() {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        
        if (objs.Length > 1){
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

    }

    public int mainMenuIndex = 0;
    public int world1Index = 1;
    public int world2Index = 4;
    public int world3Index = 7;

    public List<AudioClip> songs = new List<AudioClip>();

    private AudioSource aud;

    void Start()
    {
        aud = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
