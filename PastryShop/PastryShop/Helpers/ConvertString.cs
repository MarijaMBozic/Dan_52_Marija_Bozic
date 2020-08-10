using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastryShop.Helpers
{
    public class ConvertString
    {
        public static string CommentString(string comment)
        {
            StringBuilder sb = new StringBuilder();
            string[] str = comment.Split();

            sb.Append("A list of ingredients that curtomer don’t want in cakes!");
            foreach (string s in str)
            {
                sb.Append(string.Format("\n{0}", s));
            }
            return sb.ToString();
        }
    }
}
