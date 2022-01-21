
namespace Transportation
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.TableComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SelectFizRecipientButton = new System.Windows.Forms.Button();
            this.SelectFizSenderButton = new System.Windows.Forms.Button();
            this.FizSender2Button = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SelectEmployeeAcceptanceOrdersButton = new System.Windows.Forms.Button();
            this.patronymicSelectEmployeeAcceptanceOrdersTextBox = new System.Windows.Forms.TextBox();
            this.namesSelectEmployeeAcceptanceOrdersTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SurnameSelectEmployeeAcceptanceOrdersTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(883, 411);
            this.dataGridView1.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.addButton.Location = new System.Drawing.Point(12, 8);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.deleteButton.Location = new System.Drawing.Point(93, 8);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(174, 9);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // TableComboBox
            // 
            this.TableComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TableComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TableComboBox.FormattingEnabled = true;
            this.TableComboBox.Location = new System.Drawing.Point(12, 55);
            this.TableComboBox.Name = "TableComboBox";
            this.TableComboBox.Size = new System.Drawing.Size(175, 21);
            this.TableComboBox.Sorted = true;
            this.TableComboBox.TabIndex = 4;
            this.TableComboBox.SelectedIndexChanged += new System.EventHandler(this.TableComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Список баз данных";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.addButton);
            this.panel1.Controls.Add(this.TableComboBox);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.deleteButton);
            this.panel1.Location = new System.Drawing.Point(12, 417);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 92);
            this.panel1.TabIndex = 6;
            // 
            // SelectFizRecipientButton
            // 
            this.SelectFizRecipientButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectFizRecipientButton.Location = new System.Drawing.Point(314, 426);
            this.SelectFizRecipientButton.Name = "SelectFizRecipientButton";
            this.SelectFizRecipientButton.Size = new System.Drawing.Size(75, 23);
            this.SelectFizRecipientButton.TabIndex = 7;
            this.SelectFizRecipientButton.Text = "Запрос 1";
            this.SelectFizRecipientButton.UseVisualStyleBackColor = true;
            this.SelectFizRecipientButton.Click += new System.EventHandler(this.SelectFizRecipientButton_Click);
            // 
            // SelectFizSenderButton
            // 
            this.SelectFizSenderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectFizSenderButton.Location = new System.Drawing.Point(404, 427);
            this.SelectFizSenderButton.Name = "SelectFizSenderButton";
            this.SelectFizSenderButton.Size = new System.Drawing.Size(75, 23);
            this.SelectFizSenderButton.TabIndex = 8;
            this.SelectFizSenderButton.Text = "Запрос 2";
            this.SelectFizSenderButton.UseVisualStyleBackColor = true;
            this.SelectFizSenderButton.Click += new System.EventHandler(this.SelectFizSenderButton_Click);
            // 
            // FizSender2Button
            // 
            this.FizSender2Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FizSender2Button.Location = new System.Drawing.Point(497, 426);
            this.FizSender2Button.Name = "FizSender2Button";
            this.FizSender2Button.Size = new System.Drawing.Size(100, 23);
            this.FizSender2Button.TabIndex = 10;
            this.FizSender2Button.Text = "Запрос 3";
            this.FizSender2Button.UseVisualStyleBackColor = true;
            this.FizSender2Button.Click += new System.EventHandler(this.FizSender2Button_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.SelectEmployeeAcceptanceOrdersButton);
            this.panel2.Controls.Add(this.patronymicSelectEmployeeAcceptanceOrdersTextBox);
            this.panel2.Controls.Add(this.namesSelectEmployeeAcceptanceOrdersTextBox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.SurnameSelectEmployeeAcceptanceOrdersTextBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(623, 417);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(249, 170);
            this.panel2.TabIndex = 11;
            // 
            // SelectEmployeeAcceptanceOrdersButton
            // 
            this.SelectEmployeeAcceptanceOrdersButton.Location = new System.Drawing.Point(7, 95);
            this.SelectEmployeeAcceptanceOrdersButton.Name = "SelectEmployeeAcceptanceOrdersButton";
            this.SelectEmployeeAcceptanceOrdersButton.Size = new System.Drawing.Size(162, 23);
            this.SelectEmployeeAcceptanceOrdersButton.TabIndex = 6;
            this.SelectEmployeeAcceptanceOrdersButton.Text = "Запрос 4";
            this.SelectEmployeeAcceptanceOrdersButton.UseVisualStyleBackColor = true;
            this.SelectEmployeeAcceptanceOrdersButton.Click += new System.EventHandler(this.SelectEmployeeAcceptanceOrdersButton_Click);
            // 
            // patronymicSelectEmployeeAcceptanceOrdersTextBox
            // 
            this.patronymicSelectEmployeeAcceptanceOrdersTextBox.Location = new System.Drawing.Point(69, 60);
            this.patronymicSelectEmployeeAcceptanceOrdersTextBox.Name = "patronymicSelectEmployeeAcceptanceOrdersTextBox";
            this.patronymicSelectEmployeeAcceptanceOrdersTextBox.Size = new System.Drawing.Size(100, 20);
            this.patronymicSelectEmployeeAcceptanceOrdersTextBox.TabIndex = 5;
            // 
            // namesSelectEmployeeAcceptanceOrdersTextBox
            // 
            this.namesSelectEmployeeAcceptanceOrdersTextBox.Location = new System.Drawing.Point(69, 33);
            this.namesSelectEmployeeAcceptanceOrdersTextBox.Name = "namesSelectEmployeeAcceptanceOrdersTextBox";
            this.namesSelectEmployeeAcceptanceOrdersTextBox.Size = new System.Drawing.Size(100, 20);
            this.namesSelectEmployeeAcceptanceOrdersTextBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Patronymic";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Names";
            // 
            // SurnameSelectEmployeeAcceptanceOrdersTextBox
            // 
            this.SurnameSelectEmployeeAcceptanceOrdersTextBox.Location = new System.Drawing.Point(69, 7);
            this.SurnameSelectEmployeeAcceptanceOrdersTextBox.Name = "SurnameSelectEmployeeAcceptanceOrdersTextBox";
            this.SurnameSelectEmployeeAcceptanceOrdersTextBox.Size = new System.Drawing.Size(100, 20);
            this.SurnameSelectEmployeeAcceptanceOrdersTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Surname";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 591);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.FizSender2Button);
            this.Controls.Add(this.SelectFizSenderButton);
            this.Controls.Add(this.SelectFizRecipientButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 630);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ComboBox TableComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button SelectFizRecipientButton;
        private System.Windows.Forms.Button SelectFizSenderButton;
        private System.Windows.Forms.Button FizSender2Button;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button SelectEmployeeAcceptanceOrdersButton;
        private System.Windows.Forms.TextBox patronymicSelectEmployeeAcceptanceOrdersTextBox;
        private System.Windows.Forms.TextBox namesSelectEmployeeAcceptanceOrdersTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SurnameSelectEmployeeAcceptanceOrdersTextBox;
        private System.Windows.Forms.Label label2;
    }
}

