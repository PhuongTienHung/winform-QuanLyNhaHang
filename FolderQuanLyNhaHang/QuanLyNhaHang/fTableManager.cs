using QuanLyNhaHang.DAO;
using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class fTableManager : Form
    {
        public fTableManager()
        {
            InitializeComponent();
            LoadTable();
            LoadCatagory();
            LoadFoodListByCatagoryId(1);
        }

        #region Event

        private void đăngToolStripMenuItem_Click(object sender, EventArgs e)//btn đăng xuất
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)//btn thông tin cá nhân
        {
            fAcountProfile f = new fAcountProfile();
            f.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)//btn Adimin
        {
            fAdmin f = new fAdmin();
            f.ShowDialog();
        }

        private void btn_click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag  as Table).ID;
            lsvBill.Tag = (sender as Button).Tag;
            showBill(tableID);
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)// COMBOBOX SELECET CHOOSE CATAGORY
        {
            int i = 0;
            i =  comboBox1.SelectedIndex;
            LoadFoodListByCatagoryId(i+1);
        }

        private void button1_Click(object sender, EventArgs e)//btn thêm món
        {
            Table table = lsvBill.Tag as Table;
            if(table == null)
            {
                MessageBox.Show("table đang rỗng", "thông báo");
            }
            else{
                MessageBox.Show("table đang không rỗng", "thông báo");

            }
            int idBill = BillDAO.Instance.GetUnCheckBillIDByTableId(table.ID);
            int foddId = (comboBox2.SelectedItem as Food).Id;
            int count = (int)nmFoodCount.Value;

            if (idBill == -1)
            {
                MessageBox.Show("giá trị id của table: "+table.ID, "thông báo");
                BillDAO.Instance.InsertBill(table.ID);
                BillInforDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxBillId(), foddId, count);
            }
            else
            {
                BillInforDAO.Instance.InsertBillInfo(idBill, foddId, count);
            }

            showBill(table.ID);
        }

        #endregion
        //---------------------------------------------------------------------------------------------------------------------
        #region Method

        void LoadTable()
        {
            List<Table> tableList = TableDAO.Intance.LoadTableList();

            foreach (Table item in tableList)
            {
                if (item != null)
                {
                    Button btn = new Button()
                    {
                        Width = TableDAO.TableWidth,
                        Height = TableDAO.TableHeight,

                    };
                    btn.Text = $"{item.Name} \n {item.Status}";
                    btn.Click += btn_click;
                    btn.Tag = item;
                    switch (item.Status)
                    {
                        case "ĐANG TRỐNG":
                            btn.BackColor = ColorTranslator.FromHtml("#CCCCCC"); 
                            break;

                        case "ĐANG SỬ DỤNG":
                            btn.BackColor = ColorTranslator.FromHtml("#00CC33");
                            break;

                        case "ĐÃ ĐẶT TRƯỚC":
                            btn.BackColor = ColorTranslator.FromHtml("#FFFF66");
                            break;

                    }
                    flpTable.Controls.Add(btn);
                }
            }
        }

        void showBill(int id)//show food on table by TableId
        {
            List<FoodOnTable> billInfos = FoodOnTableDAO.Instance.GetFoodsByTable(id);
            lsvBill.Items.Clear();
            float totalPrice = 0;
            foreach (FoodOnTable item in billInfos)
            {
                ListViewItem listViewItem = new ListViewItem(item.FoodName1);
                listViewItem.SubItems.Add(item.Count.ToString());
                listViewItem.SubItems.Add(item.Price.ToString("c"));
                listViewItem.SubItems.Add(item.TotalPrice.ToString("c"));
                totalPrice += item.TotalPrice;
                lsvBill.Items.Add(listViewItem);

            }

            txtTongTien.Text = totalPrice.ToString("c");
        }

        void LoadCatagory()
        {
            List<Catagory> listCatagory = CatagoryDAO.Instance.GetListCatagory();
            comboBox1.DataSource = listCatagory;
            comboBox1.DisplayMember = "name";
        }

        void LoadFoodListByCatagoryId(int idCatagory)
        {
            List<Food> listCatagory = FoodDAO.Instance.GetFoodByCatagoryId(idCatagory);
            comboBox2.DataSource = listCatagory;
            comboBox2.DisplayMember = "name";
        }

        #endregion

       
    }
}
