using System.Numerics;
using UnityEngine;

public class Ch5_MyVector3
{
    public float x;
    public float y;
    public float z;

    public Ch5_MyVector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    // Vector addition
    public static Ch5_MyVector3 Add(Ch5_MyVector3 a, Ch5_MyVector3 b)
    {
        return new Ch5_MyVector3(
            a.x + b.x,
            a.y + b.y,
            a.z + b.z
        );
    }

    // Scalar multiplication
    public static Ch5_MyVector3 Multiply(Ch5_MyVector3 v, float s)
    {
        return new Ch5_MyVector3(
            v.x * s,
            v.y * s,
            v.z * s
        );
    }
}
