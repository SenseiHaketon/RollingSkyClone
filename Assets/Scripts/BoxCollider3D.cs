using UnityEngine;
using System.Collections;
using System;
using Vector3DNamespace;

namespace BoxCollider3Dn
{
    [Serializable]
    public struct BoxCollider3D
    {

        private Vector3D center;
        private Vector3D outer;

        

        public Vector3D Center
        {
            get
            {
                return this.center;
            }

            set
            {
                this.center = value;
            }
        }

        public Vector3D Outer
        {
            get
            {
                return this.outer;
            }

            set
            {
                this.outer = value;
            }
        }

        public Vector3D Size
        {
            get
            {
                return this.outer * 2f;
            }

            set
            {
                this.outer = value * 0.5f;
            }
        }

        public Vector3D Min
        {
            get
            {
                return this.center - this.outer;
            }
        }

        public Vector3D Max
        {
            get
            {
                return this.center + this.outer;
            }
        }

        public BoxCollider3D(Vector3D vCenter, Vector3D vOuter) : this()
        {
            this.center = vCenter;
            this.outer = vOuter;
        }

        public void GetPoints()
        {
            Vector3D[] points = new Vector3D[8];
            points[0] = center + new Vector3D(outer.x, outer.y, outer.z);
        }
       
    }
}
