using UnityEngine;

[ExecuteInEditMode]
public class CameraAspect : MonoBehaviour
{
    public float targetAspect = 16f / 9f;

    void Awake()
    {
        Set();
    }

    void Set()
    {
        var cam = GetComponent<Camera>();
        if (!cam)
        {
            return;
        }

        float windowaspect = (float)Screen.width / (float)Screen.height; // determine the game window's current aspect ratio
        float scaleheight = windowaspect / targetAspect; // current viewport height should be scaled by this amount

        // if scaled height is less than current height, add letterbox (horizontal bars)
        if (scaleheight < 1.0f)
        {
            Rect rect = cam.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            cam.rect = rect;
        }
        else // add pillarbox (vertical bars)
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = cam.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            cam.rect = rect;
        }
    }

    private void Update()
    {
        Set();
    }
}
