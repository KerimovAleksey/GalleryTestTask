using UnityEngine;
using UnityEngine.UI;

public static class ScenesBridge
{
    private static Texture _image;

    public static void SendImage(Texture newImage)
    {
        _image = newImage;
    }

    public static Texture GetImage()
    {
        return _image;
    }
}
