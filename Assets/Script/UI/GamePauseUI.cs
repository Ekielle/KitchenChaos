using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button optionsButton;

    private void Awake() {
        resumeButton.onClick.AddListener(() => {
            KitchenGameManager.Instance.TogglePauseGame();
        });
        mainMenuButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
        optionsButton.onClick.AddListener(() => {
            Hide();
            OptionUI.Instance.Show(Show);
        });
    }

    private void Start() {
        KitchenGameManager.Instance.OngamePaused += KitchenGameManager_OngamePaused;
        KitchenGameManager.Instance.OngameUnpaused += KitchenGameManager_OngameUnpaused;

        Hide();
    }

    private void KitchenGameManager_OngameUnpaused(object sender, EventArgs e)
    {
        Hide();
    }

    private void KitchenGameManager_OngamePaused(object sender, EventArgs e)
    {
        Show();
    }

    private void Show() {
        gameObject.SetActive(true);

        resumeButton.Select();
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

}
