using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    public static Managers ins_ = default;
    public SceneMan sceneMan_ = default;
    public FadeMan fadeMan_ = default;
    public SchoolMan schoolMan_ = default;

    public void Awake()
    {
        ins_ = this;
        DontDestroyOnLoad(gameObject);
    }
}
