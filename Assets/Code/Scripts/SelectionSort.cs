using System.Collections;
using UnityEngine;

public class SelectionSort : ISortingStrategy
{
    public IEnumerator Sort(GameVariables gv) {
        var l = gv.Rects.Length;
        var p = 0;
        var smallest = 0;
        for (var k =  0; k < l; k++) {
            VisualizerUtils.ChangeColor(gv.Rects[k].GetChild(0), Color.gray);
        }
        while (p < l) {
            for (var i = p; i < l; i++) {
                VisualizerUtils.ChangeColor(gv.Rects[i].GetChild(0), Color.red);
                VisualizerUtils.ChangeColor(gv.Rects[smallest].GetChild(0), Color.red);
                yield return new WaitForSeconds(.2F / gv.AnimationSpeed);
                if (gv.Rects[i].localScale.y < gv.Rects[smallest].localScale.y) {
                    VisualizerUtils.ChangeColor(gv.Rects[smallest].GetChild(0), Color.gray);
                    smallest = i;
                }
                VisualizerUtils.ChangeColor(gv.Rects[i].GetChild(0), Color.gray);
                VisualizerUtils.ChangeColor(gv.Rects[smallest].GetChild(0), Color.gray);
            }
            (gv.Rects[p].localScale, gv.Rects[smallest].localScale) = (
                new Vector2(gv.Rects[smallest].localScale.x, gv.Rects[smallest].localScale.y),
                new Vector2(gv.Rects[p].localScale.x, gv.Rects[p].localScale.y)
            );
            VisualizerUtils.ChangeColor(gv.Rects[p].GetChild(0), Color.white);
            p++;
            smallest = p;
        }
        gv.IsRunning = false;
    }
}
