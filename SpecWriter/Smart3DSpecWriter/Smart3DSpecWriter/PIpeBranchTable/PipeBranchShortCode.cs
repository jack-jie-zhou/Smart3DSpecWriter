using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart3DSpecWriter.PipeBranchTable
{
    /// <summary>
    ///  A class to operate ShortCode, SecondaryshortCode and TertiaryShortCode
    /// </summary>
    public class PipeBranchShortCode
    {
        private string sc;
        private string sc2;
        private string sc3;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="sc"></param>
        /// <param name="sc2"></param>
        /// <param name="sc3"></param>
        public PipeBranchShortCode(string sc, string sc2, string sc3)
        {
            this.sc = sc??"";
            this.sc2 = sc2??"";
            this.sc3 = sc3??"";
        }

        /// <summary>
        /// ShortCode 1
        /// </summary>
        public string ShortCode1  => sc;
        /// <summary>
        /// ShortCode 2
        /// </summary>
        public string ShortCode2 => sc2;
        /// <summary>
        /// ShortCode 3
        /// </summary>
        public string ShortCode3 => sc3;

        /// <summary>
        /// Convert PipeBranchShortCode instance to a string
        /// </summary>
        /// <param name="sc">-</param>
        public static implicit operator string(PipeBranchShortCode sc)
        {
            return $"{sc.ShortCode1}\n{sc.ShortCode2}\n{sc.ShortCode3}";
        }

        /// <summary>
        /// decode string as PipeBranchShortCode instance
        /// </summary>
        /// <param name="codeString"></param>
        public static explicit operator PipeBranchShortCode(string codeString)
        {
            (string sc, string sc2, string sc3) codes = GetCodes(codeString);
            PipeBranchShortCode sc = new PipeBranchShortCode(codes.sc,codes.sc2,codes.sc3);
            return sc;
        }

        /// <summary>
        /// decode string as sc, sc2, sc3 - these are private fields of class PipeBranchShortCode
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static (string, string, string) GetCodes(string code)
        {
            string sc = "", sc2 = "", sc3 = "";
            string[] codes = code.Split('\n');
            if (codes.Length == 1)
            {
                sc = codes[0];
            }
            else if (codes.Length == 2)
            {
                sc = codes[0];
                sc2 = codes[1];
            }
            else if (codes.Length == 3)
            {
                sc = codes[0];
                sc2 = codes[1];
                sc3 = codes[3];
            }
            (string sc, string sc2, string sc3) r = (sc: sc, sc2: sc2, sc3: sc3);
            return r;
        }
    }
}
