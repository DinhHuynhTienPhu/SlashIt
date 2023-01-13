using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SimpleChat : MonoBehaviour
{
    public List<string> chatmgs;
    public Text txtChat;
    public int i =0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        i++;
        txtChat.text = chatmgs[i%chatmgs.Count];
    }
}
