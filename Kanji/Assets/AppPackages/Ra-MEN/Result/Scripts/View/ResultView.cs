using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;

namespace RaMen.Result
{
    public class ResultView : MonoBehaviour
    {
        [SerializeField]
        private Button _RestartButton;

        [SerializeField]
        private Text _ThisTimeScoreText;

        [SerializeField]
        private Text _HighScoreText;

        [SerializeField]
        private Image _GameOverImage;

        [SerializeField]
        private Transform _ResultPanel;

        [SerializeField]
        private GameOverImage _ScriptableGameOverImage;

        void Awake()
        {
            _RestartButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                _RestartButton.interactable = false;
                // ChangeToTapScene();

            })
            .AddTo(this);
        }

        public void ResultPanelActive()
        {
            _ResultPanel.gameObject.SetActive (true);
        }

        // public void ChangeToTapScene()
        // {
        //     SceneManager.LoadScene(SCENE_TO_TAP_SCENE);
        // }

        public void ScoreTextUpdate(int score, int highScore)
        {
            _ThisTimeScoreText.text = score.ToString();
            _HighScoreText.text = highScore.ToString();
        }

        public void ChangeGameOverImage()
        {
            _GameOverImage.sprite = _ScriptableGameOverImage.GameOverImageSprite;
        }

        public void ChangeGameClearImage()
        {
            _GameOverImage.sprite = _ScriptableGameOverImage.GameClearImageSprite;
        }
    }
}
