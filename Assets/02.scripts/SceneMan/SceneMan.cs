using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Def.Enum;
using System;
     

public class SceneMan : MonoBehaviour
{
    public static SceneMan ins;
    private Stack<sceneNameNMode> stackScene;

    private void Awake()
    {
        ins = this;

        stackScene = new Stack<sceneNameNMode>();

        sceneNameNMode sceneNameNMode = new sceneNameNMode(enumSceneName.Home, LoadSceneMode.Single);
        stackScene.Push(sceneNameNMode);
    }

    /// <summary> 씬을 로드하고, 씬 리스트에 추가한다</summary>
    /// <param name="enumSceneName">로드할 씬</param>
    /// <param name="loadSceneMode">로드 모드</param>
    /// <param name="onDonee">로드가 끝나면 추가적으로 실행할 메소드</param>
    public void PushScene(enumSceneName enumSceneName, LoadSceneMode loadSceneMode, Action onDone = null)
    {
        SceneManager.LoadScene(enumSceneName.ToString(), loadSceneMode);
        sceneNameNMode sceneNameNMode = new sceneNameNMode(enumSceneName, loadSceneMode);
        stackScene.Push(sceneNameNMode);
        onDone?.Invoke();
    }

    /// <summary>이전 씬으로 돌아가고, 현재 씬은 리스트에서 삭제</summary>
    /// <param name="onDonee">로드가 끝나면 추가적으로 실행할 메소드</param>
    public void PopScene(Action onDone = null)
    {
        sceneNameNMode sceneNameNMode = stackScene.Pop();
        AsyncOperation asyncOperation;
        if (sceneNameNMode.loadSceneMode == LoadSceneMode.Additive) asyncOperation = SceneManager.UnloadSceneAsync(sceneNameNMode.enumSceneName.ToString());
        else asyncOperation = SceneManager.LoadSceneAsync(sceneNameNMode.enumSceneName.ToString(), sceneNameNMode.loadSceneMode);

        onDone?.Invoke();
    }

    /// <summary>씬 이름과 로드 모드</summary>
    private struct sceneNameNMode
    {
        public enumSceneName enumSceneName;
        public LoadSceneMode loadSceneMode;

        public sceneNameNMode(enumSceneName SceneName, LoadSceneMode SceneMode)
        {
            enumSceneName = SceneName;
            loadSceneMode = SceneMode;
        }
    }
}
