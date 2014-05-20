using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoogleSearchAPI.Query;
using GoogleSearchAPI;
using GoogleSearchAPI.Resources;

namespace SearchResultsViewer
{
    public partial class Viewer : Form
    {
        public Viewer()
        {
            InitializeComponent();
        }

        private void btnGoogleSearch_Click(object sender, EventArgs e)
        {
            WebQuery query = new WebQuery(tbQuery.Text);
            IGoogleResultSet<GoogleWebResult> resultSet = GoogleService.Instance.Search<GoogleWebResult>(query);
            dgvResults.DataSource = resultSet.Results;
        }
    }
}
