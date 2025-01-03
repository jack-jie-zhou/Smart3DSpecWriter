using System;
using System.Collections.Generic;

namespace Smart3DSpecWriter.PipeBranchTable
{
    /// <summary>
    /// Branch Angle
    /// </summary>
    public class PipeBranchAngle  
    {
        private string _angleHigh;
        private string _angleLow;
        /// <summary>
        /// ctor
        /// </summary>
        public PipeBranchAngle()
        {

        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="angleHigh">-</param>
        /// <param name="angleLow">-</param>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// Angle Height
        /// </summary>
        public string AngleHigh => _angleHigh;
        /// <summary>
        /// AngleLow
        /// </summary>
        public string AngleLow => _angleLow;

        /// <summary>
        /// Equals operator
        /// </summary>
        /// <param name="obj">-</param>
        /// <returns>-</returns>
        public override bool Equals(object obj)
        {
            var angle = obj as PipeBranchAngle;
            return angle != null &&
                   AngleHigh == angle.AngleHigh &&
                   AngleLow == angle.AngleLow;
        }

        /// <summary>
        /// -
        /// </summary>
        /// <returns>-</returns>
        public override int GetHashCode()
        {
            var hashCode = 626923886;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AngleHigh);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AngleLow);
            return hashCode;
        }

        /// <summary>
        /// == operator
        /// </summary>
        /// <param name="angle1">-</param>
        /// <param name="angle2">-</param>
        /// <returns>-</returns>
        public static bool operator ==(PipeBranchAngle angle1, PipeBranchAngle angle2)
        {
            //Default check if T implments the System.IEquatable<T> interface
            // [1],if YES, EqualityComparer<T> uses that implmentation
            // [2], if NO, it uses Object.Equals and Object.GetHashCode provided by T
            return EqualityComparer<PipeBranchAngle>.Default.Equals(angle1, angle2);
        }

        /// <summary>
        /// != operator
        /// </summary>
        /// <param name="angle1">-</param>
        /// <param name="angle2">-</param>
        /// <returns>-</returns>
        public static bool operator !=(PipeBranchAngle angle1, PipeBranchAngle angle2)
        {
            return !(angle1 == angle2);
        }

        /// <summary>
        /// string paString = angles[0];
        /// </summary>
        /// <param name="angle"></param>
        public static implicit operator string(PipeBranchAngle angle)
        {
            return angle.AngleHigh + "_" + angle.AngleLow;
        }

        /// <summary>
        /// PipeBranchAngle pa1 = (PipeBranchAngle)paString;
        /// </summary>
        /// <param name="angleString">-</param>
        public static explicit operator PipeBranchAngle(string angleString)
        {
            string[] s = angleString.Split('_');
            if (s.Length != 2) throw new ArgumentException("Not a valid PipeBranchAngle string");
            PipeBranchAngle pa = new PipeBranchAngle(s[0],s[1]);
            return pa;
        }
    }
}
