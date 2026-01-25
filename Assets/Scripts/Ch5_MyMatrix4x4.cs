using System.Numerics;
using UnityEngine;

public class Ch5_MyMatrix4x4
{
    public float[,] m = new float[4, 4];

    public Ch5_MyMatrix4x4()
    {
        for (int r = 0; r < 4; r++)
        {
            for (int c = 0; c < 4; c++)
            {
                m[r, c] = 0f;
            }
        }
    }
    public static Ch5_MyMatrix4x4 Identity()
    {
        Ch5_MyMatrix4x4 mat = new Ch5_MyMatrix4x4();

        mat.m[0, 0] = 1f;
        mat.m[1, 1] = 1f;
        mat.m[2, 2] = 1f;
        mat.m[3, 3] = 1f;

        return mat;
    }

    public static Ch5_MyMatrix4x4 Translation(float tx, float ty, float tz)
    {
        Ch5_MyMatrix4x4 mat = Identity();

        mat.m[0, 3] = tx;
        mat.m[1, 3] = ty;
        mat.m[2, 3] = tz;

        return mat;
    }

    public static Ch5_MyMatrix4x4 Scale(float s)
    {
        Ch5_MyMatrix4x4 mat = Identity();

        mat.m[0, 0] = s;
        mat.m[1, 1] = s;
        mat.m[2, 2] = s;

        return mat;
    }

    public static float Sin(float x)
    {
        float x3 = x * x * x;
        float x5 = x3 * x * x;
        return x - x3 / 6f + x5 / 120f;
    }

    public static float Cos(float x)
    {
        float x2 = x * x;
        float x4 = x2 * x2;
        return 1 - x2 / 2f + x4 / 24f;
    }

    public static Ch5_MyMatrix4x4 RotationX(float rad)
    {
        Ch5_MyMatrix4x4 mat = Identity();
        float c = Cos(rad);
        float s = Sin(rad);

        mat.m[1, 1] = c;
        mat.m[1, 2] = -s;
        mat.m[2, 1] = s;
        mat.m[2, 2] = c;

        return mat;
    }
    public static Ch5_MyMatrix4x4 RotationY(float rad)
    {
        Ch5_MyMatrix4x4 mat = Identity();
        float c = Cos(rad);
        float s = Sin(rad);

        mat.m[0, 0] = c;
        mat.m[0, 2] = s;
        mat.m[2, 0] = -s;
        mat.m[2, 2] = c;

        return mat;
    }
    public static Ch5_MyMatrix4x4 RotationZ(float rad)
    {
        Ch5_MyMatrix4x4 mat = Identity();
        float c = Cos(rad);
        float s = Sin(rad);

        mat.m[0, 0] = c;
        mat.m[0, 1] = -s;
        mat.m[1, 0] = s;
        mat.m[1, 1] = c;

        return mat;
    }

    public static Ch5_MyMatrix4x4 Multiply(Ch5_MyMatrix4x4 a, Ch5_MyMatrix4x4 b)
    {
        Ch5_MyMatrix4x4 result = new Ch5_MyMatrix4x4();

        for (int r = 0; r < 4; r++)
        {
            for (int c = 0; c < 4; c++)
            {
                float sum = 0f;
                for (int k = 0; k < 4; k++)
                {
                    sum += a.m[r, k] * b.m[k, c];
                }
                result.m[r, c] = sum;
            }
        }
        return result;
    }

    public static Ch5_MyVector3 Multiply(Ch5_MyMatrix4x4 mat, Ch5_MyVector3 v)
    {
        float x =
            mat.m[0, 0] * v.x +
            mat.m[0, 1] * v.y +
            mat.m[0, 2] * v.z +
            mat.m[0, 3];

        float y =
            mat.m[1, 0] * v.x +
            mat.m[1, 1] * v.y +
            mat.m[1, 2] * v.z +
            mat.m[1, 3];

        float z =
            mat.m[2, 0] * v.x +
            mat.m[2, 1] * v.y +
            mat.m[2, 2] * v.z +
            mat.m[2, 3];

        return new Ch5_MyVector3(x, y, z);
    }

}
