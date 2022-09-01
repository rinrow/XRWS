using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudio : MonoBehaviour
{
    //Не удалять при загрузке других сцен
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
