using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication4.Model;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            Expl02();
        }

        //Прямая загрузка
        public static void Expl01()
        {
            MCS db = new MCS();

            db.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));

            int i = 0;
            foreach (var accessTab in db.AccessTab)
            {
                i++;
                Console.WriteLine(accessTab.strTabName);
                foreach (var user in accessTab.AccessUser)
                {
                    Console.WriteLine("\t-->" + user.intUserId);
                }
            }

            List<AccessTab> tabs = db.AccessTab.Include(c => c.AccessUser)
                //.Include() можно подключать несколько include
                .ToList();
        }
        //Явная загрузка (точечная загрузка, удобна когда связь медленная) 
        public static void Expl02()
        {
            MCS db = new MCS();
            //Загрузка одной вкладки
            AccessTab tab =
                db.AccessTab.Where(w => w.intTabID == 1).FirstOrDefault();
            addExpl02(tab);
            //Загрузка связанные данные с этой вкладки
           // db.Entry(tab).Collection(c => c.AccessUser).Load();

            //Console.WriteLine(tab.strTabName);
            //foreach (var user in tab.AccessUser)
            //{
            //    Console.WriteLine("\t--> " + user.intUserId);
            //} 

        }

        public static void addExpl02(AccessTab tab)
        {
            Console.WriteLine(tab.strTabName);
            foreach (var user in tab.AccessUser)
            {
                Console.WriteLine("\t--> " + user.intUserId);
            }
        }
    }
}
