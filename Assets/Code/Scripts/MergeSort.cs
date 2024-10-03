using System;
using System.Collections;
using UnityEngine;

public class MergeSort : MonoBehaviour
{
    // Start is called before the first frame update
    public static IEnumerator Sort(GameVariables gv) {
        int l = gv.Rects.Length;
        for (int k = 0; k < l; k++) {
            VisualizerUtils.ChangeColor(gv.Rects[k].GetChild(0), Color.gray);
        }
        for (int size = 1; size < l; size *= 2) {
            for (int start = 0; start < l - 1; start += size * 2) {
                int mid = Math.Min(l - 1, start + size - 1);
                int end = Math.Min(l - 1, start + 2 * size - 1);

                VisualizerUtils.ChangeColor(gv.Rects[start].GetChild(0), Color.green);
                VisualizerUtils.ChangeColor(gv.Rects[mid].GetChild(0), Color.green);
                VisualizerUtils.ChangeColor(gv.Rects[end].GetChild(0), Color.green);

                Vector2[] temp = new Vector2[mid + 1 - start];
                for (int k = start; k < mid + 1; k++) {
                    temp[k - start] = new Vector2(gv.Rects[k].localScale.x, gv.Rects[k].localScale.y);
                }
                int i = 0;
                int j = mid + 1;
                int p = start;
                while (i < temp.Length && j <= end) {
                    VisualizerUtils.ChangeColor(gv.Rects[j].GetChild(0), Color.red);
                    VisualizerUtils.ChangeColor(gv.Rects[p].GetChild(0), Color.red);
                    yield return new WaitForSeconds(.2F / gv.AnimationSpeed);
                    if (temp[i].y < gv.Rects[j].localScale.y) {
                        gv.Rects[p].localScale = new Vector2(temp[i].x, temp[i].y);
                        VisualizerUtils.ChangeColor(gv.Rects[p].GetChild(0), Color.gray);
                        i++;
                    } else {
                        gv.Rects[p].localScale = new Vector2(gv.Rects[j].localScale.x, gv.Rects[j].localScale.y);
                        VisualizerUtils.ChangeColor(gv.Rects[j].GetChild(0), Color.gray);
                        VisualizerUtils.ChangeColor(gv.Rects[p].GetChild(0), Color.gray);
                        j++;
                    }
                    p++;
                }
                while (i < temp.Length) {
                    VisualizerUtils.ChangeColor(gv.Rects[p].GetChild(0), Color.red);
                    yield return new WaitForSeconds(.2F / gv.AnimationSpeed);
                    gv.Rects[p].localScale = new Vector2(temp[i].x, temp[i].y);
                    VisualizerUtils.ChangeColor(gv.Rects[p].GetChild(0), Color.gray);
                    i++;
                    p++;
                }
                while (j < end + 1) {
                    VisualizerUtils.ChangeColor(gv.Rects[j].GetChild(0), Color.red);
                    VisualizerUtils.ChangeColor(gv.Rects[p].GetChild(0), Color.red);
                    yield return new WaitForSeconds(.2F / gv.AnimationSpeed);
                    gv.Rects[p].localScale = new Vector2(gv.Rects[j].localScale.x, gv.Rects[j].localScale.y);
                    VisualizerUtils.ChangeColor(gv.Rects[j].GetChild(0), Color.gray);
                    VisualizerUtils.ChangeColor(gv.Rects[p].GetChild(0), Color.gray);
                    j++;
                    p++;
                }
                VisualizerUtils.ChangeColor(gv.Rects[start].GetChild(0), Color.gray);
                VisualizerUtils.ChangeColor(gv.Rects[mid].GetChild(0), Color.gray);
                VisualizerUtils.ChangeColor(gv.Rects[end].GetChild(0), Color.gray);
            }
        }
        for (int k =  0; k < l; k++) {
            VisualizerUtils.ChangeColor(gv.Rects[k].GetChild(0), Color.white);
        }
        gv.IsRunning = false;
    }

}
