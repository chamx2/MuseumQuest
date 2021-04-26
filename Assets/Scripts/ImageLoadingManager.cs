using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageLoadingManager : MonoBehaviour
{
    public ImageLoader[] loaders;
    public string[] urls;
    private void Awake()
    {
       loaders = FindObjectsOfType<ImageLoader>();
        for (int i = 0; i<loaders.Length; i++) {
            if (urls.Length > i)
            {
                loaders[i].imageUrl = urls[i];
                Debug.Log("HERE");
            }
            else {
                loaders[i].imageUrl = urls[urls.Length-1];
            }
        }
    }
}
