using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            string text = btnhyperlink.Text;

            if (text.Contains("http"))
            {
                HyperLink hl = new HyperLink();
                hl.Text = btnhyperlink.Text;
                string hypertext = hl.Text;

                hl.NavigateUrl = hypertext;
               
                btnhyperlink.Parent.Controls.Add(hl);
                btnhyperlink.Visible = false;
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string text = TextBox1.Text;

            if (text.Contains("http"))
            {
                HyperLink hl = new HyperLink();
                hl.Text = TextBox1.Text;
                string hypertext = hl.Text;

                hl.NavigateUrl = hypertext;



                TextBox1.Parent.Controls.Add(hl);
                TextBox1.Visible = false;
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string test = btnhyperlink.Text;
            MakeLink(test);
        }

        protected string MakeLink(string txt)
        {
            Regex regx = new Regex("http://([\\w+?\\.\\w+])+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\\\/\\?\\.\\:\\;\\'\\,]*)?", RegexOptions.IgnoreCase);

            MatchCollection mactches = regx.Matches(txt);

            foreach (Match match in mactches)
            {
                txt = txt.Replace(match.Value, "<a href='" + match.Value + "'>" + match.Value + "</a>");
            }

            return txt;
        }
    }
}
