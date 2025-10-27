using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleNextScene : MonoBehaviour
{
    [SerializeField] private string nextSceneName; // Inspectorで次のシーン名を指定

    void Update()
    {
        // マウスクリック（左）または画面タップで次のシーンへ
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                Debug.LogWarning("次のシーン名が指定されていません！");
            }
        }
    }
}
