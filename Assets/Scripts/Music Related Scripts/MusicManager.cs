//MusicManager.cs



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Struct to define a playlist with a name and list of songs
[System.Serializable]
public struct Playlist
{
    public string name;
    public List<AudioClip> songs;
}

//Struct to associate a scene with a playlist
[System.Serializable]
public struct ScenePlaylist
{
    public string sceneName;
    public string playlistName;
}

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    //Lists set in the Inspector
    [SerializeField]
    public List<Playlist> playlistDefinitions = new List<Playlist>();

    [SerializeField]
    private List<ScenePlaylist> scenePlaylists = new List<ScenePlaylist>();

    [SerializeField]
    public float fadeDuration = 1f;

    //Dictionaries for quick lookup
    private Dictionary<string, List<AudioClip>> playlists;
    private Dictionary<string, string> sceneToPlaylist;

    //Current playlist tracking
    private string currentPlaylistName;
    private List<AudioClip> currentSongList;

    //AudioSource Component
    private AudioSource audioSource;

    private void Awake()
    {
        // Singleton pattern to ensure only one MusicManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            //Get or add AudioSource
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
                Debug.Log("AudioSource added to MusicManager automatically.");
            }
            audioSource.loop = false; // Background music should not loop

            // Initialize dictionaries from Inspector
            playlists = new Dictionary<string, List<AudioClip>>();
            foreach (var pl in playlistDefinitions)
            {
                playlists[pl.name] = pl.songs;
            }

            sceneToPlaylist = new Dictionary<string, string>();
            foreach (var sp in scenePlaylists)
            {
                sceneToPlaylist[sp.sceneName] = sp.playlistName;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string sceneName = scene.name;

        //Check if scene has been assigned a playlist
        if (sceneToPlaylist.TryGetValue(sceneName, out string newPlaylistName))
        {
            //If the playlist changes
            if (newPlaylistName != currentPlaylistName)
            {
                currentPlaylistName = newPlaylistName;

                //Get the new playlist's song list
                if (playlists.TryGetValue(newPlaylistName, out currentSongList))
                {
                    //Stop any ongoing music and coroutines
                    StopAllCoroutines();
                    if (audioSource.isPlaying)
                    {
                        audioSource.Stop();
                    }

                    //Play a new random song from the new playlist
                    PlayRandomSong();
                }
                else
                {
                    Debug.LogWarning($"Playlist '{newPlaylistName}' not found!");
                }
            }
            //If the playlist is the same, do nothing; current song continues
        }
        else
        {
            Debug.LogWarning($"No playlist assigned for scene '{sceneName}'.");
        }
    }

    private void PlayRandomSong()
    {
        if (currentSongList == null || currentSongList.Count == 0)
        {
            Debug.LogWarning("No songs in the current playlist!");
            return;
        }

        //Select and play a random song
        int index = Random.Range(0, currentSongList.Count);
        AudioClip selectedSong = currentSongList[index];
        audioSource.clip = selectedSong;
        audioSource.Play();

        //Start coroutine to wait for song end
        StartCoroutine(WaitForSongEnd());
    }

    private IEnumerator WaitForSongEnd()
    {
        //Wait for the song to finish
        yield return new WaitForSeconds(audioSource.clip.length);

        //Play another random song from the current playlist
        PlayRandomSong();
    }
    //        AudioClip newClip = sceneMusic[sceneName];
    //        if (audioSource.clip != newClip)
    //        {
    //            StartCoroutine(TransitionMusic(newClip, fadeDuration));
    //        }
    //        // If the clip is the same, music continues playing uninterrupted
    //    }
    //    else
    //    {
    //        if (audioSource.isPlaying)
    //        {
    //            StartCoroutine(FadeOut(fadeDuration));
    //        }
    //    }
    //}

    private IEnumerator TransitionMusic(AudioClip newClip, float duration)
    {
        if (audioSource.isPlaying)
        {
            yield return StartCoroutine(FadeOut(duration));
        }
        yield return StartCoroutine(FadeIn(duration, newClip));
    }

    private IEnumerator FadeOut(float duration)
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / duration;
            yield return null;
        }
        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    private IEnumerator FadeIn(float duration, AudioClip newClip)
    {
        audioSource.clip = newClip;
        audioSource.volume = 0;
        audioSource.Play();
        while (audioSource.volume < 1)
        {
            audioSource.volume += Time.deltaTime / duration;
            yield return null;
        }
    }
}