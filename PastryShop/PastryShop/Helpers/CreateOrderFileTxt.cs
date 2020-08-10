using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastryShop.Helpers
{
    public class CreateOrderFileTxt
    {
        public static void CreateOrder(string customerName, int orderId, string comments)
        {
            FileInfo txt = new FileInfo(string.Format(@"..\..\{0}_{1}.txt", customerName, orderId));
            StreamWriter sw = txt.AppendText();
            comments=ConvertString.CommentString(comments);
            sw.WriteLine("{0}", comments);
            sw.Close();
        }
    }
}
