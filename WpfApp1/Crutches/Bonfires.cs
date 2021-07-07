using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace MainApp.Crutches
{
    public partial class Bonfire
    {
        public string bonfireName { get; set; }
        public string bonfireID { get; set; }
    }

    public class BonfiresItemList
    {
        public static List<Bonfire> LoadBonfireList()
        {
            List<Bonfire> lst = new List<Bonfire>();

            try
            {
                string _bonfires = Properties.Resources.bonfires;
                List<string> bonfires_list = _bonfires.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();


                foreach (string _bonfire in bonfires_list)
                {
                    Bonfire obj = new Bonfire();
                    string[] info = _bonfire.Split(':');

                    obj.bonfireName = info[0].ToString();
                    obj.bonfireID = info[1].ToString();

                    lst.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lst;
        }
    }
}
