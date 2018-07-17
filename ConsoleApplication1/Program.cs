using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ConsoleApplication1.Model;

namespace ConsoleApplication1
{
    class Program
    {
        public static MCSEntities2 db = new MCSEntities2();
        static void Main(string[] args)
        {




            exmpl03();



        }

        public static void exmpl01()
        {
            //Прямая загрузка(если есть include)
            db.Database.Log = Console.Write;
            List<newEquipment> equipments = db.newEquipment
                                                          .Include(d => d.TablesLocation)
                                                          .Include(d => d.TablesModel)
                                                          .Include(d => d.TablesModel.TablesManufacturer)
                                                          .ToList();
            Console.WriteLine("---------------------");
            foreach (var newEquipment in equipments)
            {
                Console.WriteLine(newEquipment.intGarageRoom);
                foreach (var pref in newEquipment.TablesModel.TablesSNPrefix)
                {
                    Console.WriteLine("->" + pref.strPrefix);
                }
            }
            Console.WriteLine("--------------------------");
        }

        public static void exmpl02()
        {
            //Ленивая загрузка(отложенная)
            db.Database.Log = Console.Write;
            foreach (var tablesModel in db.TablesModel.Take(5))
            {
                Console.WriteLine(tablesModel.strName);
                foreach (var tablesSnPrefix in tablesModel.TablesSNPrefix)
                {
                    Console.WriteLine("   -" + tablesSnPrefix.strPrefix);
                }
            }
        }

        public static void exmpl03()
        {
            //Явная загрузка
            db.Database.Log = Console.Write;
            TablesModel model = db.TablesModel.Find(1);
            db.Entry(model).Collection(c => c.TablesSNPrefix).Load();
        }
    }
}
