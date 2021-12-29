using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelIndicatorAnimation : MonoBehaviour
{
    [SerializeField]
    // RectTransform WelcomeRT, LevelRT, LastBtn;
    RectTransform WelcomeRT, LevelRT;
    [SerializeField]
    CanvasGroup InstCV, LevelCV;
    //CanvasGroup InstCV, LevelCV, FinishCV;
    [SerializeField]
     TMP_Text LevelText;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        WelcomeRT.DOScale(1f, 0.65f);

        yield return new WaitForSeconds(3f);
        WelcomeRT.DOScale(0f, 0.45f);
        InstCV.DOFade(1f, 0.65f);

        yield return new WaitForSeconds(5f);
        InstCV.DOFade(0f, 0.45f);

       //ShowLevel();
    }

    public void ShowLevel()
    {
        StartCoroutine(Show());
    }

    IEnumerator Show()
    {
        LevelText.text = "Rocket Launch ";
        LevelRT.DOScaleX(1f, 0.65f);
        LevelCV.DOFade(1f, 0.65f);

        yield return new WaitForSeconds(3f);
        LevelRT.DOScaleX(0f, 0.45f);
        LevelCV.DOFade(0f, 1f);
    }

    public void EndPanel()
    {
        StartCoroutine(Anim());
    }

    IEnumerator Anim()
    {
       // FinishCV.DOFade(1f, 0.35f);
        //FinishCV.blocksRaycasts = true;
        yield return new WaitForSeconds(3f);
        //LastBtn.DOScale(1f, 0.3f);
        MainMenu();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
