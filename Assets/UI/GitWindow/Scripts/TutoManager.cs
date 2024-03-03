using System.Collections.Generic;
using UnityEngine;

namespace UI.GitWindow.Scripts
{
    public class TutoManager : MonoBehaviour
    {
        
        [Header("Tutorial scenes")]
        [SerializeField] private List<GameObject> tutoScenes;

        private bool _firstCommitSelected;
        private bool _secondCommitSelected;
        private bool _isTutoActive = true;

        private void Start()
        {
            if (!_isTutoActive) return;
            tutoScenes[0].SetActive(true);
            _isTutoActive = false;
        }

        private void Update()
        {
            if (_firstCommitSelected && tutoScenes[1].activeSelf)
            {
                NextTuto2();
            }
            else if (_secondCommitSelected && tutoScenes[2].activeSelf)
            {
                tutoScenes[2].SetActive(false);
            }
        }

        public void NextTuto1()
        {
            tutoScenes[0].SetActive(false);
            tutoScenes[1].SetActive(true);
        }
        private void NextTuto2()
        {
            tutoScenes[1].SetActive(false);
            tutoScenes[2].SetActive(true);
        }

        public void SetFirstCommit()
        {
            _firstCommitSelected = true;
        }

        public void SetSecondCommit()
        {
            _secondCommitSelected = true;
        }
    }
}
