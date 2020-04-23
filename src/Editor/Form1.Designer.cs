using System.Threading;

namespace Editor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.richTextBoxPlain = new System.Windows.Forms.RichTextBox();
            this.richTextBoxRule = new FastColoredTextBoxNS.FastColoredTextBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.listViewLogs = new System.Windows.Forms.ListView();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.treeViewSelections = new System.Windows.Forms.TreeView();
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 700;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1223, 840);
            this.splitContainer1.SplitterDistance = 513;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.richTextBoxPlain);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.richTextBoxRule);
            this.splitContainer2.Size = new System.Drawing.Size(513, 840);
            this.splitContainer2.SplitterDistance = 268;
            this.splitContainer2.TabIndex = 0;
            // 
            // richTextBoxPlain
            // 
            this.richTextBoxPlain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxPlain.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxPlain.Name = "richTextBoxPlain";
            this.richTextBoxPlain.Size = new System.Drawing.Size(513, 268);
            this.richTextBoxPlain.TabIndex = 0;
            this.richTextBoxPlain.Text = "";
            // 
            // richTextBoxRule
            // 
            this.richTextBoxRule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxRule.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxRule.Name = "richTextBoxRule";
            this.richTextBoxRule.Size = new System.Drawing.Size(513, 568);
            this.richTextBoxRule.TabIndex = 0;
            this.richTextBoxRule.Text = "";
            this.richTextBoxRule.TextChanged += RichTextBoxRule_TextChanged;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.listViewLogs);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(706, 840);
            this.splitContainer3.SplitterDistance = 271;
            this.splitContainer3.TabIndex = 0;
            // 
            // listViewLogs
            // 
            this.listViewLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLogs.HideSelection = false;
            this.listViewLogs.Location = new System.Drawing.Point(0, 0);
            this.listViewLogs.Name = "listViewLogs";
            this.listViewLogs.Size = new System.Drawing.Size(706, 271);
            this.listViewLogs.TabIndex = 0;
            this.listViewLogs.UseCompatibleStateImageBehavior = false;
            this.listViewLogs.View = System.Windows.Forms.View.Details;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.treeViewSelections);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.richTextBoxOutput);
            this.splitContainer4.Size = new System.Drawing.Size(706, 565);
            this.splitContainer4.SplitterDistance = 340;
            this.splitContainer4.TabIndex = 0;
            // 
            // treeViewSelections
            // 
            this.treeViewSelections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewSelections.Location = new System.Drawing.Point(0, 0);
            this.treeViewSelections.Name = "treeViewSelections";
            this.treeViewSelections.Size = new System.Drawing.Size(340, 565);
            this.treeViewSelections.TabIndex = 0;
            this.treeViewSelections.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSelections_AfterSelect);
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxOutput.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.Size = new System.Drawing.Size(362, 565);
            this.richTextBoxOutput.TabIndex = 0;
            this.richTextBoxOutput.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 840);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.ListView listViewLogs;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TreeView treeViewSelections;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;
        private System.Windows.Forms.RichTextBox richTextBoxPlain;
        private FastColoredTextBoxNS.FastColoredTextBox richTextBoxRule;
    }
}

