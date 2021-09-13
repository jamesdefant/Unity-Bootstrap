using UnityEngine;
public static class RectTransformExtensions
{
    public static void SetLeft(this RectTransform rt, float left)
    {
        rt.offsetMin = new Vector2(left, rt.offsetMin.y);
    }

    public static void SetRight(this RectTransform rt, float right)
    {
        rt.offsetMax = new Vector2(-right, rt.offsetMax.y);
    }

    public static void SetTop(this RectTransform rt, float top)
    {
        rt.offsetMax = new Vector2(rt.offsetMax.x, -top);
    }

    public static void SetBottom(this RectTransform rt, float bottom)
    {
        rt.offsetMin = new Vector2(rt.offsetMin.x, bottom);
    }

    /// <summary>
    /// Set the RectTransform's size
    /// </summary>
    /// <param name="rt">Rt.</param>
    /// <param name="top">Top.</param>
    /// <param name="right">Right.</param>
    /// <param name="bottom">Bottom.</param>
    /// <param name="left">Left.</param>
    public static void SetAnchoredSize(this RectTransform rt, float top, float right, float bottom, float left)
    {
        rt.offsetMin = new Vector2(left, bottom);
        rt.offsetMax = new Vector2(-right, -top);
    }
    /// <summary>
    /// Reset the RectTransform's size to 0
    /// </summary>
    /// <param name="rt">Rt.</param>
    public static void SetAnchoredSize(this RectTransform rt)
    {
        rt.offsetMin = new Vector2(0f, 0f);
        rt.offsetMax = new Vector2(0f, 0f);
    }
}