using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    internal class FoodDAO
    {
        private static FoodDAO instance;

        internal static FoodDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new FoodDAO();
                return instance;
            }
            private set => instance = value;
        }

        private FoodDAO() { }

        public List<Food> GetFoodByCatagoryId(int catagoryId)
        {
            List<Food> listFood = new List<Food>();

            string query = $"SELECT * FROM Food WHERE idCategory = {catagoryId}";

            DataTable dt = DataProvider.Intance.ExcuteQuery(query);

            foreach (DataRow item in dt.Rows)
            {
                Food food = new Food(item);

                listFood.Add(food);
            }

            return listFood;
        }
    }
}
