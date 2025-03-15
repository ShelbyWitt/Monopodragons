//ColorManager.cs
using UnityEngine;
using System.Collections.Generic;

public static class ColorManager
{
    public static Dictionary<string, Color> ColorOptions = new Dictionary<string, Color>()
    {
        {"Red", Color.red},
        {"Blue", Color.blue},
        {"Green", Color.green},
        {"Yellow", Color.yellow},
        {"Purple", new Color(0.5f, 0, 0.5f)},
        {"Orange", new Color(1f, 0.5f, 0)},
        {"White", Color.white},
        {"Black", Color.black}
    };
}