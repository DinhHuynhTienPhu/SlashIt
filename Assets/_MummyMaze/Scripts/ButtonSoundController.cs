using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonSoundController : MonoBehaviour
{
    public Button thisbtn;
    // Start is called before the first frame update
    void Start()
    {
        thisbtn = gameObject.GetComponent<Button>();
        thisbtn.onClick.AddListener(PlaySound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PlaySound() {
        AudioController.Play("switch_button_push_small_03");
    }
}
