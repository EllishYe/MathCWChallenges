using UnityEngine;

/*
 * HelloWorldDrawer_Centered
 * ------------------------
 * Draws a "HELLO WORLD" logo using only line-drawing tools (LineRenderer).
 *
 * The text is automatically centred by calculating the total width
 * of all letters and shifting the starting X position accordingly.
 *
 * This script demonstrates:
 * - Unity's LEFT-HANDED coordinate system
 * - Manual line-based drawing in world space
 * - Basic text layout logic (bounding & centring)
 *
 * Coordinate system:
 * - X axis: positive to the right
 * - Y axis: positive upwards
 * - Z axis: positive forward
 *
 * All geometry is drawn on the X¨CY plane with Z = 0.
 */

public class Ch1_HellowWorldDrawer : MonoBehaviour
{
    // Vertical size of letters (half height = 1 unit)
    private const float letterHeight = 1f;

    // Horizontal spacing between letters
    private const float letterSpacing = 0.3f;

    // Approximate visual widths for each letter
    // Order: H E L L O   W O R L D
    private float[] letterWidths =
    {
        1.2f, // H
        1.2f, // E
        1.0f, // L
        1.0f, // L
        1.2f, // O
        2.2f, // W
        1.2f, // O
        1.3f, // R
        1.0f, // L
        1.3f  // D
    };

    /*
     * We calculate the total width of the text and
     * then draw each letter from left to right.
     */
    void Start()
    {
        // Calculate total width of the entire string
        float totalWidth = 0f;

        foreach (float w in letterWidths)
        {
            totalWidth += w + letterSpacing;
        }

        // Remove the extra spacing added after the last letter
        totalWidth -= letterSpacing;

        // Start drawing so that the centre of the text aligns with X = 0
        float currentX = -totalWidth / 2f;

        // ---- Draw "HELLO" ----
        DrawH(new Vector3(currentX, 0f, 0f));
        currentX += letterWidths[0] + letterSpacing;

        DrawE(new Vector3(currentX, 0f, 0f));
        currentX += letterWidths[1] + letterSpacing;

        DrawL(new Vector3(currentX, 0f, 0f));
        currentX += letterWidths[2] + letterSpacing;

        DrawL(new Vector3(currentX, 0f, 0f));
        currentX += letterWidths[3] + letterSpacing;

        DrawO(new Vector3(currentX, 0f, 0f));
        currentX += letterWidths[4] + letterSpacing;

        // Extra spacing between words
        currentX += letterSpacing * 2f;

        // ---- Draw "WORLD" ----
        DrawW(new Vector3(currentX, 0f, 0f));
        currentX += letterWidths[5] + letterSpacing;

        DrawO(new Vector3(currentX, 0f, 0f));
        currentX += letterWidths[6] + letterSpacing;

        DrawR(new Vector3(currentX, 0f, 0f));
        currentX += letterWidths[7] + letterSpacing;

        DrawL(new Vector3(currentX, 0f, 0f));
        currentX += letterWidths[8] + letterSpacing;

        DrawD(new Vector3(currentX, 0f, 0f));
    }

    // =========================================================
    //  Generic Line Drawing Function
    // =========================================================

    /*
     * DrawLine()
     * ----------
     * Draws a single straight line in world space using LineRenderer.
     *
     * Parameters:
     * start - starting point of the line (world coordinates)
     * end   - ending point of the line (world coordinates)
     */
    void DrawLine(Vector3 start, Vector3 end)
    {
        GameObject lineObj = new GameObject("Line");
        lineObj.transform.parent = this.transform;

        LineRenderer lr = lineObj.AddComponent<LineRenderer>();

        lr.positionCount = 2;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);

        lr.startWidth = 0.08f;
        lr.endWidth = 0.08f;

        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.useWorldSpace = true;
    }

    // =========================================================
    //  Letter Definitions (drawn relative to local origin)
    // =========================================================

    /*
     * Each DrawX() method draws a letter using
     * line segments relative to an origin point.
     */

    void DrawH(Vector3 o)
    {
        DrawLine(o + new Vector3(0, letterHeight, 0), o + new Vector3(0, -letterHeight, 0));
        DrawLine(o + new Vector3(1, letterHeight, 0), o + new Vector3(1, -letterHeight, 0));
        DrawLine(o + new Vector3(0, 0, 0), o + new Vector3(1, 0, 0));
    }

    void DrawE(Vector3 o)
    {
        DrawLine(o + new Vector3(1, letterHeight, 0), o + new Vector3(0, letterHeight, 0));
        DrawLine(o + new Vector3(0, letterHeight, 0), o + new Vector3(0, -letterHeight, 0));
        DrawLine(o + new Vector3(0, 0, 0), o + new Vector3(0.8f, 0, 0));
        DrawLine(o + new Vector3(0, -letterHeight, 0), o + new Vector3(1, -letterHeight, 0));
    }

    void DrawL(Vector3 o)
    {
        DrawLine(o + new Vector3(0, letterHeight, 0), o + new Vector3(0, -letterHeight, 0));
        DrawLine(o + new Vector3(0, -letterHeight, 0), o + new Vector3(1, -letterHeight, 0));
    }

    void DrawO(Vector3 o)
    {
        DrawLine(o + new Vector3(0, letterHeight, 0), o + new Vector3(1, letterHeight, 0));
        DrawLine(o + new Vector3(1, letterHeight, 0), o + new Vector3(1, -letterHeight, 0));
        DrawLine(o + new Vector3(1, -letterHeight, 0), o + new Vector3(0, -letterHeight, 0));
        DrawLine(o + new Vector3(0, -letterHeight, 0), o + new Vector3(0, letterHeight, 0));
    }

    void DrawW(Vector3 o)
    {
        DrawLine(o + new Vector3(0, letterHeight, 0), o + new Vector3(0.5f, -letterHeight, 0));
        DrawLine(o + new Vector3(0.5f, -letterHeight, 0), o + new Vector3(1f, 0, 0));
        DrawLine(o + new Vector3(1f, 0, 0), o + new Vector3(1.5f, -letterHeight, 0));
        DrawLine(o + new Vector3(1.5f, -letterHeight, 0), o + new Vector3(2f, letterHeight, 0));
    }

    void DrawR(Vector3 o)
    {
        DrawLine(o + new Vector3(0, letterHeight, 0), o + new Vector3(0, -letterHeight, 0));
        DrawLine(o + new Vector3(0, letterHeight, 0), o + new Vector3(1, letterHeight, 0));
        DrawLine(o + new Vector3(1, letterHeight, 0), o + new Vector3(1, 0, 0));
        DrawLine(o + new Vector3(1, 0, 0), o + new Vector3(0, 0, 0));
        DrawLine(o + new Vector3(0, 0, 0), o + new Vector3(1, -letterHeight, 0));
    }

    void DrawD(Vector3 o)
    {
        DrawLine(o + new Vector3(0, letterHeight, 0), o + new Vector3(0, -letterHeight, 0));
        DrawLine(o + new Vector3(0, letterHeight, 0), o + new Vector3(1, 0.5f, 0));
        DrawLine(o + new Vector3(1, 0.5f, 0), o + new Vector3(1, -0.5f, 0));
        DrawLine(o + new Vector3(1, -0.5f, 0), o + new Vector3(0, -letterHeight, 0));
    }
}
