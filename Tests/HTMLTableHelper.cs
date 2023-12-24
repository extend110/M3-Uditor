using System.Collections.Generic;
using System.Text;
using System.Web.UI.HtmlControls;

namespace Tests
{
    public class HTMLTableHelper
    {
        #region Fields

        private readonly HtmlTable htmlTable;

        #endregion

        #region Constructors

        public HTMLTableHelper(HtmlTable htmlTable)
        {
            this.htmlTable = htmlTable;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Converts HTML Table to Comma Seperated Values structure.
        /// </summary>
        /// <returns></returns>
        public string[] ConvertToCSV()
        {
            //Will hold all rows of table as CSV
            List<string> rows = new List<string>();

            //Loop through each row in the HTML table
            foreach (HtmlTableRow row in htmlTable.Rows)
            {
                StringBuilder rowCVS = new StringBuilder();
                //Loop through each cell in the row
                foreach (HtmlTableCell cell in row.Cells)
                {
                    //Appends cell Text to rowCVS
                    rowCVS.Append(cell.TagName.Trim());
                    //Adds comma after text
                    rowCVS.Append(",");
                }
                //Removes last Comma from row
                rowCVS.Remove(rowCVS.Length - 1, 1);
                //Add cvs row to list of rows
                rows.Add(rowCVS.ToString());
            }

            return rows.ToArray();
        }

        #endregion
    }
}
