using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCalculator 
{
    public static Vector2 GetPositionNearViewPort()
    {
        float xPos = Random.Range(-0.2f, 1.2f);
        float yPos;

        if (xPos >= 0 && xPos <= 1)
        {
            float[] floats = new float[2];
            floats[0] = Random.Range(-0.2f, -0.1f);
            floats[1] = Random.Range(1.1f, 1.2f);

            yPos = GetRandomFloat(floats);
        }
        else
        {
            yPos = Random.Range(-0.2f, 1.2f);
        }

        return Camera.main.ViewportToWorldPoint(new Vector2(xPos, yPos));
    }
    private static float GetRandomFloat(float[] floats)
    {
        var randomIndex = Random.Range(0, floats.Length);

        return floats[randomIndex];
    }
}
