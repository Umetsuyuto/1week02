using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private int maxHP = 4;
    [SerializeField] private float invincibleTime = 1f;
    [SerializeField] private Image[] lifeImages;
    [SerializeField] private float blinkInterval = 0.18f;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private string gameOverSceneName;

    private int currentHP;
    private bool isInvincible = false;
    private Coroutine blinkCoroutine;
    private int lastDamagedIndex = -1;

    private readonly Color32 brightColor = new Color32(255, 255, 255, 255);
    private readonly Color32 darkColor = new Color32(90, 90, 90, 255);
    private readonly Color32 blinkColor = new Color32(60, 60, 60, 255);

    private bool isDie = false;

    void Start()
    {
        if (lifeImages == null || lifeImages.Length < 3)
            Debug.LogWarning("lifeImages が設定されていないか数が足りません。Inspectorで3つ入れてください。");

        currentHP = maxHP;
        UpdateLifeUI();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isInvincible) return;

        if (isDie) return;

        if (other.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return;

        int prevHP = currentHP;
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        if (currentHP <= 0)
        {
            // 暗くなる対象を UI に反映
            int damagedIndex = Mathf.Clamp(prevHP - 1, 0, lifeImages.Length - 1);
            SetImageDark(damagedIndex);
            UpdateLifeUI();

                // Die アニメーション再生してシーン遷移
                playerAnimator.SetTrigger("die");
                isDie = true;
                StartCoroutine(WaitForDieAnimation());
                return;
        }

        // HP>0 の場合：今回暗くなる1つを決める
        lastDamagedIndex = Mathf.Clamp(currentHP - 1, 0, lifeImages.Length - 1);
        UpdateLifeUI();
        playerAnimator.SetTrigger("hurt");

        // 点滅処理開始
        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
            blinkCoroutine = null;
        }
        blinkCoroutine = StartCoroutine(BlinkSingleImage(lastDamagedIndex));
        StartCoroutine(InvincibleTimer());
    }

    private void UpdateLifeUI()
    {
        int brightCount = Mathf.Clamp(currentHP - 1, 0, lifeImages.Length);

        for (int i = 0; i < lifeImages.Length; i++)
        {
            if (i < brightCount)
                lifeImages[i].color = brightColor;
            else
                lifeImages[i].color = darkColor;
        }
    }

    private IEnumerator BlinkSingleImage(int index)
    {
        if (index < 0 || index >= lifeImages.Length) yield break;

        while (true)
        {
            lifeImages[index].color = blinkColor;
            yield return new WaitForSeconds(blinkInterval);
            lifeImages[index].color = darkColor;
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    private IEnumerator InvincibleTimer()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibleTime);

        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
            blinkCoroutine = null;
        }
        lastDamagedIndex = -1;
        UpdateLifeUI();
        isInvincible = false;
    }

    private void SetImageDark(int index)
    {
        if (index < 0 || index >= lifeImages.Length) return;
        lifeImages[index].color = darkColor;
    }

    private IEnumerator WaitForDieAnimation()
    {
        // Die ステート情報を取得
        AnimatorStateInfo dieState = playerAnimator.GetCurrentAnimatorStateInfo(0);

        // Die が再生されるまで1フレーム待つ
        yield return null;

        // Die の再生時間分待つ
        float dieLength = dieState.length;
        yield return new WaitForSeconds(dieLength);

        // シーン遷移
        if (!string.IsNullOrEmpty(gameOverSceneName))
        {
            SceneManager.LoadScene(gameOverSceneName);
        }
    }


    public void Heal(int amount)
    {
        currentHP = Mathf.Clamp(currentHP + amount, 0, maxHP);
        UpdateLifeUI();
    }

    public int GetCurrentHP() => currentHP;

    public bool IsDie()
    {
        return isDie;
    }
}
