using System;
using System.Collections;
using UnityEngine;

public class MergeSort : ISortingStrategy
{
    // Start is called before the first frame update
    public IEnumerator Sort(GameVariables gv) {
        var l = gv.Rects.Length;
        for (var k = 0; k < l; k++) {
            VisualizerUtils.ChangeColor(gv.Rects[k].GetChild(0), Color.gray);
        }
        for (var size = 1; size < l; size *= 2) {
            for (var start = 0; start < l - 1; start += size * 2) {
                var mid = Math.Min(l - 1, start + size - 1);
                var end = Math.Min(l - 1, start + 2 * size - 1);

                VisualizerUtils.ChangeColor(gv.Rects[start].GetChild(0), Color.green);
                VisualizerUtils.ChangeColor(gv.Rects[mid].GetChild(0), Color.green);
                VisualizerUtils.ChangeColor(gv.Rects[end].GetChild(0), Color.green);

                var temp = new Vector2[mid + 1 - start];
                for (var k = start; k < mid + 1; k++) {
                    temp[k - start] = new Vector2(gv.Rects[k].localScale.x, gv.Rects[k].localScale.y);
                }
                var i = 0;
                var j = mid + 1;
                var p = start;
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
        for (var k =  0; k < l; k++) {
            VisualizerUtils.ChangeColor(gv.Rects[k].GetChild(0), Color.white);
        }
        gv.IsRunning = false;
    }

}
