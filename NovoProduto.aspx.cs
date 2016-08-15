using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebFormsStore
{
    public partial class NovoProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (HttpPostedFile htfiles in FileUpload1.PostedFiles)
            {
                string getFileName = Path.GetFileName(htfiles.FileName);
                htfiles.SaveAs(Server.MapPath("~/Files/" + getFileName));
            }
            Label1.Visible = true;
            Label1.Text = FileUpload1.PostedFiles.Count.ToString() + "Arquivo enviado com sucesso.";
        }

    }
}