using UnityEngine;
using System.Collections;
using System;

namespace Vector3DNamespace
{
    [Serializable]
    public struct Vector3D {

        public float x;
        public float y;
        public float z;


        public Vector3D(float xi, float yi, float zi)
        {
            this.x = xi;
            this.y = yi;
            this.z = zi;
        }

        public void Set(float xi, float yi, float zi)
        {
            this.x = xi;
            this.y = yi;
            this.z = zi;
        }

        public static implicit operator Vector3(Vector3D v)
        {
            return new Vector3(v.x, v.y, v.z);
        }

        //public float Magnitude
        //{
        //    get
        //    {
        //        this.magnitude = Mathf.Sqrt(x * x + y * y + z * z);
        //        return this.magnitude;
        //    }
        //}

        //public void Normalize()
        //{
        //    this.x /= Magnitude;
        //    this.y /= Magnitude;
        //    this.z /= Magnitude;

        //    return;
        //}

        public void Reverse()
        {
            this.x *= -1;
            this.y *= -1;
            this.z *= -1;

            return;
        }

        public void Scale(Vector3D vs)
        {
            this.x *= vs.x;
            this.y *= vs.y;
            this.z *= vs.z;

            return;
        }

        public void Scale(float s)
        {
            this.x *= s;
            this.y *= s;
            this.z *= s;

            return;
        }

        public static Vector3D operator+(Vector3D v1, Vector3D v2)

        {

            return new Vector3D(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector3D operator-(Vector3D v1, Vector3D v2)

        {

            return new Vector3D(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector3D operator*(Vector3D v1, float s)

        {

            return new Vector3D(v1.x * s, v1.y * s, v1.z * s);
        }

        public static Vector3D operator/(Vector3D a, float d)

        {

            return new Vector3D(a.x / d, a.y / d, a.z / d);
        }

        public static Vector3D Scale(Vector3D v1, Vector3D v2)
        {

            return new Vector3D(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        }

        public static Vector3D Lerp(Vector3D v1, Vector3D v2, float t)

        {

            t = Mathf.Clamp01(t);

            return new Vector3D(v1.x + (v2.x - v1.x) * t, v1.y + (v2.y - v1.y) * t, v1.z + (v2.z - v1.z) * t);
        }

        public static Vector3D up
        {
            get
            {
                return new Vector3D(0f, 1f, 0f);
            }
        }

        public static Vector3D down
        {
            get
            {
                return new Vector3D(0f, -1f, 0f);
            }
        }

    }

}
