using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSetSize : MonoBehaviour
{
    public RectTransform ui;
    public RectTransform GameCanvas;

    public Camera camera;

    public void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
     //   Screen.SetResolution(1920, 1080, true);
    }
    public void Start()
    {
        if(ui != null && GameCanvas != null)
        {
            float height = GetComponent<RectTransform>().rect.height;
            ui.sizeDelta = new Vector2(ui.sizeDelta.x, height * 0.2f);
            GameCanvas.sizeDelta = new Vector2(GameCanvas.sizeDelta.x, height * 0.8f);
        }
        


        Rect rect = camera.rect;
        float scaleheight = ((float)Screen.width / Screen.height) / ((float)9 / 16); // (가로 / 세로)
        float scalewidth = 1f / scaleheight;
        if (scaleheight < 1)
        {
            rect.height = scaleheight;
            rect.y = (1f - scaleheight) / 2f;
        }
        else
        {
            rect.width = scalewidth;
            rect.x = (1f - scalewidth) / 2f;
        }
        camera.rect = rect;
    }


    void OnPreCull() => GL.Clear(true, true, Color.black);
}
