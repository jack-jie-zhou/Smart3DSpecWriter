using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart3DSpecWriter.PipeBranchTable
{
    public class PipeBranchShortCode
    {
        private string sc;
        private string sc2;
        private string sc3;

        public PipeBranchShortCode(string sc, string sc2, string sc3)
        {
            this.sc = sc??"";
            this.sc2 = sc2??"";
            this.sc3 = sc3??"";
        }

        public string ShortCode1  => sc;
        public string ShortCode2 => sc2;
        public string ShortCode3 => sc3;

        public static implicit operator string(PipeBranchShortCode sc)
        {
            return $"{sc.ShortCode1}\n{sc.ShortCode2}\n{sc.ShortCode3}";
        }

        public static explicit operator PipeBranchShortCode(string codeString)
        {
            (string sc, string sc2, string sc3) codes = GetCodes(codeString);
            PipeBranchShortCode sc = new PipeBranchShortCode(codes.sc,codes.sc2,codes.sc3);
            return sc;
        }

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
