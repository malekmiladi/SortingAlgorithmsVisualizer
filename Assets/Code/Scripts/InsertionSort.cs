using System.Collections;
using UnityEngine;

public class InsertionSort : ISortingStrategy
{
    public IEnumerator Sort(GameVariables gv)
    {
        var l = gv.Rects.Length;
        for (var i = 0; i < l; i++)
        {
            for (var j = i; j > 0 && gv.Rects[j].localScale.y < gv.Rects[j - 1].localScale.y; j--)
            {
                VisualizerUtils.ChangeColor(gv.Rects[j].GetChild(0), Color.red);
                VisualizerUtils.ChangeColor(gv.Rects[j - 1].GetChild(0), Color.red);
                yield return new WaitForSeconds(.2F / gv.AnimationSpeed);

                (gv.Rects[j].localScale, gv.Rects[j - 1].localScale) = (
                    new Vector2(gv.Rects[j - 1].localScale.x, gv.Rects[j - 1].localScale.y),
                    new Vector2(gv.Rects[j].localScale.x, gv.Rects[j].localScale.y)
                );

                VisualizerUtils.ChangeColor(gv.Rects[j].GetChild(0), Color.white);
                VisualizerUtils.ChangeColor(gv.Rects[j - 1].GetChild(0), Color.white);
            }
        }

        gv.IsRunning = false;
    }
}