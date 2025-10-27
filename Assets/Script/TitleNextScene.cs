using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleNextScene : MonoBehaviour
{
    [SerializeField] private string nextSceneName; // Inspector�Ŏ��̃V�[�������w��

    void Update()
    {
        // �}�E�X�N���b�N�i���j�܂��͉�ʃ^�b�v�Ŏ��̃V�[����
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
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
