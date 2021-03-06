﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Manager
{
    public partial class DlgProduct : Form
    {
        public Product Data = new Product();
        public DlgProduct()
        {
            InitializeComponent();
        }
        private void DlgProduct_Load(object sender, EventArgs e)
        {
            tbName.Text   = Data.Name;
            tbCatalog.Text= Data.Catalog;
            tbUnit.Text   = Data.Unit;

            tbBuyPrice.Text = Data.BuyPrice.ToString();
            tbSalePrice.Text= Data.SalePrice.ToString();
            nudVatRate.Value= Data.VatRate;
        }
        private void DlgProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( DialogResult != DialogResult.OK )
                return;
        // check data 
            if ( string.IsNullOrEmpty(tbName.Text) )
            {
                GM.ShowErrorMessageBox(this, "Name may not be empty!");
                tbName.Focus();
                e.Cancel = true;
                return;
            }
        // save data
            Data.Name    = tbName.Text;
            Data.Catalog = tbCatalog.Text;
            Data.Unit    = tbUnit.Text;
            try { Data.BuyPrice = decimal.Parse(tbBuyPrice.Text); } 
            catch(Exception ex) 
            { 
                GM.ShowErrorMessageBox(this, "Enter buy price", ex); 
                tbBuyPrice.Focus(); 
                e.Cancel = true;
                return;
            }
            try { Data.SalePrice = decimal.Parse(tbSalePrice.Text); } 
            catch(Exception ex) 
            { 
                GM.ShowErrorMessageBox(this, "Enter sale price", ex); 
                tbSalePrice.Focus(); 
                e.Cancel = true;
                return;
            }
            Data.VatRate = nudVatRate.Value;
        }
    }
}
