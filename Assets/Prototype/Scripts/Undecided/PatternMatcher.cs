using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class PatternUtils
{
    static Color[] PatternColors = new Color[] {Color.blue, Color.red, Color.green, new Color(1, 0, 1, 1)};

    public static Color GetLeftOf(Color color)
    {
        if (color == Color.blue)
        {
            return new Color(1, 0, 1, 1);
        }
        else if (color == Color.red)
        {
            return Color.blue;
        }
        else if (color == Color.green)
        {
            return Color.red;
        }
        else if (color == new Color(1, 0, 1, 1))
        {
            return Color.green;
        }

        // this hsouldn't happen
        return Color.clear;
    }

    public static Color GetRightOf(Color color)
    {
        if (color == Color.blue)
        {
            return Color.red;
        }
        else if (color == Color.red)
        {
            return Color.green;
        }
        else if (color == Color.green)
        {
            return new Color(1, 0, 1, 1);
        }
        else if (color == new Color(1, 0, 1, 1))
        {
            return Color.blue;
        }   

        // this hsouldn't happen
        return Color.clear;
    }
}

public class PatternRule
{
    private Color _target;
    
    private List<Color> _desiredPattern = new List<Color>();

    public PatternRule(Color target, IEnumerable<Color> pattern)
    {
        _target = target;
        _desiredPattern.AddRange(pattern);
    }

    public bool SatisfiesPattern(Color target, IEnumerable<Color> pattern)
    {
        if (_target != target)
        {
            return false;
        }

        for (int i = 0; i < Mathf.Min(pattern.Count(), _desiredPattern.Count); i += 1)
        {
            if (_desiredPattern[i] != pattern.ElementAt(i))
            {
                return false;
            }
        }

        return true;
    }
}

public class InteractionRule
{
<<<<<<< HEAD
    public Color _focus;

    public Color _leftOf;

    public Color _rightOf;
=======
    public Color Focus { get; private set; }

    public Color LeftOf { get; private set; }

    public Color RightOf { get; private set; }
>>>>>>> bfdc3250c151411528adb4ee6378d34e07c5654c

    public InteractionRule(Color focus, Color leftOf, Color rightOf)
    {
        Focus = focus;
        LeftOf = leftOf;
        RightOf = rightOf;
    }

    public void RotateLeft()
    {
        Focus = PatternUtils.GetLeftOf(Focus);
        LeftOf = PatternUtils.GetLeftOf(LeftOf);
        RightOf = PatternUtils.GetLeftOf(RightOf);
    }

    public void RotateRight()
    {
        Focus = PatternUtils.GetRightOf(Focus);
        LeftOf = PatternUtils.GetRightOf(LeftOf);
        RightOf = PatternUtils.GetRightOf(RightOf);
    }
}

public class PatternMatcher : MonoBehaviour
{
}