using System.Collections;
using UnityEngine;

public class BubbleSort
{

    public static IEnumerator Sort(GameVariables gv) {
        int l = gv.Rects.Length;
        for (int k =  0; k < l; k++) {
            VisualizerUtils.ChangeColor(gv.Rects[k].GetChild(0), Color.gray);
        }
        for (int i = 0; i < l - 1; i++) {
            bool didSwap = false;
            for (int j = 0; j < l - 1 - i; j++) {
                VisualizerUtils.ChangeColor(gv.Rects[j].GetChild(0), Color.red);
                VisualizerUtils.ChangeColor(gv.Rects[j + 1].GetChild(0), Color.red);
                yield return new WaitForSeconds(.2F / gv.AnimationSpeed);
                if (gv.Rects[j + 1].localScale.y < gv.Rects[j].localScale.y) {
                    (gv.Rects[j].localScale, gv.Rects[j + 1].localScale) = (
                        new Vector2(gv.Rects[j + 1].localScale.x, gv.Rects[j + 1].localScale.y),
                        new Vector2(gv.Rects[j].localScale.x, gv.Rects[j].localScale.y)
                    );
                    didSwap = true;
                }
                VisualizerUtils.ChangeColor(gv.Rects[j].GetChild(0), Color.gray);
                VisualizerUtils.ChangeColor(gv.Rects[j + 1].GetChild(0), Color.gray);
            }
            VisualizerUtils.ChangeColor(gv.Rects[l - 1 - i].GetChild(0), Color.white);
            if (!didSwap) {
                for (int k = 0; k < i + 1; k++) {
                    VisualizerUtils.ChangeColor(gv.Rects[l - 1 - i].GetChild(0), Color.white);
                }
                gv.IsRunning = false;
                yield return null;
            }
        }
        gv.IsRunning = false;
    }

}
