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
    private int currentSongIndex = -1; // Track which song is currently playing
    private bool isInitialized = false;

    //AudioSource Component
    private AudioSource audioSource;

    private void Awake()
    {
        Debug.Log("MusicManager Awake called");

        // CRITICAL FIX: Make sure the GameObject is at the root level
        if (transform.parent != null)
        {
            // This is not a root GameObject, so we need to make it one
            Debug.LogWarning("MusicManager must be a root GameObject for DontDestroyOnLoad to work. Moving to root.");
            transform.SetParent(null);
        }

        // Singleton pattern to ensure only one MusicManager exists
        if (Instance == null)
        {
            Debug.Log("Setting up MusicManager singleton instance");
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeManager();
        }
        else
        {
            Debug.Log("Destroying duplicate MusicManager");
            Destroy(gameObject);
        }
    }

    private void InitializeManager()
    {
        if (isInitialized) return;

        Debug.Log("Initializing MusicManager");

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

        isInitialized = true;

        // Handle the initial scene
        string initialSceneName = SceneManager.GetActiveScene().name;
        if (sceneToPlaylist.TryGetValue(initialSceneName, out string initialPlaylistName))
        {
            currentPlaylistName = initialPlaylistName;
            if (playlists.TryGetValue(initialPlaylistName, out currentSongList))
            {
                PlayRandomSong();
            }
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
        Debug.Log($"Scene loaded: {sceneName}");

        //Check if scene has been assigned a playlist
        if (sceneToPlaylist.TryGetValue(sceneName, out string newPlaylistName))
        {
            Debug.Log($"Scene {sceneName} has playlist: {newPlaylistName}, current playlist: {currentPlaylistName}");

            //If the playlist changes
            if (newPlaylistName != currentPlaylistName)
            {
                Debug.Log($"Changing playlist from {currentPlaylistName} to {newPlaylistName}");
                // Store the previous playlist name for comparison
                string previousPlaylist = currentPlaylistName;
                currentPlaylistName = newPlaylistName;

                //Get the new playlist's song list
                if (playlists.TryGetValue(newPlaylistName, out currentSongList))
                {
                    //Stop any ongoing music and coroutines
                    StopAllCoroutines();

                    // If music is already playing, transition to new playlist
                    if (audioSource.isPlaying)
                    {
                        StartCoroutine(TransitionToNewPlaylist());
                    }
                    else
                    {
                        //Play a new random song from the new playlist
                        PlayRandomSong();
                    }
                }
                else
                {
                    Debug.LogWarning($"Playlist '{newPlaylistName}' not found!");
                }
            }
            else
            {
                Debug.Log("Playlist hasn't changed, continuing current song");
                //If the playlist is the same, do nothing; current song continues
            }
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
        currentSongIndex = index; // Store the current song index
        AudioClip selectedSong = currentSongList[index];
        Debug.Log($"Playing song: {selectedSong.name} from playlist: {currentPlaylistName}");

        audioSource.clip = selectedSong;
        audioSource.volume = 1.0f; // Ensure full volume for new songs
        audioSource.Play();

        //Start coroutine to wait for song end
        StartCoroutine(WaitForSongEnd());
    }

    private IEnumerator WaitForSongEnd()
    {
        //Wait for the song to finish
        float songLength = audioSource.clip.length;
        Debug.Log($"Waiting for song to end: {songLength} seconds");
        yield return new WaitForSeconds(songLength);

        Debug.Log("Song ended, playing next song");
        //Play another random song from the current playlist
        PlayRandomSong();
    }

    private IEnumerator TransitionToNewPlaylist()
    {
        Debug.Log("Transitioning to new playlist");
        // Fade out current song
        yield return StartCoroutine(FadeOut(fadeDuration));

        // Then play a new song from the new playlist
        PlayRandomSong();
    }

    private IEnumerator FadeOut(float duration)
    {
        float startVolume = audioSource.volume;
        Debug.Log($"Fading out from volume: {startVolume}");

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / duration;
            yield return null;
        }
        audioSource.Stop();
        audioSource.volume = startVolume;
        Debug.Log("Fade out complete");
    }

    private IEnumerator FadeIn(float duration, AudioClip newClip)
    {
        audioSource.clip = newClip;
        audioSource.volume = 0;
        audioSource.Play();
        Debug.Log($"Fading in song: {newClip.name}");

        while (audioSource.volume < 1)
        {
            audioSource.volume += Time.deltaTime / duration;
            yield return null;
        }
        Debug.Log("Fade in complete");
    }
}