using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Manager
{
    public class Product
    {
        public int ID;
        //
        public string Name;
        public string Catalog;
        public string Unit;
        public decimal BuyPrice;
        public decimal SalePrice;
        public decimal VatRate;

        public Product()
        {
            Reset();
        }
        public override string ToString()
        {
            return Name;
        }
        public bool IsValid()
        {
            return (ID != GD.INVALID_ID);
        }
        public void Reset()
        {
            ID = GD.INVALID_ID; 

            Name = "";
            Catalog = "";
            Unit = "";
            BuyPrice = 0m;
            SalePrice = 0m;
            VatRate = 0m;
        }
        // do not catch exception here, let it fire to parent
        public void Load(DataRow r)
        {
            Reset();

            object o;
            o = r["prod_id"];       if ( o != null && o != Convert.DBNull ) ID = Convert.ToInt32(o);

            o = r["prod_name"];     if ( o != null && o != Convert.DBNull ) Name = Convert.ToString(o);
            o = r["prod_catalog"];  if ( o != null && o != Convert.DBNull ) Catalog = Convert.ToString(o);
            o = r["prod_unit"];     if ( o != null && o != Convert.DBNull ) Unit = Convert.ToString(o);
            o = r["prod_buyprice"]; if ( o != null && o != Convert.DBNull ) BuyPrice = Convert.ToDecimal(o);
            o = r["prod_saleprice"];if ( o != null && o != Convert.DBNull ) SalePrice = Convert.ToDecimal(o);
            o = r["prod_vatrate"];  if ( o != null && o != Convert.DBNull ) VatRate = Convert.ToDecimal(o);
        }
        public void Save(DataRow r)
        {
            r.BeginEdit();
            r["prod_name"]     = Name;
            r["prod_catalog"]  = Catalog;
            r["prod_unit"]     = Unit;
            r["prod_buyprice"] = BuyPrice;
            r["prod_saleprice"]= SalePrice;
            r["prod_vatrate"]  = VatRate;
            r.EndEdit();
        }
    }
}
