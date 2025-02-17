﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    internal class Table
    {
        private int iD;
        private string name;
        private string status;

        Table(int iD, string name, string status)
        {
            ID = iD;
            Name = name;
            Status = status;
        }

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }

        public Table(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Status = row["status"].ToString();
            this.Name = row["name"].ToString();
        }
    }
}
