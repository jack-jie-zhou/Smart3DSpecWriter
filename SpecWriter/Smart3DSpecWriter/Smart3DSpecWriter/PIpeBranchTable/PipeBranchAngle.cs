using System;
using System.Collections.Generic;

namespace Smart3DSpecWriter.PipeBranchTable
{
    public class PipeBranchAngle  
    {
        private string _angleHigh;
        private string _angleLow;
        public PipeBranchAngle()
        {

        }

        public PipeBranchAngle(string angleHigh, string angleLow)
        {
            if (string.IsNullOrWhiteSpace(angleHigh))
            {
                throw new ArgumentException("message", nameof(angleHigh));
            }

            if (string.IsNullOrWhiteSpace(angleLow))
            {
                throw new ArgumentException("message", nameof(angleLow));
            }

            _angleHigh = angleHigh;
            _angleLow = angleLow;
        }

        public string AngleHigh => _angleHigh;
        public string AngleLow => _angleLow;

        public override bool Equals(object obj)
        {
            var angle = obj as PipeBranchAngle;
            return angle != null &&
                   AngleHigh == angle.AngleHigh &&
                   AngleLow == angle.AngleLow;
        }


        public override int GetHashCode()
        {
            var hashCode = 626923886;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AngleHigh);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AngleLow);
            return hashCode;
        }



        public static bool operator ==(PipeBranchAngle angle1, PipeBranchAngle angle2)
        {
            //Default check if T implments the System.IEquatable<T> interface
            // [1],if YES, EqualityComparer<T> uses that implmentation
            // [2], if NO, it uses Object.Equals and Object.GetHashCode provided by T
            return EqualityComparer<PipeBranchAngle>.Default.Equals(angle1, angle2);
        }

        public static bool operator !=(PipeBranchAngle angle1, PipeBranchAngle angle2)
        {
            return !(angle1 == angle2);
        }

        // string paString = angles[0];
        public static implicit operator string(PipeBranchAngle angle)
        {
            return angle.AngleHigh + "_" + angle.AngleLow;
        }

        //PipeBranchAngle pa1 = (PipeBranchAngle)paString;
        public static explicit operator PipeBranchAngle(string angleString)
        {
            string[] s = angleString.Split('_');
            if (s.Length != 2) throw new ArgumentException("Not a valid PipeBranchAngle string");
            PipeBranchAngle pa = new PipeBranchAngle(s[0],s[1]);
            return pa;
        }
    }
}
