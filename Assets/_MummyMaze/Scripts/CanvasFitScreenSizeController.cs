using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFitScreenSizeController : MonoBehaviour
{
    public CanvasScaler canvasScaler;
    // Start is called before the first frame update
    void Start()
    {
        if (Screen.width / Screen.height < 9f / 16f)
        {
            canvasScaler.matchWidthOrHeight = 1;
        }
        else if (Screen.width / Screen.height > 9f / 16f) {
            canvasScaler.matchWidthOrHeight = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
