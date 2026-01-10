namespace WebRespSnifferApp
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            ResponseDataListView = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            ContextMenuStrip = new ContextMenuStrip( components );
            ContextMenuStripMenuItemOpenFolder = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripSeparator();
            ContextMenuStripMenuItemSave = new ToolStripMenuItem();
            ContextMenuStripMenuItemConcat = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripSeparator();
            ContextMenuStripMenuItemSelectAll = new ToolStripMenuItem();
            ContextMenuStripMenuItemSelectTag = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            ContextMenuStripMenuItemCopy = new ToolStripMenuItem();
            ContextMenuStripMenuItemCopyUrl = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            ContextMenuStripMenuItemDelete = new ToolStripMenuItem();
            TextBoxTagRegex = new TextBox();
            MainMenuStrip = new MenuStrip();
            ToolStripMenuItemFile = new ToolStripMenuItem();
            ToolStripMenuItemOpenFolder = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            ToolStripMenuItemSave = new ToolStripMenuItem();
            ToolStripMenuItemConcat = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            ToolStripMenuItemExit = new ToolStripMenuItem();
            ToolStripMenuItemEdit = new ToolStripMenuItem();
            ToolStripMenuItemSelectAll = new ToolStripMenuItem();
            ToolStripMenuItemSelectTag = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            ToolStripMenuItemCopy = new ToolStripMenuItem();
            ToolStripMenuItemCopyUrl = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            ToolStripMenuItemDelete = new ToolStripMenuItem();
            LabelTagRegex = new Label();
            LabelIndexRegex = new Label();
            TextBoxIndexRegex = new TextBox();
            LabelPositionRegex = new Label();
            TextBoxPositionRegex = new TextBox();
            ContextMenuStrip.SuspendLayout();
            MainMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // ResponseDataListView
            // 
            ResponseDataListView.AllowColumnReorder = true;
            ResponseDataListView.Anchor =    AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left   |  AnchorStyles.Right ;
            ResponseDataListView.Columns.AddRange( new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7, columnHeader8, columnHeader9, columnHeader10 } );
            ResponseDataListView.ContextMenuStrip = ContextMenuStrip;
            ResponseDataListView.FullRowSelect = true;
            ResponseDataListView.Location = new Point( 12, 56 );
            ResponseDataListView.Name = "ResponseDataListView";
            ResponseDataListView.ShowItemToolTips = true;
            ResponseDataListView.Size = new Size( 776, 382 );
            ResponseDataListView.TabIndex = 0;
            ResponseDataListView.UseCompatibleStateImageBehavior = false;
            ResponseDataListView.View = View.Details;
            ResponseDataListView.VirtualMode = true;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "URL";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Content-Type";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Content-Length";
            columnHeader3.TextAlign = HorizontalAlignment.Right;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Size";
            columnHeader4.TextAlign = HorizontalAlignment.Right;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Tag";
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Temp File";
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Position";
            columnHeader7.TextAlign = HorizontalAlignment.Right;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Save File";
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Type";
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Index";
            // 
            // ContextMenuStrip
            // 
            ContextMenuStrip.Items.AddRange( new ToolStripItem[] { ContextMenuStripMenuItemOpenFolder, toolStripMenuItem4, ContextMenuStripMenuItemSave, ContextMenuStripMenuItemConcat, toolStripMenuItem3, ContextMenuStripMenuItemSelectAll, ContextMenuStripMenuItemSelectTag, toolStripMenuItem2, ContextMenuStripMenuItemCopy, ContextMenuStripMenuItemCopyUrl, toolStripSeparator3, ContextMenuStripMenuItemDelete } );
            ContextMenuStrip.Name = "contextMenuStrip1";
            ContextMenuStrip.Size = new Size( 140, 204 );
            // 
            // ContextMenuStripMenuItemOpenFolder
            // 
            ContextMenuStripMenuItemOpenFolder.Name = "ContextMenuStripMenuItemOpenFolder";
            ContextMenuStripMenuItemOpenFolder.Size = new Size( 139, 22 );
            ContextMenuStripMenuItemOpenFolder.Text = "Open &Folder";
            ContextMenuStripMenuItemOpenFolder.Click +=  ToolStripMenuItemOpenFolder_Click ;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size( 136, 6 );
            // 
            // ContextMenuStripMenuItemSave
            // 
            ContextMenuStripMenuItemSave.Name = "ContextMenuStripMenuItemSave";
            ContextMenuStripMenuItemSave.Size = new Size( 139, 22 );
            ContextMenuStripMenuItemSave.Text = "&Save";
            ContextMenuStripMenuItemSave.Click +=  ToolStripMenuItemSave_Click ;
            // 
            // ContextMenuStripMenuItemConcat
            // 
            ContextMenuStripMenuItemConcat.Name = "ContextMenuStripMenuItemConcat";
            ContextMenuStripMenuItemConcat.Size = new Size( 139, 22 );
            ContextMenuStripMenuItemConcat.Text = "C&oncat";
            ContextMenuStripMenuItemConcat.Click +=  ToolStripMenuItemConcat_Click ;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size( 136, 6 );
            // 
            // ContextMenuStripMenuItemSelectAll
            // 
            ContextMenuStripMenuItemSelectAll.Name = "ContextMenuStripMenuItemSelectAll";
            ContextMenuStripMenuItemSelectAll.Size = new Size( 139, 22 );
            ContextMenuStripMenuItemSelectAll.Text = "Select &All";
            ContextMenuStripMenuItemSelectAll.Click +=  ToolStripMenuItemSelectAll_Click ;
            // 
            // ContextMenuStripMenuItemSelectTag
            // 
            ContextMenuStripMenuItemSelectTag.Name = "ContextMenuStripMenuItemSelectTag";
            ContextMenuStripMenuItemSelectTag.Size = new Size( 139, 22 );
            ContextMenuStripMenuItemSelectTag.Text = "Select &Tag";
            ContextMenuStripMenuItemSelectTag.Click +=  ToolStripMenuItemSelectTag_Click ;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size( 136, 6 );
            // 
            // ContextMenuStripMenuItemCopy
            // 
            ContextMenuStripMenuItemCopy.Name = "ContextMenuStripMenuItemCopy";
            ContextMenuStripMenuItemCopy.Size = new Size( 139, 22 );
            ContextMenuStripMenuItemCopy.Text = "&Copy";
            ContextMenuStripMenuItemCopy.Click +=  ToolStripMenuItemCopy_Click ;
            // 
            // ContextMenuStripMenuItemCopyUrl
            // 
            ContextMenuStripMenuItemCopyUrl.Name = "ContextMenuStripMenuItemCopyUrl";
            ContextMenuStripMenuItemCopyUrl.Size = new Size( 139, 22 );
            ContextMenuStripMenuItemCopyUrl.Text = "Copy URL";
            ContextMenuStripMenuItemCopyUrl.Click +=  ToolStripMenuItemCopyUrl_Click ;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size( 136, 6 );
            // 
            // ContextMenuStripMenuItemDelete
            // 
            ContextMenuStripMenuItemDelete.Name = "ContextMenuStripMenuItemDelete";
            ContextMenuStripMenuItemDelete.Size = new Size( 139, 22 );
            ContextMenuStripMenuItemDelete.Text = "&Delete";
            ContextMenuStripMenuItemDelete.Click +=  ToolStripMenuItemDelete_Click ;
            // 
            // TextBoxTagRegex
            // 
            TextBoxTagRegex.Location = new Point( 81, 27 );
            TextBoxTagRegex.Name = "TextBoxTagRegex";
            TextBoxTagRegex.Size = new Size( 100, 23 );
            TextBoxTagRegex.TabIndex = 1;
            TextBoxTagRegex.TextChanged +=  TextBoxTagRegex_TextChanged ;
            // 
            // MainMenuStrip
            // 
            MainMenuStrip.Items.AddRange( new ToolStripItem[] { ToolStripMenuItemFile, ToolStripMenuItemEdit } );
            MainMenuStrip.Location = new Point( 0, 0 );
            MainMenuStrip.Name = "MainMenuStrip";
            MainMenuStrip.Size = new Size( 800, 24 );
            MainMenuStrip.TabIndex = 4;
            MainMenuStrip.Text = "menuStrip1";
            // 
            // ToolStripMenuItemFile
            // 
            ToolStripMenuItemFile.DropDownItems.AddRange( new ToolStripItem[] { ToolStripMenuItemOpenFolder, toolStripSeparator4, ToolStripMenuItemSave, ToolStripMenuItemConcat, toolStripMenuItem1, ToolStripMenuItemExit } );
            ToolStripMenuItemFile.Name = "ToolStripMenuItemFile";
            ToolStripMenuItemFile.Size = new Size( 37, 20 );
            ToolStripMenuItemFile.Text = "&File";
            // 
            // ToolStripMenuItemOpenFolder
            // 
            ToolStripMenuItemOpenFolder.Name = "ToolStripMenuItemOpenFolder";
            ToolStripMenuItemOpenFolder.ShortcutKeys =  Keys.Control  |  Keys.F ;
            ToolStripMenuItemOpenFolder.Size = new Size( 178, 22 );
            ToolStripMenuItemOpenFolder.Text = "Open &Folder";
            ToolStripMenuItemOpenFolder.Click +=  ToolStripMenuItemOpenFolder_Click ;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size( 175, 6 );
            // 
            // ToolStripMenuItemSave
            // 
            ToolStripMenuItemSave.Name = "ToolStripMenuItemSave";
            ToolStripMenuItemSave.ShortcutKeys =  Keys.Control  |  Keys.S ;
            ToolStripMenuItemSave.Size = new Size( 178, 22 );
            ToolStripMenuItemSave.Text = "&Save";
            ToolStripMenuItemSave.Click +=  ToolStripMenuItemSave_Click ;
            // 
            // ToolStripMenuItemConcat
            // 
            ToolStripMenuItemConcat.Name = "ToolStripMenuItemConcat";
            ToolStripMenuItemConcat.Size = new Size( 178, 22 );
            ToolStripMenuItemConcat.Text = "&Concat";
            ToolStripMenuItemConcat.Click +=  ToolStripMenuItemConcat_Click ;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size( 175, 6 );
            // 
            // ToolStripMenuItemExit
            // 
            ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            ToolStripMenuItemExit.ShortcutKeys =  Keys.Alt  |  Keys.F4 ;
            ToolStripMenuItemExit.Size = new Size( 178, 22 );
            ToolStripMenuItemExit.Text = "E&xit";
            ToolStripMenuItemExit.Click +=  ToolStripMenuItemExit_Click ;
            // 
            // ToolStripMenuItemEdit
            // 
            ToolStripMenuItemEdit.DropDownItems.AddRange( new ToolStripItem[] { ToolStripMenuItemSelectAll, ToolStripMenuItemSelectTag, toolStripSeparator1, ToolStripMenuItemCopy, ToolStripMenuItemCopyUrl, toolStripSeparator2, ToolStripMenuItemDelete } );
            ToolStripMenuItemEdit.Name = "ToolStripMenuItemEdit";
            ToolStripMenuItemEdit.Size = new Size( 39, 20 );
            ToolStripMenuItemEdit.Text = "&Edit";
            // 
            // ToolStripMenuItemSelectAll
            // 
            ToolStripMenuItemSelectAll.Name = "ToolStripMenuItemSelectAll";
            ToolStripMenuItemSelectAll.ShortcutKeys =  Keys.Control  |  Keys.A ;
            ToolStripMenuItemSelectAll.Size = new Size( 163, 22 );
            ToolStripMenuItemSelectAll.Text = "Select &All";
            ToolStripMenuItemSelectAll.Click +=  ToolStripMenuItemSelectAll_Click ;
            // 
            // ToolStripMenuItemSelectTag
            // 
            ToolStripMenuItemSelectTag.Name = "ToolStripMenuItemSelectTag";
            ToolStripMenuItemSelectTag.Size = new Size( 163, 22 );
            ToolStripMenuItemSelectTag.Text = "Select &Tag";
            ToolStripMenuItemSelectTag.Click +=  ToolStripMenuItemSelectTag_Click ;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size( 160, 6 );
            // 
            // ToolStripMenuItemCopy
            // 
            ToolStripMenuItemCopy.Name = "ToolStripMenuItemCopy";
            ToolStripMenuItemCopy.ShortcutKeys =  Keys.Control  |  Keys.C ;
            ToolStripMenuItemCopy.Size = new Size( 163, 22 );
            ToolStripMenuItemCopy.Text = "&Copy";
            ToolStripMenuItemCopy.Click +=  ToolStripMenuItemCopy_Click ;
            // 
            // ToolStripMenuItemCopyUrl
            // 
            ToolStripMenuItemCopyUrl.Name = "ToolStripMenuItemCopyUrl";
            ToolStripMenuItemCopyUrl.Size = new Size( 163, 22 );
            ToolStripMenuItemCopyUrl.Text = "Copy &URL";
            ToolStripMenuItemCopyUrl.Click +=  ToolStripMenuItemCopyUrl_Click ;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size( 160, 6 );
            // 
            // ToolStripMenuItemDelete
            // 
            ToolStripMenuItemDelete.Name = "ToolStripMenuItemDelete";
            ToolStripMenuItemDelete.ShortcutKeys = Keys.Delete;
            ToolStripMenuItemDelete.Size = new Size( 163, 22 );
            ToolStripMenuItemDelete.Text = "&Delete";
            ToolStripMenuItemDelete.Click +=  ToolStripMenuItemDelete_Click ;
            // 
            // LabelTagRegex
            // 
            LabelTagRegex.AutoSize = true;
            LabelTagRegex.Location = new Point( 12, 30 );
            LabelTagRegex.Name = "LabelTagRegex";
            LabelTagRegex.Size = new Size( 63, 15 );
            LabelTagRegex.TabIndex = 5;
            LabelTagRegex.Text = "Tag Regex:";
            // 
            // LabelIndexRegex
            // 
            LabelIndexRegex.AutoSize = true;
            LabelIndexRegex.Location = new Point( 187, 30 );
            LabelIndexRegex.Name = "LabelIndexRegex";
            LabelIndexRegex.Size = new Size( 74, 15 );
            LabelIndexRegex.TabIndex = 7;
            LabelIndexRegex.Text = "Index Regex:";
            // 
            // TextBoxIndexRegex
            // 
            TextBoxIndexRegex.Location = new Point( 267, 27 );
            TextBoxIndexRegex.Name = "TextBoxIndexRegex";
            TextBoxIndexRegex.Size = new Size( 100, 23 );
            TextBoxIndexRegex.TabIndex = 6;
            TextBoxIndexRegex.TextChanged +=  TextBoxIndexRegex_TextChanged ;
            // 
            // LabelPositionRegex
            // 
            LabelPositionRegex.AutoSize = true;
            LabelPositionRegex.Location = new Point( 373, 30 );
            LabelPositionRegex.Name = "LabelPositionRegex";
            LabelPositionRegex.Size = new Size( 88, 15 );
            LabelPositionRegex.TabIndex = 9;
            LabelPositionRegex.Text = "Position Regex:";
            // 
            // TextBoxPositionRegex
            // 
            TextBoxPositionRegex.Location = new Point( 467, 27 );
            TextBoxPositionRegex.Name = "TextBoxPositionRegex";
            TextBoxPositionRegex.Size = new Size( 100, 23 );
            TextBoxPositionRegex.TabIndex = 8;
            TextBoxPositionRegex.TextChanged +=  TextBoxPositionRegex_TextChanged ;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF( 7F, 15F );
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size( 800, 450 );
            Controls.Add( LabelPositionRegex );
            Controls.Add( TextBoxPositionRegex );
            Controls.Add( LabelIndexRegex );
            Controls.Add( TextBoxIndexRegex );
            Controls.Add( LabelTagRegex );
            Controls.Add( MainMenuStrip );
            Controls.Add( TextBoxTagRegex );
            Controls.Add( ResponseDataListView );
            Name = "MainForm";
            Text = "Web Response Sniffer App";
            FormClosed +=  MainForm_FormClosed ;
            ContextMenuStrip.ResumeLayout( false );
            MainMenuStrip.ResumeLayout( false );
            MainMenuStrip.PerformLayout();
            ResumeLayout( false );
            PerformLayout();
        }

        #endregion

        private ListView ResponseDataListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private TextBox TextBoxTagRegex;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ContextMenuStrip ContextMenuStrip;
        private MenuStrip MainMenuStrip;
        private ToolStripMenuItem ToolStripMenuItemFile;
        private ToolStripMenuItem ToolStripMenuItemSave;
        private ToolStripMenuItem ToolStripMenuItemConcat;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private ToolStripMenuItem ToolStripMenuItemEdit;
        private ToolStripMenuItem ToolStripMenuItemSelectAll;
        private ToolStripMenuItem ToolStripMenuItemSelectTag;
        private ToolStripMenuItem ToolStripMenuItemDelete;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem ContextMenuStripMenuItemSelectTag;
        private ToolStripMenuItem ContextMenuStripMenuItemSelectAll;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem ContextMenuStripMenuItemDelete;
        private Label LabelTagRegex;
        private Label LabelIndexRegex;
        private TextBox TextBoxIndexRegex;
        private Label LabelPositionRegex;
        private TextBox TextBoxPositionRegex;
        private ColumnHeader columnHeader7;
        private ToolStripMenuItem ToolStripMenuItemCopy;
        private ToolStripMenuItem ToolStripMenuItemCopyUrl;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem ContextMenuStripMenuItemCopy;
        private ToolStripMenuItem ContextMenuStripMenuItemCopyUrl;
        private ToolStripSeparator toolStripSeparator3;
        private ColumnHeader columnHeader8;
        private ToolStripMenuItem ContextMenuStripMenuItemSave;
        private ToolStripMenuItem ContextMenuStripMenuItemConcat;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem ToolStripMenuItemOpenFolder;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem ContextMenuStripMenuItemOpenFolder;
        private ToolStripSeparator toolStripMenuItem4;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
    }
}