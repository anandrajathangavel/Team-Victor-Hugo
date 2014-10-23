using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBooking.WebForms.Controls.SmallStarStack
{
    public partial class SmallStarStack : System.Web.UI.UserControl
    {
        public int StarCount { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.StarStack.DataSource = new bool[this.StarCount];
            this.StarStack.DataBind();

            this.IncludeContent();
        }

        private void IncludeContent()
        {
            ClientScriptManager cs = Page.ClientScript;

            string cssRelativeUrl = this.TemplateSourceDirectory +
                "/Styles/SmallStarStack.css";

            if (!cs.IsClientScriptBlockRegistered(cssRelativeUrl))
            {
                string cssLinkCode = string.Format(
                    @"<link href='{0}' rel='stylesheet' type='text/css' />",
                    cssRelativeUrl);

                cs.RegisterClientScriptBlock(this.GetType(), cssRelativeUrl, cssLinkCode);
            }
        }
    }
}