using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;
using UnityEngine.SceneManagement;
using Common.SoundManager;

namespace RaMen.Result
{
    public class ResultView : MonoBehaviour
    {
        [Inject]
        private SoundManager _SoundManager;

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
                ChangeToTapScene();

            })
            .AddTo(this);
        }

        public void ResultPanelActive()
        {
            _ResultPanel.gameObject.SetActive (true);
        }

        public void ChangeToTapScene()
        {
            _SoundManager.StopBgm();
            SceneManager.LoadScene("RaMEN");
        }

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
