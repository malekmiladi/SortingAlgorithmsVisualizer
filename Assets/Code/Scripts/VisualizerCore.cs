using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = Unity.Mathematics.Random;

namespace Code.Scripts
{
    public class VisualizerCore : MonoBehaviour
    {
        private GameVariables _gv;
        [SerializeField]
        private Transform barPrefab;
        [SerializeField]
        private TMP_Dropdown algorithmSelector;
        [SerializeField]
        private Slider animationSpeedSlider;
        private IEnumerator _coroutine;
        private ISortingStrategy _sortingStrategy;

        private void GenerateArray() {
            Random randomNum = new(13579);
            for (var i = 0; i < _gv.Rects.Length; i++) {
                var n = randomNum.NextInt(10, 500);
                var rect = Instantiate(barPrefab);
                rect.position = new Vector2(-6 + i * _gv.BarWidth, -5 + .05F);
                rect.localScale = new Vector2(_gv.BarWidth - .05F, (n * _gv.BarHeight) - .05F);
                _gv.Rects[i] = rect;
            }
        }

        private void Awake()
        {
            _gv = new GameVariables(animationSpeed: 1F);
            RandomizeArray();
        }

        private void DestroyArray()
        {
            foreach (var t in _gv.Rects)
            {
                if (t != null) {
                    Destroy(t.gameObject);
                }
            }
        }

        public void GetSortingStrategy()
        {
            _sortingStrategy = algorithmSelector.value switch
            {
                0 => new BubbleSort(),
                1 => new InsertionSort(),
                2 => new MergeSort(),
                3 => new QuickSort(),
                4 => new SelectionSort(),
                _ => _sortingStrategy
            };
        }

        public void RandomizeArray() {
            DestroyArray();
            GenerateArray();
        }

        public void SetAnimationSpeed(float animationSpeed) {
            _gv.AnimationSpeed = animationSpeed;
        }

        public void SortArray()
        {
            if (_gv.IsRunning)
            {
                StopCoroutine(_coroutine);
                _gv.IsRunning = false;
            }
            else
            {
                _gv.IsRunning = true;
                GetSortingStrategy();
                _coroutine = _sortingStrategy.Sort(_gv);
                StartCoroutine(_coroutine);
            }
        }

        public void QuitGame() {
            Application.Quit();
        }
    }
}
