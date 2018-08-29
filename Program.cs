using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;

namespace ArticleDigest
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            bool print = false;
            char scan = 'a';
            char prev = 'a';

            WebRequest request = WebRequest.Create("http://www.foxnews.com/politics/2018/08/29/chinese-company-reportedly-hacked-clintons-server-got-copy-every-email-in-real-time.html");
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            string html = String.Empty;

            using (StreamReader sr = new StreamReader(data))
            {
                html = sr.ReadToEnd();
                //Console.WriteLine(html);
                for (i = 0; i < html.Length; i++)
                {
                    prev = scan;
                    scan = html[i];

                    //look for opening <p> tag
                    if (prev == '<' && scan == 'p')
                    { print = true; } 
                    //look for closing </p> tag
                    if (prev == '/' && scan == 'p')
                    { print = false; }

                    if (print)
                    { Console.Write(scan); }

                }
            }
            //wait for input
            String pause = Console.ReadLine();
        }
    }
}
