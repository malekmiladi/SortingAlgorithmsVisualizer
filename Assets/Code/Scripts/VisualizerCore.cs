using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = Unity.Mathematics.Random;

public class VisualizerCore : MonoBehaviour
{
    private GameVariables gv = new(animationSpeed: 1F);
    [SerializeField]
    private Transform barPrefab;
    [SerializeField]
    private TMP_Dropdown algorithmSelector;
    [SerializeField]
    private Slider animationSpeedSlider;
    private IEnumerator _coroutine;

    public void GenerateArray() {
        for (int i = 0; i < gv.Rects.Length; i++) {
            if (gv.Rects[i] != null) {
                Destroy(gv.Rects[i].gameObject);
            }
        }
        Random randomNum = new(13579);
        for (int i = 0; i < gv.Rects.Length; i++) {
            int n = randomNum.NextInt(10, 500);
            Transform rect = Instantiate(barPrefab);
            rect.position = new Vector2(-6 + i * gv.BarWidth, -5 + .05F);
            rect.localScale = new Vector2(gv.BarWidth - .05F, (n * gv.BarHeight) - .05F);
            gv.Rects[i] = rect;
        }
    }

    public void GetAlgorithmDropdownValue() {
        switch (algorithmSelector.value)
        {
            case 0:
                _coroutine = BubbleSort.Sort(gv);
                break;
            case 1:
                _coroutine = InsertionSort.Sort(gv);
                break;
            case 2:
                _coroutine = MergeSort.Sort(gv);
                break;
            case 3:
                _coroutine = QuickSort.Sort(gv);
                break;
            case 4:
                _coroutine = SelectionSort.Sort(gv);
                break;
            default:
                break;
        }
    }

    public void RandomizeArray() {
        GenerateArray();
    }

    public void GetAnimationSpeed(float animationSpeed) {
        gv.AnimationSpeed = animationSpeed;
    }

    public void SortArray() {
        if (!gv.IsRunning) {
            gv.IsRunning = true;
            GetAlgorithmDropdownValue();
            StartCoroutine(_coroutine);
        } else {
            StopCoroutine(_coroutine);
            gv.IsRunning = false;
        }
    }

    public void QuitGame() {
        Application.Quit();
    }
}
