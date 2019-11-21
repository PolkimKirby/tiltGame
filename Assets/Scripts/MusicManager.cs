using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        aud.clip = songs[0];
        aud.Play();
    }

    public IEnumerator StartNextLevel() {
        yield return new WaitForSeconds(0.5f);
        int currentIndex = SceneManager.GetActiveScene().buildIndex;

        if(currentIndex == mainMenuIndex) {
            aud.clip = songs[0];
            aud.Play();
        }
        else if(currentIndex == world1Index) {
            aud.clip = songs[1];
            aud.Play();
        }
        else if(currentIndex == world2Index) {
            aud.clip = songs[2];
            aud.Play();
        }
        else if(currentIndex == world3Index) {
            aud.clip = songs[3];
            aud.Play();
        }
    }
    
    public bool debug = true;

    void Update() {
        if(debug) {
            if(Input.GetKeyDown(KeyCode.Alpha9)) {
                Debug.Log("Starting next level!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                StartCoroutine(StartNextLevel());
            }
            if(Input.GetKeyDown(KeyCode.Alpha0)) {
                Debug.Log("Going to main menu");
                SceneManager.LoadScene(0);
                StartCoroutine(StartNextLevel());
            }
        }
    }
}
