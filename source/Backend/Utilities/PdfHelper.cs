using System;
using System.Collections.Generic;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Backend.Utilities
{
    public class PdfHelper
    {
        public static readonly BaseFont bfChinese = BaseFont.createFont("C:\\WINDOWS\\Fonts\\simsun.ttc,1", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        public static readonly Font fontMinSpace = new Font(bfChinese, 6, Font.NORMAL, new Color(0, 0, 0));
        public static readonly Font fontMaxSpace = new Font(bfChinese, 12, Font.NORMAL, new Color(0, 0, 0));
        public static readonly Font fontHeader = new Font(bfChinese, 12, Font.NORMAL, new Color(0, 0, 0));
        public static readonly Font fontTitle = new Font(bfChinese, 20, Font.NORMAL, new Color(0, 0, 0));
        public static readonly Font fontTableTitle = new Font(bfChinese, 12, Font.NORMAL, new Color(255, 255, 255));
        public static readonly Font fontTableFooter = new Font(bfChinese, 12, Font.NORMAL, new Color(0, 0, 128));
        public static readonly Font fontContent = new Font(bfChinese, 12, Font.NORMAL, new Color(0, 0, 0));
        public static readonly Font fontFooter = new Font(bfChinese, 12, Font.UNDERLINE, new Color(0, 0, 0));
        public static readonly Paragraph phMaxSpace = new Paragraph(new Chunk("   ", PdfHelper.fontMaxSpace));

        public static HeaderFooter GetHeardFooter(string companyName, string phone)
        {
            HeaderFooter header = new HeaderFooter(new Phrase("" + companyName + "                                                                   Tel£º" + phone, fontHeader), false);
            header.Border = Rectangle.BOTTOM;
            return header;
        }
        public static Cell GetTitleCellRight(string value)
        {
            Cell result = new Cell(new Paragraph(value, fontTableTitle));
            result.HorizontalAlignment = Element.ALIGN_RIGHT;
            result.VerticalAlignment = Element.ALIGN_MIDDLE;
            result.BackgroundColor = new Color(127, 127, 127);            
            return result;
        }
        public static Cell GetTitleCellLeft(string value)
        {
            Cell result = new Cell(new Paragraph(value, fontTableTitle));
            result.HorizontalAlignment = Element.ALIGN_LEFT;
            result.VerticalAlignment = Element.ALIGN_MIDDLE;
            result.BackgroundColor = new Color(127, 127, 127);
            return result;
        }

        public static Cell GetCellRight(string value)
        {
            Cell result = new Cell(new Paragraph(value, fontContent));
            result.HorizontalAlignment = Element.ALIGN_RIGHT;
            result.VerticalAlignment = Element.ALIGN_MIDDLE;
            return result;
        }
        public static Cell GetCellLeft(string value)
        {
            Cell result = new Cell(new Paragraph(value, fontContent));
            result.HorizontalAlignment = Element.ALIGN_LEFT;
            result.VerticalAlignment = Element.ALIGN_MIDDLE;
            return result;
        }

        public static Cell GetFooterCellRight(string value)
        {
            Cell result = new Cell(new Paragraph(value, fontTableFooter));
            result.HorizontalAlignment = Element.ALIGN_RIGHT;
            result.VerticalAlignment = Element.ALIGN_MIDDLE;
            result.BackgroundColor = new Color(234, 234, 234);
            return result;
        }
        public static Cell GetFooterCellLeft(string value)
        {
            Cell result = new Cell(new Paragraph(value, fontTableFooter));
            result.HorizontalAlignment = Element.ALIGN_LEFT;
            result.VerticalAlignment = Element.ALIGN_MIDDLE;
            result.BackgroundColor = new Color(234, 234, 234);
            return result;
        }        
    }
}
