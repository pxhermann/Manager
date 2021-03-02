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
                MessageBox.Show(this, "Name may not be empty!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbName.Focus();
                e.Cancel = true;
                return;
            }
            if ( tbICO.Text.Length > 0 && !Address.CheckICO(tbICO.Text) && 
                 MessageBox.Show(this, "Entered IC doesn't comply IC validation algorithm. Continue anyway?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes )
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
            if ( tbICO.Text.Length < 1 )
            {
                MessageBox.Show(this, "Enter IC first!", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbICO.Focus();
                return;
            }
            if ( !Address.CheckICO(tbICO.Text) && 
                 MessageBox.Show(this, "Entered IC doesn't comply IC validation algorithm. Continue anyway?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes )
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
                XElement elAddr = GetElement(elRoot, new XName[] {are + "Odpoved", are + "Zaznam"});
                if ( elAddr == null )
                {
                    s = string.Format("No address found in ARES for IC: {0}", tbICO.Text);
                    MessageBox.Show(this, s, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                    return;
                }

                // name
                tbName.Text = GetElementValue(elAddr, are + "Obchodni_firma");
                //** address
                elAddr = GetElement(elAddr, new XName[] {are + "Identifikace", are + "Adresa_ARES"});
                if ( elAddr != null )
                {
                    string strObec = GetElementValue(elAddr, dtt+"Nazev_obce");
                 // city
                    s = GetElementValue(elAddr, dtt+"Nazev_mestske_casti");
                    tbCity.Text = (s.Length>0)?s:strObec;
                 // street
                    s = GetElementValue(elAddr, dtt+"Nazev_ulice");
                    tbStreet.Text  = (s.Length>0)?s:strObec;
                    //
                    s = GetElementValue(elAddr, dtt+"Cislo_domovni");
                    if ( s.Length > 0 ) 
                        tbStreet.Text += " "+s;
                    s = GetElementValue(elAddr, dtt+"Cislo_orientacni");
                    if ( s.Length > 0 ) 
                        tbStreet.Text += "/"+s;
                 // ZIP
                    tbZip.Text = GetElementValue(elAddr, dtt+"PSC");
                }
                //**DIC
                s = GetElementValue(elRoot, new XName[] {are+"Odpoved", are+"Zaznam", are+"Priznaky_subjektu"});
                if ( s != null && s.Length > 5 && (s[5] == 'A' || s[5] == 'a') )
                {
                    strUrl = string.Format("http://wwwinfo.mfcr.cz/cgi-bin/ares/darv_bas.cgi?ico={0}&aktivni=false", tbICO.Text);
                    using ( WebClient webCli = new WebClient() )
                        using ( StreamReader r = new StreamReader(webCli.OpenRead(strUrl)))
                            s = r.ReadToEnd();

                    elRoot = XElement.Parse(s);
                    are = "http://wwwinfo.mfcr.cz/ares/xml_doc/schemas/ares/ares_answer_basic/v_1.0.3";
                    dtt = "http://wwwinfo.mfcr.cz/ares/xml_doc/schemas/ares/ares_datatypes/v_1.0.3";

                    tbDIC.Text = GetElementValue(elRoot, new XName[] {are+"Odpoved", dtt+"VBAS", dtt+"DIC"});
                }
            }
            catch (Exception ex)
            {
                GM.ReportError(this, ex, string.Format("Error occured when reading ARES data from '{0}'", strUrl));
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private XElement GetElement(XElement parent, params XName[] path)
        {
            XElement elHlp = parent;
            foreach (XName name in path)
            {
                if (elHlp == null)
                    break;
                elHlp = elHlp.Element(name);
            }
            return elHlp;
        }
        private string GetElementValue(XElement parent, params XName[] path)
        {
            XElement elHlp = GetElement(parent, path);

            return (elHlp==null)?"":elHlp.Value;
        }
/* 
        private void btnGetARES_Click(object sender, EventArgs e)
        {
        // check ICO
            if ( tbICO.Text.Length < 1 )
            {
                MessageBox.Show(this, "Enter IC first!", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbICO.Focus();
                return;
            }
            if ( !Address.CheckICO(tbICO.Text) && 
                 MessageBox.Show(this, "Entered IC doesn't comply IC validation algorithm. Continue anyway?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes )
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
                XmlNode n, nodeAddr;
                XmlDocument doc = new XmlDocument();
                using ( WebClient webCli = new WebClient() )
                    using ( StreamReader r = new StreamReader(webCli.OpenRead(strUrl)))
                        doc.LoadXml(r.ReadToEnd());

                XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
                ns.AddNamespace("are", "http://wwwinfo.mfcr.cz/ares/xml_doc/schemas/ares/ares_answer/v_1.0.1");
                ns.AddNamespace("dtt", "http://wwwinfo.mfcr.cz/ares/xml_doc/schemas/ares/ares_datatypes/v_1.0.4");

                // check whether address exists
                nodeAddr = doc.DocumentElement.SelectSingleNode("are:Odpoved/are:Zaznam", ns);
                if ( nodeAddr == null )
                {
                    s = string.Format("No address found in ARES for IC: {0}", tbICO.Text);
                    MessageBox.Show(this, s, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                    return;
                }
                // name
                n = nodeAddr.SelectSingleNode("are:Obchodni_firma", ns);
                if ( n != null )
                    tbName.Text = n.FirstChild.Value.ToString();
                //** address
                nodeAddr = nodeAddr.SelectSingleNode("are:Identifikace/are:Adresa_ARES", ns);
                if ( nodeAddr != null )
                {
                    string strObec = "";
                    n = nodeAddr.SelectSingleNode("dtt:Nazev_obce", ns);
                    if ( n != null )
                        strObec = n.FirstChild.Value.ToString();
                    // city
                    s = "";
                    n = nodeAddr.SelectSingleNode("dtt:Nazev_mestske_casti", ns);
                    if ( n != null )
                        s = n.FirstChild.Value.ToString();
                    tbCity.Text = (s.Length>0)?s:strObec;
                    // street
                    n = nodeAddr.SelectSingleNode("dtt:Nazev_ulice", ns);
                    tbStreet.Text = ( n == null )?strObec:n.FirstChild.Value.ToString();
                    // 
                    {
                        n = nodeAddr.SelectSingleNode("dtt:Cislo_domovni", ns);
                        if ( n != null )
                            tbStreet.Text += " "+n.FirstChild.Value.ToString();
                        n = nodeAddr.SelectSingleNode("dtt:Cislo_orientacni", ns);
                        if ( n != null )
                            tbStreet.Text += "/"+n.FirstChild.Value.ToString();
                    }
                    // ZIP
                    n = nodeAddr.SelectSingleNode("dtt:PSC", ns);
                    if ( n != null )
                        tbZip.Text = n.FirstChild.Value.ToString();
                }
                //**DIC
                n = doc.DocumentElement.SelectSingleNode("are:Odpoved/are:Zaznam/are:Priznaky_subjektu", ns);
                if ( n != null )
                {
                    s = n.FirstChild.Value.ToString();
                    if ( s != null && s.Length > 5 && (s[5] == 'A' || s[5] == 'a') )
                    {
                        strUrl = string.Format("http://wwwinfo.mfcr.cz/cgi-bin/ares/darv_bas.cgi?ico={0}&aktivni=false", tbICO.Text);
                        using ( WebClient webCli = new WebClient() )
                            using ( StreamReader r = new StreamReader(webCli.OpenRead(strUrl)))
                                doc.LoadXml(r.ReadToEnd());

                        ns = new XmlNamespaceManager(doc.NameTable);
                        ns.AddNamespace("are", "http://wwwinfo.mfcr.cz/ares/xml_doc/schemas/ares/ares_answer_basic/v_1.0.3");
                        ns.AddNamespace("D", "http://wwwinfo.mfcr.cz/ares/xml_doc/schemas/ares/ares_datatypes/v_1.0.3");
                        n = doc.DocumentElement.SelectSingleNode("are:Odpoved/D:VBAS/D:DIC", ns);
                        if ( n != null )
                            tbDIC.Text = n.FirstChild.Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                GM.ReportError(this, ex, string.Format("Error occured when reading ARES data from '{0}'", strUrl));
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
 */ 
    }
}
