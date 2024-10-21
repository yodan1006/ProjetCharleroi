public class MyMathToolBox
{
    public static float Clamp(float value, float minValue, float maxValue)
    {
        if (value > 1)
            value = 1;
        if (value < -1)
            value = -1;
        return value;
    }
}