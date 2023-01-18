using UnityEngine;
using System;
 
public class Mathfx
{
    public static float Hermite(float start, float end, float value)
    {
        return Mathf.Lerp(start, end, value * value * (3.0f - 2.0f * value));
    }
    
    public static float Sinerp(float start, float end, float value)
    {
        return Mathf.Lerp(start, end, Mathf.Sin(value * Mathf.PI * 0.5f));
    }
 
    public static float Berp(float start, float end, float value)
    {
        value = Mathf.Clamp01(value);
        value = (Mathf.Sin(value * Mathf.PI * (0.2f + 2.5f * value * value * value)) * Mathf.Pow(1f - value, 2.2f) + value) * (1f + (1.2f * (1f - value)));
        return start + (end - start) * value;
    }
    
    public static float SmoothStep (float x, float min, float max) 
    {
        x = Mathf.Clamp (x, min, max);
        float v1 = (x-min)/(max-min);
        float v2 = (x-min)/(max-min);
        return -2*v1 * v1 *v1 + 3*v2 * v2;
    }
 
    public static float Lerp(float start, float end, float value)
    {
        return ((1.0f - value) * start) + (value * end);
    }
 
    public static Vector3 NearestPoint(Vector3 lineStart, Vector3 lineEnd, Vector3 point)
    {
        Vector3 lineDirection = Vector3.Normalize(lineEnd-lineStart);
        float closestPoint = Vector3.Dot((point-lineStart),lineDirection)/Vector3.Dot(lineDirection,lineDirection);
        return lineStart+(closestPoint*lineDirection);
    }
 
    public static Vector3 NearestPointStrict(Vector3 lineStart, Vector3 lineEnd, Vector3 point)
    {
        Vector3 fullDirection = lineEnd-lineStart;
        Vector3 lineDirection = Vector3.Normalize(fullDirection);
        float closestPoint = Vector3.Dot((point-lineStart),lineDirection)/Vector3.Dot(lineDirection,lineDirection);
        return lineStart+(Mathf.Clamp(closestPoint,0.0f,Vector3.Magnitude(fullDirection))*lineDirection);
    }
    public static float Bounce(float x) {
        return Mathf.Abs(Mathf.Sin(6.28f*(x+1f)*(x+1f)) * (1f-x));
    }
    
    // test for value that is near specified float (due to floating point inprecision)
    // all thanks to Opless for this!
    public static bool Approx(float val, float about, float range) {
        return ( ( Mathf.Abs(val - about) < range) );
    }
 
    // test if a Vector3 is close to another Vector3 (due to floating point inprecision)
    // compares the square of the distance to the square of the range as this 
    // avoids calculating a square root which is much slower than squaring the range
    public static bool Approx(Vector3 val, Vector3 about, float range) {
        return ( (val - about).sqrMagnitude < range*range);
    }
 
}