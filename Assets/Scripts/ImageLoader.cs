using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    public Image image;
    public string imageUrl;

    private void Start()
    {
        //Simple usage - Single line of code and ready to go!
        Davinci.get().load(imageUrl).into(image).start();
    }
}
