﻿using UnityEngine;
using System.Collections;

public class EaseCurve
{
    public enum EaseType
    {
        easeInQuad,
        easeOutQuad,
        easeInOutQuad,
        easeInCubic,
        easeOutCubic,
        easeInOutCubic,
        easeInQuart,
        easeOutQuart,
        easeInOutQuart,
        easeInQuint,
        easeOutQuint,
        easeInOutQuint,
        easeInSine,
        easeOutSine,
        easeInOutSine,
        easeInExpo,
        easeOutExpo,
        easeInOutExpo,
        easeInCirc,
        easeOutCirc,
        easeInOutCirc,
        linear,
        spring,
        /* GFX47 MOD START */
        //bounce,
        easeInBounce,
        easeOutBounce,
        easeInOutBounce,
        /* GFX47 MOD END */
        easeInBack,
        easeOutBack,
        easeInOutBack,
        /* GFX47 MOD START */
        //elastic,
        easeInElastic,
        easeOutElastic,
        easeInOutElastic,
        /* GFX47 MOD END */
    }

    public static float EasingFunction(float start, float end, float value, EaseCurve.EaseType easeType)
    {
        switch (easeType)
        {
            case EaseType.easeInQuad:
                return EaseInQuad(start, end, value);
                
            case EaseType.easeOutQuad:
                return EaseOutQuad(start, end, value);
                
            case EaseType.easeInOutQuad:
                return EaseInOutQuad(start, end, value);
                
            case EaseType.easeInCubic:
                return EaseInCubic(start, end, value);
                
            case EaseType.easeOutCubic:
                return EaseOutCubic(start, end, value);
                
            case EaseType.easeInOutCubic:
                return EaseInOutCubic(start, end, value);
                
            case EaseType.easeInQuart:
                return EaseInQuart(start, end, value);
                
            case EaseType.easeOutQuart:
                return EaseOutQuart(start, end, value);
                
            case EaseType.easeInOutQuart:
                return EaseInOutQuart(start, end, value);
                
            case EaseType.easeInQuint:
                return EaseInQuint(start, end, value);
                
            case EaseType.easeOutQuint:
                return EaseOutQuint(start, end, value);
                
            case EaseType.easeInOutQuint:
                return EaseInOutQuint(start, end, value);
                
            case EaseType.easeInSine:
                return EaseInSine(start, end, value);
                
            case EaseType.easeOutSine:
                return EaseOutSine(start, end, value);
                
            case EaseType.easeInOutSine:
                return EaseInOutSine(start, end, value);
                
            case EaseType.easeInExpo:
                return EaseInExpo(start, end, value);
                
            case EaseType.easeOutExpo:
                return EaseOutExpo(start, end, value);
                
            case EaseType.easeInOutExpo:
                return EaseInOutExpo(start, end, value);
                
            case EaseType.easeInCirc:
                return EaseInCirc(start, end, value);
                
            case EaseType.easeOutCirc:
                return EaseOutCirc(start, end, value);
                
            case EaseType.easeInOutCirc:
                return EaseInOutCirc(start, end, value);
                
            case EaseType.linear:
                return Linear(start, end, value);
                
            case EaseType.spring:
                return Spring(start, end, value);
                
            /* GFX47 MOD START */
            /*case EaseType.bounce:
                return bounce);
                */
            case EaseType.easeInBounce:
                return EaseInBounce(start, end, value);
                
            case EaseType.easeOutBounce:
                return EaseOutBounce(start, end, value);
                
            case EaseType.easeInOutBounce:
                return EaseInOutBounce(start, end, value);
                
            /* GFX47 MOD END */
            case EaseType.easeInBack:
                return EaseInBack(start, end, value);
                
            case EaseType.easeOutBack:
                return EaseOutBack(start, end, value);
                
            case EaseType.easeInOutBack:
                return EaseInOutBack(start, end, value);
                
            /* GFX47 MOD START */
            /*case EaseType.elastic:
                return elastic);
                */
            case EaseType.easeInElastic:
                return EaseInElastic(start, end, value);
                
            case EaseType.easeOutElastic:
                return EaseOutElastic(start, end, value);
                
            case EaseType.easeInOutElastic:
                return EaseInOutElastic(start, end, value);
                
            /* GFX47 MOD END */
        }
        return 0.0f;
    }

    public static Vector3 EasingFunction(Vector3 start, Vector3 end, float value, EaseCurve.EaseType easeType)
    {
        Vector3 result;
        result.x = EasingFunction(start.x, end.x, value, easeType);
        result.y = EasingFunction(start.y, end.y, value, easeType);
        result.z = EasingFunction(start.z, end.z, value, easeType);
        return result;
    }

    public static float EasingAnimationCurve(AnimationCurve animationCurve, float start, float end, float value)
    {
        value = animationCurve.Evaluate(value);
        float distance = end - start;
        return start + distance * value;
    }

    public static Vector3 EasingAnimationCurve(AnimationCurve animationCurve, Vector3 start, Vector3 end, float value)
    {
        Vector3 result;
        result.x = EasingAnimationCurve(animationCurve, start.x, end.x, value);
        result.y = EasingAnimationCurve(animationCurve, start.y, end.y, value);
        result.z = EasingAnimationCurve(animationCurve, start.z, end.z, value);
        return result;
    }

    #region Easing Curves

    private static float Linear(float start, float end, float value)
    {
        return Mathf.Lerp(start, end, value);
    }

    private static float Clerp(float start, float end, float value)
    {
        float min = 0.0f;
        float max = 360.0f;
        float half = Mathf.Abs((max - min) * 0.5f);
        float retval = 0.0f;
        float diff = 0.0f;
        if ((end - start) < -half)
        {
            diff = ((max - start) + end) * value;
            retval = start + diff;
        }
        else if ((end - start) > half)
        {
            diff = -((max - end) + start) * value;
            retval = start + diff;
        }
        else retval = start + (end - start) * value;
        return retval;
    }

    private static float Spring(float start, float end, float value)
    {
        value = Mathf.Clamp01(value);
        value = (Mathf.Sin(value * Mathf.PI * (0.2f + 2.5f * value * value * value)) * Mathf.Pow(1f - value, 2.2f) + value) * (1f + (1.2f * (1f - value)));
        return start + (end - start) * value;
    }

    private static float EaseInQuad(float start, float end, float value)
    {
        end -= start;
        return end * value * value + start;
    }

    private static float EaseOutQuad(float start, float end, float value)
    {
        end -= start;
        return -end * value * (value - 2) + start;
    }

    private static float EaseInOutQuad(float start, float end, float value)
    {
        value /= .5f;
        end -= start;
        if (value < 1) return end * 0.5f * value * value + start;
        value--;
        return -end * 0.5f * (value * (value - 2) - 1) + start;
    }

    private static float EaseInCubic(float start, float end, float value)
    {
        end -= start;
        return end * value * value * value + start;
    }

    private static float EaseOutCubic(float start, float end, float value)
    {
        value--;
        end -= start;
        return end * (value * value * value + 1) + start;
    }

    private static float EaseInOutCubic(float start, float end, float value)
    {
        value /= .5f;
        end -= start;
        if (value < 1) return end * 0.5f * value * value * value + start;
        value -= 2;
        return end * 0.5f * (value * value * value + 2) + start;
    }

    private static float EaseInQuart(float start, float end, float value)
    {
        end -= start;
        return end * value * value * value * value + start;
    }

    private static float EaseOutQuart(float start, float end, float value)
    {
        value--;
        end -= start;
        return -end * (value * value * value * value - 1) + start;
    }

    private static float EaseInOutQuart(float start, float end, float value)
    {
        value /= .5f;
        end -= start;
        if (value < 1) return end * 0.5f * value * value * value * value + start;
        value -= 2;
        return -end * 0.5f * (value * value * value * value - 2) + start;
    }

    private static float EaseInQuint(float start, float end, float value)
    {
        end -= start;
        return end * value * value * value * value * value + start;
    }

    private static float EaseOutQuint(float start, float end, float value)
    {
        value--;
        end -= start;
        return end * (value * value * value * value * value + 1) + start;
    }

    private static float EaseInOutQuint(float start, float end, float value)
    {
        value /= .5f;
        end -= start;
        if (value < 1) return end * 0.5f * value * value * value * value * value + start;
        value -= 2;
        return end * 0.5f * (value * value * value * value * value + 2) + start;
    }

    private static float EaseInSine(float start, float end, float value)
    {
        end -= start;
        return -end * Mathf.Cos(value * (Mathf.PI * 0.5f)) + end + start;
    }

    private static float EaseOutSine(float start, float end, float value)
    {
        end -= start;
        return end * Mathf.Sin(value * (Mathf.PI * 0.5f)) + start;
    }

    private static float EaseInOutSine(float start, float end, float value)
    {
        end -= start;
        return -end * 0.5f * (Mathf.Cos(Mathf.PI * value) - 1) + start;
    }

    private static float EaseInExpo(float start, float end, float value)
    {
        end -= start;
        return end * Mathf.Pow(2, 10 * (value - 1)) + start;
    }

    private static float EaseOutExpo(float start, float end, float value)
    {
        end -= start;
        return end * (-Mathf.Pow(2, -10 * value) + 1) + start;
    }

    private static float EaseInOutExpo(float start, float end, float value)
    {
        value /= .5f;
        end -= start;
        if (value < 1) return end * 0.5f * Mathf.Pow(2, 10 * (value - 1)) + start;
        value--;
        return end * 0.5f * (-Mathf.Pow(2, -10 * value) + 2) + start;
    }

    private static float EaseInCirc(float start, float end, float value)
    {
        end -= start;
        return -end * (Mathf.Sqrt(1 - value * value) - 1) + start;
    }

    private static float EaseOutCirc(float start, float end, float value)
    {
        value--;
        end -= start;
        return end * Mathf.Sqrt(1 - value * value) + start;
    }

    private static float EaseInOutCirc(float start, float end, float value)
    {
        value /= .5f;
        end -= start;
        if (value < 1) return -end * 0.5f * (Mathf.Sqrt(1 - value * value) - 1) + start;
        value -= 2;
        return end * 0.5f * (Mathf.Sqrt(1 - value * value) + 1) + start;
    }

    /* GFX47 MOD START */
    private static float EaseInBounce(float start, float end, float value)
    {
        end -= start;
        float d = 1f;
        return end - EaseOutBounce(0, end, d - value) + start;
    }
    /* GFX47 MOD END */

    /* GFX47 MOD START */
    private static float EaseOutBounce(float start, float end, float value)
    {
        value /= 1f;
        end -= start;
        if (value < (1 / 2.75f))
        {
            return end * (7.5625f * value * value) + start;
        }
        else if (value < (2 / 2.75f))
        {
            value -= (1.5f / 2.75f);
            return end * (7.5625f * (value) * value + .75f) + start;
        }
        else if (value < (2.5 / 2.75))
        {
            value -= (2.25f / 2.75f);
            return end * (7.5625f * (value) * value + .9375f) + start;
        }
        else
        {
            value -= (2.625f / 2.75f);
            return end * (7.5625f * (value) * value + .984375f) + start;
        }
    }
    /* GFX47 MOD END */

    /* GFX47 MOD START */
    private static float EaseInOutBounce(float start, float end, float value)
    {
        end -= start;
        float d = 1f;
        if (value < d * 0.5f) return EaseInBounce(0, end, value * 2) * 0.5f + start;
        else return EaseOutBounce(0, end, value * 2 - d) * 0.5f + end * 0.5f + start;
    }
    /* GFX47 MOD END */

    private static float EaseInBack(float start, float end, float value)
    {
        end -= start;
        value /= 1;
        float s = 1.70158f;
        return end * (value) * value * ((s + 1) * value - s) + start;
    }

    private static float EaseOutBack(float start, float end, float value)
    {
        float s = 1.70158f;
        end -= start;
        value = (value) - 1;
        return end * ((value) * value * ((s + 1) * value + s) + 1) + start;
    }

    private static float EaseInOutBack(float start, float end, float value)
    {
        float s = 1.70158f;
        end -= start;
        value /= .5f;
        if ((value) < 1)
        {
            s *= (1.525f);
            return end * 0.5f * (value * value * (((s) + 1) * value - s)) + start;
        }
        value -= 2;
        s *= (1.525f);
        return end * 0.5f * ((value) * value * (((s) + 1) * value + s) + 2) + start;
    }

    /* GFX47 MOD START */
    private static float EaseInElastic(float start, float end, float value)
    {
        end -= start;

        float d = 1f;
        float p = d * .3f;
        float s = 0;
        float a = 0;

        if (value == 0) return start;

        if ((value /= d) == 1) return start + end;

        if (a == 0f || a < Mathf.Abs(end))
        {
            a = end;
            s = p / 4;
        }
        else
        {
            s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
        }

        return -(a * Mathf.Pow(2, 10 * (value -= 1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p)) + start;
    }
    /* GFX47 MOD END */

    /* GFX47 MOD START */
    //private static float elastic(float start, float end, float value){
    private static float EaseOutElastic(float start, float end, float value)
    {
        /* GFX47 MOD END */
        //Thank you to rafael.marteleto for fixing this as a port over from Pedro's UnityTween
        end -= start;

        float d = 1f;
        float p = d * .3f;
        float s = 0;
        float a = 0;

        if (value == 0) return start;

        if ((value /= d) == 1) return start + end;

        if (a == 0f || a < Mathf.Abs(end))
        {
            a = end;
            s = p * 0.25f;
        }
        else
        {
            s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
        }

        return (a * Mathf.Pow(2, -10 * value) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p) + end + start);
    }

    /* GFX47 MOD START */
    private static float EaseInOutElastic(float start, float end, float value)
    {
        end -= start;

        float d = 1f;
        float p = d * .3f;
        float s = 0;
        float a = 0;

        if (value == 0) return start;

        if ((value /= d * 0.5f) == 2) return start + end;

        if (a == 0f || a < Mathf.Abs(end))
        {
            a = end;
            s = p / 4;
        }
        else
        {
            s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
        }

        if (value < 1) return -0.5f * (a * Mathf.Pow(2, 10 * (value -= 1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p)) + start;
        return a * Mathf.Pow(2, -10 * (value -= 1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p) * 0.5f + end + start;
    }
    /* GFX47 MOD END */

    #endregion	
}
