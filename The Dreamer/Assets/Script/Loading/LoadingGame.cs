using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LoadingGame : MonoBehaviour
{
    public CanvasGroup loadingSceenGroup;
    public Image loadingBar;

    public float fadeDuration = 0.5f; //thời gian cho hiệu ứng mờ dần, dotween
    public float loadTime = 2.5f;

    [SerializeField] Animator animator;

    public void LoadGameScene(string nameScene)
    {
        StartCoroutine(LoadSceneCoroutine(nameScene));
    }

    private IEnumerator LoadSceneCoroutine(string nameScene)
    {
        loadingSceenGroup.gameObject.SetActive(true);
        loadingSceenGroup.blocksRaycasts = true; 
        loadingBar.fillAmount = 0f;

        animator.SetBool("isOpen", false);

        //Fade in màn hình đen từ từ
        loadingSceenGroup.DOFade(1f, fadeDuration);
        yield return new WaitForSeconds(fadeDuration);

        //Lưu lại mốc thời gian bắt đầu load
        float startTime = Time.time;

        //Tải scene ngầm
        AsyncOperation operation = SceneManager.LoadSceneAsync(nameScene);
        operation.allowSceneActivation = false; //ngăn chuyển sang Scene khác đột ngột

        float displayProgress = 0f; //làm thanh trượt mượt

        //Vòng lặp xử lý thanh trượt
        while (!operation.isDone)
        {
            float targetProgress = Mathf.Clamp01(operation.progress / 0.9f);
            displayProgress = Mathf.MoveTowards(displayProgress, targetProgress, 2f * Time.deltaTime);
            loadingBar.fillAmount = displayProgress;

            //Kiểm tra đk chuyển scene
            if (operation.progress >= 0.9f && displayProgress >= 0.99f)
            {
                float timeLoad = Time.time - startTime;
                if (timeLoad < loadTime)
                {
                    yield return new WaitForSeconds(loadTime - timeLoad);
                }

                loadingBar.fillAmount = 1f;

                animator.SetBool("isOpen", true);

                yield return new WaitForSeconds(1.5f);
                operation.allowSceneActivation = true;

                yield break;
            }
            yield return null; //giúp cho vòng while không bị treo
        }
    }
}
