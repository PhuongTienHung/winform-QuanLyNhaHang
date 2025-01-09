using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    internal class CatagoryDAO
    {
        private static CatagoryDAO instance;

        internal static CatagoryDAO Instance {
            get {
                if(instance == null)
                    instance = new CatagoryDAO();
                return instance;
            }  
            private set => instance = value; 
        }

        private CatagoryDAO() { }

        public List<Catagory> GetListCatagory()
        {
            List<Catagory> listCatagory = new List<Catagory>();

            string query = "SELECT * FROM FoodCategory";

            DataTable dt = DataProvider.Intance.ExcuteQuery(query);

            foreach (DataRow item in dt.Rows)
            {
                Catagory catagory = new Catagory(item);
                listCatagory.Add(catagory); 
            }

            return listCatagory;
        }
    }
}
