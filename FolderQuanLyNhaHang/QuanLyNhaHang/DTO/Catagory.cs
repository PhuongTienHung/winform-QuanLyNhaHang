using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    internal class Catagory
    {
        private int id;
        private string name;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public Catagory() { }

        public Catagory(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public Catagory(DataRow row)
        {
            this.id = (int)row["id"];
            this.name = row["name"].ToString();
        }
    }
}
