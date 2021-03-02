using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Manager
{
    public class Address
    {
        public int ID;
        //
        public string Name;
        public string Street;
        public string City;
        public string Zip;
        public string Tel;
        public string Fax;
        public string ICO;
        public string DIC;
        public string Note;

        public Address()
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
            Street = "";
            City = "";
            Zip = "";
            Tel = "";
            Fax = "";
            ICO = "";
            DIC = "";
            Note = "";
        }
        // do not catch exception here, let it fire to parent
        public void Load(DataRow r)
        {
            Reset();

            object o;
            o = r["addr_id"];     if ( o != null && o != Convert.DBNull ) ID = Convert.ToInt32(o);

            o = r["addr_name"];   if ( o != null && o != Convert.DBNull ) Name = Convert.ToString(o);
            o = r["addr_street"]; if ( o != null && o != Convert.DBNull ) Street = Convert.ToString(o);
            o = r["addr_city"];   if ( o != null && o != Convert.DBNull ) City = Convert.ToString(o);
            o = r["addr_zip"];    if ( o != null && o != Convert.DBNull ) Zip = Convert.ToString(o);
            o = r["addr_tel"];    if ( o != null && o != Convert.DBNull ) Tel = Convert.ToString(o);
            o = r["addr_fax"];    if ( o != null && o != Convert.DBNull ) Fax = Convert.ToString(o);
            o = r["addr_ICO"];    if ( o != null && o != Convert.DBNull ) ICO = Convert.ToString(o);
            o = r["addr_DIC"];    if ( o != null && o != Convert.DBNull ) DIC = Convert.ToString(o);
            o = r["addr_note"];   if ( o != null && o != Convert.DBNull ) Note = Convert.ToString(o);
        }
        public void Save(DataRow r)
        {
            r.BeginEdit();
            r["addr_name"]  = Name;
            r["addr_street"]= Street;
            r["addr_city"]  = City;
            r["addr_zip"]   = Zip;
            r["addr_tel"]   = Tel;
            r["addr_fax"]   = Fax;
            r["addr_ICO"]   = ICO;
            r["addr_DIC"]   = DIC;
            r["addr_note"]  = Note;
            r.EndEdit();
        }
        
        // kontrolni algoritmus ICO - pocita se odzadu s vynechanim posledni (kontrolni) cislice:
        // predposledni*2+ta pred ni*3+jeste pred tim*4 ... - takto vznikly
        // vysledek vezmeme modulo 11,
        // odecteme od jedenactky a mela by vzniknout posledni, kontrolni cislice.
        // Pokud vyjde 10 je kontrolni cislice 0.
        // Pro ICO 18826342 je to tedy 4*2+3*3+6*4+2*5+8*6+8*7+1*8=163
        // 163=9 (mod 11) a 11-9=2 - kontrolni cislice je 2
        public static bool CheckICO(string IC)
        {
	        int checkSum = 0;
	        for ( int i = IC.Length-2; i>=0; i-- )
		        checkSum += (IC[i]-('0')) * (IC.Length-i);

	        int rest = 11 - checkSum % 11;
	        if ( rest >= 10 )
		        rest -= 10;

	        return ( IC[IC.Length-1] - '0' == rest );
        }
    }
}
