using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVector2
{
    public float x;
    public float y;

    public MyVector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public static float operator *(MyVector2 a, MyVector2 b)
    {
        return a.x * b.x + a.y * b.y;
    }

    public static Vector2 operator /(MyVector2 a, Vector3 b)
    {
       Vector2 resultado  = new Vector2(a.x + b.x, a.y + b.y);
       return resultado;
    }

    public static Vector3 operator +(MyVector2 a, Vector3 b)
    {
        Vector3 vector3 = new Vector3(a.x + b.x, a.y + b .y, b.z);
        return vector3;
    }

    public static float Modulo(MyVector2 a)
    {
        float modulo = Mathf.Sqrt(a.x * a.x + a.y * a.y);
        return modulo;
    }

    public static Vector2 VectorUnitario(MyVector2 a)
    {
        float modulo = Modulo(a);
        Vector2 vectoruni = new Vector2(a.x / modulo, a.y / modulo);
        return vectoruni;

    }
}
