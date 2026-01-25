using UnityEngine;

public struct Ch3_CustomVector2
{
    public float x;
    public float y;

    public Ch3_CustomVector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    // Vector addition
    public static Ch3_CustomVector2 Add(Ch3_CustomVector2 a, Ch3_CustomVector2 b)
    {
        return new Ch3_CustomVector2(a.x + b.x, a.y + b.y);
    }

    // Vector subtraction
    public static Ch3_CustomVector2 Subtract(Ch3_CustomVector2 a, Ch3_CustomVector2 b)
    {
        return new Ch3_CustomVector2(a.x - b.x, a.y - b.y);
    }

    // Multiply by scalar
    public static Ch3_CustomVector2 Multiply(Ch3_CustomVector2 v, float scalar)
    {
        return new Ch3_CustomVector2(v.x * scalar, v.y * scalar);
    }

    // Dot product
    public static float Dot(Ch3_CustomVector2 a, Ch3_CustomVector2 b)
    {
        return a.x * b.x + a.y * b.y;
    }

    // 2D cross product (returns scalar)
    public static float Cross(Ch3_CustomVector2 a, Ch3_CustomVector2 b)
    {
        return a.x * b.y - a.y * b.x;
    }

    // Magnitude (length)
    public float Magnitude()
    {
        return Sqrt(x * x + y * y);
    }

    // Normalisation
    public Ch3_CustomVector2 Normalized()
    {
        float mag = Magnitude();
        if (mag == 0f)
            return new Ch3_CustomVector2(0f, 0f);

        return new Ch3_CustomVector2(x / mag, y / mag);
    }

    // -------- Hard-coded math helpers --------
    /*
     * A safety check was added to prevent normalising a zero-length vector, 
     * avoiding NaN propagation during movement calculations.
     */

    float Sqrt(float value)
    {
        if (value <= 0f)
            return 0f;

        float result = value;
        for (int i = 0; i < 5; i++)
            result = 0.5f * (result + value / result);

        return result;
    }
}
