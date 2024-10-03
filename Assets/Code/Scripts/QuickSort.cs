using System.Collections;
using UnityEngine;

public class QuickSort : MonoBehaviour
{
    public static IEnumerator Sort(GameVariables gv) {
        int l = gv.Rects.Length;
        if (l < 1) {
            yield return null;
        }
        Stack partitionStack = new();
        partitionStack.Push(l - 1);
        partitionStack.Push(0);
        while (partitionStack.Count > 0) {
            int start = (int)partitionStack.Pop();
            int end = (int)partitionStack.Pop();
            for (int k = start; k < end + 1; k++) {
                VisualizerUtils.ChangeColor(gv.Rects[k].GetChild(0), Color.cyan);
            }
            int pivot = end;
            int i = start - 1;
            VisualizerUtils.ChangeColor(gv.Rects[pivot].GetChild(0), Color.green);
            VisualizerUtils.ChangeColor(gv.Rects[start].GetChild(0), Color.green);
            for (int j = start; j < end; j++) {
                if (gv.Rects[j].localScale.y < gv.Rects[end].localScale.y) {
                    i++;
                    VisualizerUtils.ChangeColor(gv.Rects[j].GetChild(0), Color.red);
                    VisualizerUtils.ChangeColor(gv.Rects[i].GetChild(0), Color.red);
                    yield return new WaitForSeconds(.2F / gv.AnimationSpeed);
                    Swap(gv.Rects, i, j);
                    VisualizerUtils.ChangeColor(gv.Rects[start].GetChild(0), Color.green);
                    VisualizerUtils.ChangeColor(gv.Rects[j].GetChild(0), Color.cyan);
                    VisualizerUtils.ChangeColor(gv.Rects[i].GetChild(0), Color.cyan);
                }
            }

            i++;
            VisualizerUtils.ChangeColor(gv.Rects[i].GetChild(0), Color.red);
            VisualizerUtils.ChangeColor(gv.Rects[end].GetChild(0), Color.red);
            yield return new WaitForSeconds(.2F / gv.AnimationSpeed);
            Swap(gv.Rects, i, end);
            VisualizerUtils.ChangeColor(gv.Rects[i].GetChild(0), Color.gray);
            VisualizerUtils.ChangeColor(gv.Rects[end].GetChild(0), Color.gray);
            VisualizerUtils.ChangeColor(gv.Rects[pivot].GetChild(0), Color.gray);
            for (int k =  start; k < end + 1; k++) {
                VisualizerUtils.ChangeColor(gv.Rects[k].GetChild(0), Color.gray);
            }
            pivot = i;
            if (start < pivot - 1) {
                partitionStack.Push(pivot - 1);
                partitionStack.Push(start);
            }
            if (pivot + 1 < end) {
                partitionStack.Push(end);
                partitionStack.Push(pivot + 1);
            }
            yield return new WaitForSeconds(.2F / gv.AnimationSpeed);
        }
        for (int k =  0; k < l; k++) {
            VisualizerUtils.ChangeColor(gv.Rects[k].GetChild(0), Color.white);
        }
        gv.IsRunning = false;
    }

    private static void Swap(Transform[] rects, int i, int j) {
        (rects[j].localScale, rects[i].localScale) = (
            new Vector2(rects[i].localScale.x, rects[i].localScale.y),
            new Vector2(rects[j].localScale.x, rects[j].localScale.y)
        );
    }

}
