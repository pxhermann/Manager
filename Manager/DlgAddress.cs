using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Manager
{
    public partial class DlgAddress : Form
    {
        public Address Data = new Address();

        public DlgAddress()
        {
            InitializeComponent();
        }

        private void DlgAddress_Load(object sender, EventArgs e)
        {
            tbName.Text   = Data.Name;
            tbStreet.Text = Data.Street;
            tbCity.Text   = Data.City;
            tbZip.Text    = Data.Zip;

            tbICO.Text    = Data.ICO;
            tbDIC.Text    = Data.DIC;

            tbTel.Text    = Data.Tel;
            tbFax.Text    = Data.Fax;

            tbNote.Text   = Data.Note;
        }

        private void DlgAddress_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( DialogResult != DialogResult.OK )
                return;
        // check data 
            if ( tbName.Text.Trim().Length < 1 )
            {
                GM.ShowErrorMessageBox(this, "Name may not be empty!");
                tbName.Focus();
                e.Cancel = true;
                return;
            }
            if ( tbICO.Text.Length > 0 && !Address.CheckICO(tbICO.Text) && 
                 GM.ShowQuestionMessageBox(this, "Entered IC doesn't comply IC validation algorithm. Continue anyway?") != DialogResult.Yes )
            {
                tbICO.Select(0, tbICO.Text.Length);
                tbICO.Focus();
                e.Cancel = true;
                return;
            }
        // save data
            Data.Name   = tbName.Text;
            Data.Street = tbStreet.Text;
            Data.City   = tbCity.Text;
            Data.Zip    = tbZip.Text;

            Data.ICO    = tbICO.Text;
            Data.DIC    = tbDIC.Text;

            Data.Tel    = tbTel.Text;
            Data.Fax    = tbFax.Text;

            Data.Note   = tbNote.Text;
        }

        private void btnGetARES_Click(object sender, EventArgs e)
        {
        // check ICO
            if ( String.IsNullOrEmpty(tbICO.Text) )
            {
                GM.ShowErrorMessageBox(this, "Enter IC first!");
                tbICO.Focus();
                return;
            }
            if ( !Address.CheckICO(tbICO.Text) && 
                 GM.ShowQuestionMessageBox(this, "Entered IC doesn't comply IC validation algorithm. Continue anyway?") != DialogResult.Yes )
            {
                tbICO.Select(0, tbICO.Text.Length);
                tbICO.Focus();
                return;
            }
        // get address from ARES
            string strUrl = string.Format("http://wwwinfo.mfcr.cz/cgi-bin/ares/darv_std.cgi?ico={0}&aktivni=false", tbICO.Text);

            Cursor = Cursors.WaitCursor;
            try
            {
                string s;
                using ( WebClient webCli = new WebClient() )
                    using ( StreamReader r = new StreamReader(webCli.OpenRead(strUrl)))
                        s = r.ReadToEnd();

                XNamespace are = "http://wwwinfo.mfcr.cz/ares/xml_doc/schemas/ares/ares_answer/v_1.0.1";
                XNamespace dtt = "http://wwwinfo.mfcr.cz/ares/xml_doc/schemas/ares/ares_datatypes/v_1.0.4";

                XElement elRoot = XElement.Parse(s);
                XElement elAddr = GM.GetXElement(elRoot, new XName[] {are + "Odpoved", are + "Zaznam"});
                if ( elAddr == null )
                {
                    GM.ShowErrorMessageBox(this, string.Format("No address found in ARES for IC: {0}", tbICO.Text));
                    return;
                }

                // name
                tbName.Text = GM.GetXElementValue(elAddr, are + "Obchodni_firma");
                //** address
                elAddr = GM.GetXElement(elAddr, new XName[] {are + "Identifikace", are + "Adresa_ARES"});
                if ( elAddr != null )
                {
                    string strObec = GM.GetXElementValue(elAddr, dtt+"Nazev_obce");
                 // city
                    s = GM.GetXElementValue(elAddr, dtt+"Nazev_mestske_casti");
                    tbCity.Text = (s.Length>0)?s:strObec;
                 // street
                    s = GM.GetXElementValue(elAddr, dtt+"Nazev_ulice");
                    tbStreet.Text  = (s.Length>0)?s:strObec;
                    //
                    s = GM.GetXElementValue(elAddr, dtt+"Cislo_domovni");
                    if ( s.Length > 0 ) 
                        tbStreet.Text += " "+s;
                    s = GM.GetXElementValue(elAddr, dtt+"Cislo_orientacni");
                    if ( s.Length > 0 ) 
                        tbStreet.Text += "/"+s;
                 // ZIP
                    tbZip.Text = GM.GetXElementValue(elAddr, dtt+"PSC");
                }
                //**DIC
                s = GM.GetXElementValue(elRoot, new XName[] {are+"Odpoved", are+"Zaznam", are+"Priznaky_subjektu"});
                if ( s != null && s.Length > 5 && (s[5] == 'A' || s[5] == 'a') )
                {
                    strUrl = string.Format("http://wwwinfo.mfcr.cz/cgi-bin/ares/darv_bas.cgi?ico={0}&aktivni=false", tbICO.Text);
                    using ( WebClient webCli = new WebClient() )
                        using ( StreamReader r = new StreamReader(webCli.OpenRead(strUrl)))
                            s = r.ReadToEnd();

                    elRoot = XElement.Parse(s);
                    are = "http://wwwinfo.mfcr.cz/ares/xml_doc/schemas/ares/ares_answer_basic/v_1.0.3";
                    dtt = "http://wwwinfo.mfcr.cz/ares/xml_doc/schemas/ares/ares_datatypes/v_1.0.3";

                    tbDIC.Text = GM.GetXElementValue(elRoot, new XName[] {are+"Odpoved", dtt+"VBAS", dtt+"DIC"});
                }
            }
            catch (Exception ex) { GM.ShowErrorMessageBox(this, string.Format("Error occured when reading ARES data from '{0}'", strUrl), ex); }
            finally { Cursor = Cursors.Default; }
        }
    }
}
