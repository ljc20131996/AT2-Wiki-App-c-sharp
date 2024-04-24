namespace AT2_Wiki_App
{
    partial class DataForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView = new System.Windows.Forms.ListView();
            this.linearButton = new System.Windows.Forms.RadioButton();
            this.nonLinearButton = new System.Windows.Forms.RadioButton();
            this.structureGroupBox = new System.Windows.Forms.GroupBox();
            this.definitionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameGroupBox = new System.Windows.Forms.GroupBox();
            this.sortButton = new System.Windows.Forms.Button();
            this.doubleClickLabel = new System.Windows.Forms.Label();
            this.structureGroupBox.SuspendLayout();
            this.nameGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(425, 30);
            this.listView.Margin = new System.Windows.Forms.Padding(4);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(604, 509);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // linearButton
            // 
            this.linearButton.AutoSize = true;
            this.linearButton.Location = new System.Drawing.Point(47, 47);
            this.linearButton.Margin = new System.Windows.Forms.Padding(4);
            this.linearButton.Name = "linearButton";
            this.linearButton.Size = new System.Drawing.Size(65, 20);
            this.linearButton.TabIndex = 1;
            this.linearButton.TabStop = true;
            this.linearButton.Text = "Linear";
            this.linearButton.UseVisualStyleBackColor = true;
            this.linearButton.CheckedChanged += new System.EventHandler(this.linearButton_CheckedChanged);
            // 
            // nonLinearButton
            // 
            this.nonLinearButton.AutoSize = true;
            this.nonLinearButton.Location = new System.Drawing.Point(47, 75);
            this.nonLinearButton.Margin = new System.Windows.Forms.Padding(4);
            this.nonLinearButton.Name = "nonLinearButton";
            this.nonLinearButton.Size = new System.Drawing.Size(94, 20);
            this.nonLinearButton.TabIndex = 2;
            this.nonLinearButton.TabStop = true;
            this.nonLinearButton.Text = "Non-Linear";
            this.nonLinearButton.UseVisualStyleBackColor = true;
            this.nonLinearButton.CheckedChanged += new System.EventHandler(this.nonLinearButton_CheckedChanged);
            // 
            // structureGroupBox
            // 
            this.structureGroupBox.Controls.Add(this.linearButton);
            this.structureGroupBox.Controls.Add(this.nonLinearButton);
            this.structureGroupBox.Location = new System.Drawing.Point(36, 138);
            this.structureGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.structureGroupBox.Name = "structureGroupBox";
            this.structureGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.structureGroupBox.Size = new System.Drawing.Size(183, 148);
            this.structureGroupBox.TabIndex = 4;
            this.structureGroupBox.TabStop = false;
            this.structureGroupBox.Text = "Structure";
            // 
            // definitionTextBox
            // 
            this.definitionTextBox.Location = new System.Drawing.Point(23, 427);
            this.definitionTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.definitionTextBox.Multiline = true;
            this.definitionTextBox.Name = "definitionTextBox";
            this.definitionTextBox.Size = new System.Drawing.Size(371, 111);
            this.definitionTextBox.TabIndex = 5;
            this.definitionTextBox.TextChanged += new System.EventHandler(this.definitionTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 389);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Category";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(36, 340);
            this.addButton.Margin = new System.Windows.Forms.Padding(4);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(100, 28);
            this.addButton.TabIndex = 11;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(164, 340);
            this.editButton.Margin = new System.Windows.Forms.Padding(4);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(100, 28);
            this.editButton.TabIndex = 12;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(295, 340);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(100, 28);
            this.deleteButton.TabIndex = 13;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(164, 30);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(229, 22);
            this.searchTextBox.TabIndex = 14;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(36, 30);
            this.searchButton.Margin = new System.Windows.Forms.Padding(4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(100, 28);
            this.searchButton.TabIndex = 15;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(164, 65);
            this.loadButton.Margin = new System.Windows.Forms.Padding(4);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(100, 28);
            this.loadButton.TabIndex = 16;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(36, 65);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 28);
            this.saveButton.TabIndex = 17;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(103, 385);
            this.categoryComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(291, 24);
            this.categoryComboBox.TabIndex = 19;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(6, 46);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(156, 22);
            this.nameTextBox.TabIndex = 20;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // nameGroupBox
            // 
            this.nameGroupBox.Controls.Add(this.nameTextBox);
            this.nameGroupBox.Location = new System.Drawing.Point(226, 138);
            this.nameGroupBox.Name = "nameGroupBox";
            this.nameGroupBox.Size = new System.Drawing.Size(168, 147);
            this.nameGroupBox.TabIndex = 22;
            this.nameGroupBox.TabStop = false;
            this.nameGroupBox.Text = "Name";
            // 
            // sortButton
            // 
            this.sortButton.Location = new System.Drawing.Point(281, 65);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(112, 28);
            this.sortButton.TabIndex = 23;
            this.sortButton.Text = "Sort By Name";
            this.sortButton.UseVisualStyleBackColor = true;
            this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
            // 
            // doubleClickLabel
            // 
            this.doubleClickLabel.AutoSize = true;
            this.doubleClickLabel.Location = new System.Drawing.Point(80, 108);
            this.doubleClickLabel.Name = "doubleClickLabel";
            this.doubleClickLabel.Size = new System.Drawing.Size(278, 16);
            this.doubleClickLabel.TabIndex = 24;
            this.doubleClickLabel.Text = "Double click the grey space to clear the filters!";
            // 
            // DataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.doubleClickLabel);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.nameGroupBox);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.definitionTextBox);
            this.Controls.Add(this.structureGroupBox);
            this.Controls.Add(this.listView);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DataForm";
            this.Text = "Data Display";
            this.Load += new System.EventHandler(this.DataDisplayLoad);
            this.structureGroupBox.ResumeLayout(false);
            this.structureGroupBox.PerformLayout();
            this.nameGroupBox.ResumeLayout(false);
            this.nameGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.RadioButton linearButton;
        private System.Windows.Forms.RadioButton nonLinearButton;
        private System.Windows.Forms.GroupBox structureGroupBox;
        private System.Windows.Forms.TextBox definitionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.GroupBox nameGroupBox;
        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.Label doubleClickLabel;
    }
}

