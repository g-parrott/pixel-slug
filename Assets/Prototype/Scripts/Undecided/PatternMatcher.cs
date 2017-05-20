using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    Color _focus;

    Color _leftOf;

    Color _rightOf;

    public InteractionRule(Color focus, Color leftOf, Color rightOf)
    {
        _focus = focus;
        _leftOf = leftOf;
        _rightOf = rightOf;
    }

    public void RotateLeft()
    {
        _focus = PatternUtils.GetLeftOf(_focus);
        _leftOf = PatternUtils.GetLeftOf(_leftOf);
        _rightOf = PatternUtils.GetLeftOf(_rightOf);
    }

    public void RotateRight()
    {
        _focus = PatternUtils.GetRightOf(_focus);
        _leftOf = PatternUtils.GetRightOf(_leftOf);
        _rightOf = PatternUtils.GetRightOf(_rightOf);
    }
}

public class PatternMatcher : MonoBehaviour
{
}