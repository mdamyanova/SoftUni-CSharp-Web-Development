using System.Drawing;
using System.Linq;
using Novacode;

namespace _05.WordDocumentGenerator
{
    public class Generator
    {
        public const string HeadlineText = "SoftUni OOP Game Contest";

        public const string Text = "SoftUni is organizing a contest for the best role playing game " +
                                   "from the OOP teamwork projects. The winning teams will receive " +
                                   "a grand prize! The game should be:";

        public const string ImagePath = "../../rpg-game.png";

        public const string FilePath = "../../SoftUniOOPGameContest.docx";
        static void Main(string[] args)
        {
            using (var doc = DocX.Create(FilePath))
            {
                var title = doc.InsertParagraph();
                title.AppendLine(HeadlineText).Bold().FontSize(28);
                title.Alignment = Alignment.center;

                var img = doc.AddImage(ImagePath);
                var imgParagraph = doc.InsertParagraph("", false);
                var game = img.CreatePicture(200, 550);
                imgParagraph.InsertPicture(game);

                var text = doc.InsertParagraph();
                text.FontSize(15);
                text.AppendLine();
                text.Append(Text).FontSize(15);

                var bullets = doc.AddList(null, 0, ListItemType.Bulleted);
                doc.AddListItem(bullets, "Properly structured and follow all good OOP practices");
                doc.AddListItem(bullets, "Awesome");
                doc.AddListItem(bullets, "..Very Awesome");
                doc.InsertList(bullets);
                doc.InsertParagraph("\r\n");

                var table = doc.AddTable(4, 3);
                table.Alignment = Alignment.center;

                table.Rows[0].Cells[0].Paragraphs.First().Append("Team").Bold().Color(Color.White);
                table.Rows[0].Cells[0].Paragraphs.First().Alignment = Alignment.center;
                table.Rows[0].Cells[0].FillColor = Color.RoyalBlue;
                table.Rows[0].Cells[1].Paragraphs.First().Append("Game").Bold().Color(Color.White);
                table.Rows[0].Cells[1].Paragraphs.First().Alignment = Alignment.center;
                table.Rows[0].Cells[1].FillColor = Color.RoyalBlue;
                table.Rows[0].Cells[2].Paragraphs.First().Append("Points").Bold().Color(Color.White);
                table.Rows[0].Cells[2].Paragraphs.First().Alignment = Alignment.center;
                table.Rows[0].Cells[2].FillColor = Color.RoyalBlue;

                for (var i = 1; i < 4; i++)
                {
                    for (var j = 0; j < 3; j++)
                    {
                        table.Rows[i].Cells[j].Paragraphs.First().Append("-");
                        table.Rows[i].Cells[j].Paragraphs.First().Alignment = Alignment.center;
                    }
                }

                table.Rows[0].Cells.ForEach(c => c.Width = 300);
                table.Rows[1].Cells.ForEach(c => c.Width = 300);
                table.Rows[2].Cells.ForEach(c => c.Width = 300);
                doc.InsertTable(table);

                var lastText = doc.InsertParagraph();
                lastText.AppendLine();
                lastText.Append("The top 3 teams will receive a ").FontSize(15);
                lastText.Append("SPECTACULAR").Bold().FontSize(13);
                lastText.Append(" prize: \r\n").FontSize(15);
                lastText.Append("A HANDSHAKE FROM NAKOV")
                    .Bold()
                    .UnderlineStyle(UnderlineStyle.thick).FontSize(17)
                    .Color(Color.DarkBlue);
                lastText.Alignment = Alignment.center;

                doc.Save();
            }
        }
    }
}