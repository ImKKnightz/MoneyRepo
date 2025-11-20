using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
        [Range(0, 1)] public float volume = 1f;
    }

    public AudioSource source;
    public List<Sound> sounds;
    private Dictionary<string, Sound> dict;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else { Destroy(gameObject); return; }
        DontDestroyOnLoad(gameObject);


        dict = new Dictionary<string, Sound>();
        foreach (var s in sounds)
            dict[s.name] = s;
    }

    public void Play(string name)
    {
        if (dict.ContainsKey(name))
            source.PlayOneShot(dict[name].clip, dict[name].volume);
    }
}
