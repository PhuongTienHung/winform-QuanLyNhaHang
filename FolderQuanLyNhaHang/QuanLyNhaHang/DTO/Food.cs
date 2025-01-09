using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    internal class Food
    {
        private int id;
        private string name;
        private int idCatagory;
        private float price;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int IdCatagory { get => idCatagory; set => idCatagory = value; }
        public float Price { get => price; set => price = value; }

        public Food() { }

        public Food(int id, string name, int idCatagory, float price)
        {
            Id = id;
            Name = name;
            IdCatagory = idCatagory;
            Price = price;
        }

        public Food(DataRow dataRow)
        {
            this.id = (int)dataRow["id"];
            this.name = dataRow["name"].ToString();
            this.IdCatagory = (int)dataRow["idCategory"];
            this.price = (float )((double)dataRow["price"]);
        }
    }
}
