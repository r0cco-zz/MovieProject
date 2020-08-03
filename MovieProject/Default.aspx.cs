using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Net.Http.Headers;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateMovieGrid();
        }
    }

    protected override void Render(HtmlTextWriter writer)
    {
        foreach (GridViewRow r in MovieGrid.Rows)
        {
            if (r.RowType == DataControlRowType.DataRow)
            {
                r.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                r.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                r.ToolTip = "Click to select row";
                r.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.MovieGrid, "Select$" + r.RowIndex, true);
            }
        }

        base.Render(writer);
    }

    private void PopulateMovieGrid()
    {
        var movies = GetMovies().Result;
        var moviesObj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Movie>>(movies);
        MovieGrid.DataSource = moviesObj;
        MovieGrid.DataBind();
    }

    private async Task<string> GetMovies()
    {
        string result = "";

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:62942/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/Movies/").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
        }

        return result;
    }

    protected void MovieGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = MovieGrid.SelectedRow;
        MovieIDTextBox.Text = row.Cells[0].Text;
        MovieTitleTextBox.Text = row.Cells[1].Text;
        MovieRatingTextBox.Text = row.Cells[2].Text;
        YearReleasedTextBox.Text = row.Cells[3].Text;
    }
}