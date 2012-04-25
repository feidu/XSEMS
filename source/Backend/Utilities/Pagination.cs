using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace Backend.Utilities
{
    public class Pagination : Control
    {
        private int mTotalCount = 0;

        public int TotalCount
        {
            get { return mTotalCount; }
            set { mTotalCount = value; }
        }

        private int pageSize = 0;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        private bool hiddenCustomizedPageSize = false;

        public bool HiddenCustomizedPageSize
        {
            get { return hiddenCustomizedPageSize; }
            set { hiddenCustomizedPageSize = value; }
        }

        protected override void Render(HtmlTextWriter output)
        {
            if (TotalCount <= Constants.PAGE_SIZE_TWENTY) return;
            System.Web.HttpRequest request = System.Web.HttpContext.Current.Request;
            // Build base url
            int page = PaginationHelper.GetCurrentPage(request);

            string pageSizeString = request.QueryString[Constants.REQUEST_PAGE_SIZE];
            if (pageSizeString != null)
            {
                Validator.IsMatchNumber(pageSizeString);
                pageSize = Convert.ToInt16(pageSizeString);
            }
            else if (pageSize == 0)
            {
                pageSize = Constants.PAGE_SIZE_DEFAULT;
            }

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.Collections.Specialized.NameValueCollection queryStrings = request.QueryString;
            sb.Append(request.Path).Append(Constants.REQUEST_QUESTION_MAKR);
            for (int i = 0, n = queryStrings.Keys.Count; i < n; i++)
            {
                string key = queryStrings.Keys[i];
                if (key != Constants.REQUEST_PAGE_NUMBER && key != Constants.REQUEST_PAGE_SIZE)
                {
                    sb.Append(key).Append(Constants.REQUEST_EQUAL).Append(queryStrings[i])
                        .Append(Constants.REQUEST_AMPERSAND);
                }
            }
            sb.Append(Constants.REQUEST_PAGE_SIZE).Append(Constants.REQUEST_EQUAL);
            string urlWithoutItemCount = sb.ToString();
            sb.Append(pageSize).Append(Constants.REQUEST_AMPERSAND)
                .Append(Constants.REQUEST_PAGE_NUMBER).Append(Constants.REQUEST_EQUAL);
            string url = sb.ToString();

            // Calculate page parameters
            int pageCount = (int)Math.Ceiling(1.0 * TotalCount / pageSize);
            int start = page / Constants.PAGE_SHOW_NUMBER * Constants.PAGE_SHOW_NUMBER + 1;
            if (page % Constants.PAGE_SHOW_NUMBER == 0)
            {
                start = start - Constants.PAGE_SHOW_NUMBER;
            }
            int end = start + Constants.PAGE_SHOW_NUMBER - 1;
            if (end > pageCount)
            {
                end = pageCount;
            }

            // Output begin and previous pages
            output.Write("<table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\">");
            output.Write("<tr><td width=\"0\" class=\"page-link\">");
            output.Write("</td>");
            //output.Write("<tr><td width=\"10\" class=\"page-link\">");
            //output.Write("<img src=\"/Images/Dz_left_searh.gif\" width=\"8\" height=\"7\"></td>");
            output.Write("<td class=\"page-link\"> ");
            if (TotalCount > 0)
            {
                output.Write(((page - 1) * pageSize + 1));
            }
            else
            {
                output.Write(0);
            }
            output.Write(" - ");
            int endItem = page * pageSize;
            if (endItem > TotalCount)
            {
                output.Write(TotalCount);
            }
            else
            {
                output.Write(endItem);
            }
            output.Write("条 共");
            output.Write(TotalCount);
            output.Write("条结果");
            output.Write("</td><td width=\"10\" align=\"center\" class=\"page-td\">");
            if (start > Constants.PAGE_SHOW_NUMBER)
            {
                output.Write("<a href=\"");
                output.Write(url);
                output.Write((start - Constants.PAGE_SHOW_NUMBER));
                output.Write("\" class=\"page-link\">");
                output.Write("<img src=\"/Images/Page_last10.gif\" alt=\"前");
                output.Write(Constants.PAGE_SHOW_NUMBER);
                output.Write("页\" width=\"7\" height=\"7\" border=\"0\"></a>");
            }
            else
            {
                output.Write("<img src=\"/Images/Page_last10_g.gif\" width=\"7\" height=\"7\" border=\"0\">");
            }
            output.Write("</td><td width=\"9\" align=\"center\" class=\"page-td\">");
            if (page > 1)
            {
                output.Write("<a href=\"");
                output.Write(url);
                output.Write((page - 1));
                output.Write("\" class=\"page-link\"><img src=\"/Images/Page_last.gif\"");
                output.Write(" alt=\"前页\" width=\"4\" height=\"7\" border=\"0\"></a>");
            }
            else
            {
                output.Write("<img src=\"/Images/Page_last_g.gif\" width=\"4\" height=\"7\" border=\"0\">");
            }
            output.Write("</td>");

            // Output single page link
            for (int i = start; i <= end; i++)
            {
                output.Write("<td width=\"9\" align=\"center\" class=\"page-td\">");
                if (i == page)
                {
                    output.Write(i);
                }
                else
                {
                    output.Write("<a href=\"");
                    output.Write(url);
                    output.Write(i);
                    output.Write("\" class=\"page-link\">");
                    output.Write(i);
                    output.Write("</a>");
                }
                output.Write("</td>");
            }

            // Output next pages
            output.Write("<td width=\"9\" align=\"center\" class=\"page-td\">");
            if (page < pageCount)
            {
                output.Write("<a href=\"");
                output.Write(url);
                output.Write((page + 1));
                output.Write("\" class=\"page-link\"><img src=\"/Images/Page_next.gif\"");
                output.Write(" alt=\"后页\" width=\"4\" height=\"7\" border=\"0\"></a>");
            }
            else
            {
                output.Write("<img src=\"/Images/Page_next_g.gif\" width=\"4\" height=\"7\" border=\"0\">");
            }
            output.Write("</td><td width=\"10\" align=\"center\" class=\"page-td\">");
            if (end < pageCount)
            {
                output.Write("<a href=\"");
                output.Write(url);
                int next = page + Constants.PAGE_SHOW_NUMBER;
                if (next < pageCount)
                {
                    output.Write(next);
                }
                else
                {
                    output.Write(pageCount);
                }
                output.Write("\" class=\"page-link\">");
                output.Write("<img src=\"/Images/Page_next10.gif\" alt=\"后");
                output.Write(Constants.PAGE_SHOW_NUMBER);
                output.Write("页\" width=\"7\" height=\"7\" border=\"0\"></a>");
            }
            else
            {
                output.Write("<img src=\"/Images/Page_next10_g.gif\" width=\"7\" height=\"7\" border=\"0\">");
            }
            output.Write("</td>");

            // Output page count choose
            if (!hiddenCustomizedPageSize)
            {
                output.Write("<td width=\"65\" align=\"right\" class=\"page-td\">");
                if (pageSize == Constants.PAGE_SIZE_TWENTY)
                {
                    output.Write("<img src=\"/Images/Page_20_g.gif\" width=\"16\" height=\"13\" border=\"0\"> ");
                }
                else
                {
                    output.Write("<a href=\"");
                    output.Write(urlWithoutItemCount);
                    output.Write(Constants.PAGE_SIZE_TWENTY);
                    output.Write("\"><img src=\"/Images/Page_20.gif\" alt=\"每页显示");
                    output.Write(Constants.PAGE_SIZE_TWENTY);
                    output.Write("条\"");
                    output.Write(" width=\"16\" height=\"13\" border=\"0\"></a> ");
                }
                if (pageSize == Constants.PAGE_SIZE_FORTY)
                {
                    output.Write("<img src=\"/Images/Page_40_g.gif\" width=\"17\" height=\"13\" border=\"0\"> ");
                }
                else
                {
                    output.Write("<a href=\"");
                    output.Write(urlWithoutItemCount);
                    output.Write(Constants.PAGE_SIZE_FORTY);
                    output.Write("\"><img src=\"/Images/Page_40.gif\" alt=\"每页显示");
                    output.Write(Constants.PAGE_SIZE_FORTY);
                    output.Write("条\"");
                    output.Write(" width=\"17\" height=\"13\" border=\"0\"></a> ");
                }
                if (pageSize == Constants.PAGE_SIZE_EIGHTY)
                {
                    output.Write("<img src=\"/Images/Page_80_g.gif\" width=\"18\" height=\"13\" border=\"0\"> ");
                }
                else
                {
                    output.Write("<a href=\"");
                    output.Write(urlWithoutItemCount);
                    output.Write(Constants.PAGE_SIZE_EIGHTY);
                    output.Write("\"><img src=\"/Images/Page_80.gif\" alt=\"每页显示");
                    output.Write(Constants.PAGE_SIZE_EIGHTY);
                    output.Write("条\"");
                    output.Write(" width=\"18\" height=\"13\" border=\"0\"></a>");
                }
                output.Write("</td>");
            }

            output.Write("</tr></table>");
        }
    }
}
