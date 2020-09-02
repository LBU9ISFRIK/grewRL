using UnityEngine;

namespace MLAgents
{
    [System.Serializable]
    public class MarathonJoint
    {
        public Joint Joint;
        //public BulletUnity.BTypedConstraint Joint;
        public string Name;
        public string JointName;
        public Vector2 CtrlRange;
        public bool? CtrlLimited;
        public float? Gear;
        public ConfigurableJoint TrueBase;
        //public BulletUnity.B6DOFConstraint TrueBase;
        public Transform TrueTarget;
        public float MaximumForce;
    }
}
