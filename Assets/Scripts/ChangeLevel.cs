using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    [SerializeField] [NotNull] private string sceneNameToLoad = "MainScene";

    public void PlayEasy()
    {
        LoadLevel(Level.Easy);
    }

    public void PlayMedium()
    {
        LoadLevel(Level.Medium);
    }

    public void PlayHard()
    {
        LoadLevel(Level.Hard);
    }

    private void LoadLevel(Level level)
    {
        switch (level)
        {
            case Level.Easy:
                WorldSettings.Instance.Level = Level.Easy;
                break;
            case Level.Medium:
                WorldSettings.Instance.Level = Level.Medium;
                break;
            case Level.Hard:
                WorldSettings.Instance.Level = Level.Hard;
                break;
        }
        
        Debug.Log(WorldSettings.Instance.Level);

        SceneManager.LoadScene(sceneNameToLoad);
    }
}
