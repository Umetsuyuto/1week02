using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneChenge : MonoBehaviour
{
    [SerializeField] private string nextSceneName;

    void Update()
    {
        // �}�E�X�i���j�������u��  or  �^�b�`�I��
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
                Debug.LogWarning("���̃V�[�������w�肳��Ă��܂���I");
            }
        }
    }
}
