using Bb.Sdk.HttpParser;
using Bb.Sdk.HttpParser.Blocks;
using Bb.Sdk.HttpParser.Grammar;
using FastColoredTextBoxNS;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Range = FastColoredTextBoxNS.Range;

namespace Editor
{
    public partial class Form1 : Form
    {
        private BlockList _config;
        private ExtractDataVisitor _visitor;
        private readonly Dictionary<Guid, TreeNode> _dicNodes;
        public readonly Style[] Styles = new Style[sizeof(ushort) * 8];
        private Style blueStyleBold;
        private Style blueStyle;
        private Style greenStyle;
        private Style redStyle;

        public Form1()
        {
            InitializeComponent();

            var t = typeof(Functions);

            listViewLogs.Columns.Add(new ColumnHeader() { Text = "Message", Width = 400 });
            listViewLogs.Columns.Add(new ColumnHeader() { Text = "Position", Width = 80 });
            listViewLogs.Columns.Add(new ColumnHeader() { Text = "Line", Width = 80 });

            this._dicNodes = new Dictionary<Guid, TreeNode>();

            this.blueStyleBold = new TextStyle(Brushes.Blue, null, FontStyle.Bold);
            this.blueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
            this.greenStyle = new TextStyle(Brushes.Green, null, FontStyle.Italic);
            this.redStyle = new TextStyle(Brushes.Red, null, FontStyle.Regular);
            

        }

        private void RichTextBoxRule_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            timer1.Stop();
            timer1.Start();

            //e.ChangedRange.ClearStyle(blueStyle);

            // \w*\(\)
            e.ChangedRange.SetStyle(greenStyle, @"^--[^\r\n]*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(redStyle, "'[^']*'", RegexOptions.None);
            e.ChangedRange.SetStyle(blueStyleBold, "USING|SEARCH|NODE|ATTRIBUTE|AS|NEW|OBJECT|ARRAY|PROPERTY|SUB|LIMIT|SKIP|SELECT|STRING|DECIMAL|INTEGER|DATE|UUID|BOOLEAN");
            e.ChangedRange.SetStyle(blueStyle, @"\$[a-zA-Z]*\w*", RegexOptions.None);

            e.ChangedRange.SetFoldingMarkers("\\(", "\\)");



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            listViewLogs.Items.Clear();

            if (this.richTextBoxRule.Text.Length == 0)
                return;

            var sb = new StringBuilder(this.richTextBoxRule.Text);

            var parser = ReaderHtmlParser.ParseString(sb, "");
            this._config = parser.Parse();

            this._visitor = null;

            if (parser.Errors.Count() == 0)
            {


                Action<ErrorModel> actError = e =>
                {
                    var l = new ListViewItem() { Text = e.Message };
                    l.SubItems.Add(e.StartIndex.ToString());
                    l.SubItems.Add(e.Line.ToString());
                    listViewLogs.Items.Add(l);
                };

                Action<FoundHtmlNode> act = nodes =>
                {

                    TreeNode n = new TreeNode() { Text = nodes.Message, Tag = nodes, ToolTipText = nodes.Tooltip };
                    this._dicNodes.Add(nodes.Id, n);

                    if (this.treeViewSelections.Nodes.Count == 0)
                    {
                        treeViewSelections.Nodes.Add(n);
                    }
                    else
                    {
                        var n2 = this._dicNodes[nodes.Parent];
                        n2.Nodes.Add(n);

                        var o = n2.Tag as FoundHtmlNode;
                        if (o != null)
                            if (o.SearchNode || o.ResultNode)
                                n2.Expand();

                    }


                };

                try
                {

                    this._visitor = new ExtractDataVisitor(this._config)
                    {
                        Selected = act,
                        Error = actError,
                    };

                    this._dicNodes.Clear();
                    richTextBoxOutput.Text = "";
                    treeViewSelections.Nodes.Clear();

                    var jtoken = this._visitor.Run(new StringBuilder(richTextBoxPlain.Text));
                    if (jtoken != null)
                    {
                        this.richTextBoxOutput.Text = jtoken.ToString();
                    }

                }
                catch (Exception exception)
                {
                    var l = new ListViewItem() { Text = exception.Message };
                    l.SubItems.Add("0");
                    l.SubItems.Add("0");
                    listViewLogs.Items.Add(l);
                }

            }
            else
            {

                foreach (var item in parser.Errors)
                {
                    var l = new ListViewItem() { Text = item.Message };
                    l.SubItems.Add(item.StartIndex.ToString());
                    l.SubItems.Add(item.Line.ToString());
                    listViewLogs.Items.Add(l);
                }
            }

        }

        private void treeViewSelections_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (treeViewSelections.SelectedNode != null)
            {
                var t = treeViewSelections.SelectedNode.Tag as FoundHtmlNode;
                if (t != null)
                {
                    if (t.ResultNode)
                    {
                        if (t.Tag != null)
                        {
                            this.richTextBoxOutput.Text = t.Tag.OuterHtml;
                        }
                    }
                    else if (t.ObjectNode)
                    {
                        if (t.Tag2 != null)
                        {
                            this.richTextBoxOutput.Text = t.Tag2.ToString();
                        }
                    }
                }

            }
        }

    }
}
