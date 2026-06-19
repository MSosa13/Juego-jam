using UnityEngine;

public class ColliderLogic : MonoBehaviour
{
    public enum ColliderColor { Red, Green, Blue, Yellow, None };
    public ColliderColor myColor;

    private void Awake()
    {
        string n = gameObject.name;

        myColor = n switch
        {
            var s when s.Contains("Red") => ColliderColor.Red,
            var s when s.Contains("Blue") => ColliderColor.Blue,
            var s when s.Contains("Green") => ColliderColor.Green,
            var s when s.Contains("Yellow") => ColliderColor.Yellow,
            _ => ColliderColor.None
        };

    }
}
