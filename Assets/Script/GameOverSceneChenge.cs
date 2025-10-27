using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneChenge : MonoBehaviour
{
    [SerializeField] private string nextSceneName;

    void Update()
    {
        // マウス（左）離した瞬間  or  タッチ終了
        bool mouseUp = Input.GetMouseButtonUp(0);
        bool touchUp = false;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended) touchUp = true;
        }

        if (mouseUp || touchUp)
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
