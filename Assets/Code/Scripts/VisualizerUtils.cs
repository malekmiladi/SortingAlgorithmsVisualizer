using UnityEngine;

public class VisualizerUtils : MonoBehaviour
{
    public static void ChangeColor(Transform rect, Color color) {
        rect.GetComponent<SpriteRenderer>().material.color = color;
    }
}

public class GameVariables {
    
    public GameVariables(
        float animationSpeed
    ) {
        Rects = new Transform[125];
        AnimationSpeed = animationSpeed;
        IsRunning = false;
        BarWidth = 14.95F / 125;
        BarHeight = 10F / 500;
    }

    public Transform[] Rects { get; set; }
    public float AnimationSpeed { get; set; }
    public bool IsRunning { get; set; }
    public float BarWidth { get; set; }
    public float BarHeight { get; set; }
}