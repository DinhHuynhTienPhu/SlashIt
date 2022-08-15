using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AutoPlayBGM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
//        AudioController.PlayMusicPlaylist();
    }
    private void OnEnable()
    {
        AudioController.PlayMusicPlaylist();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
