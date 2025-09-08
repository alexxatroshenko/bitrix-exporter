namespace BitrixJsonExporter;

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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        label1 = new System.Windows.Forms.Label();
        webhookText = new System.Windows.Forms.RichTextBox();
        label2 = new System.Windows.Forms.Label();
        button1 = new System.Windows.Forms.Button();
        label4 = new System.Windows.Forms.Label();
        button2 = new System.Windows.Forms.Button();
        label3 = new System.Windows.Forms.Label();
        folderPath = new System.Windows.Forms.Label();
        exception = new System.Windows.Forms.Label();
        status = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label1.Location = new System.Drawing.Point(8, 28);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(397, 29);
        label1.TabIndex = 0;
        label1.Text = "Введите webhook";
        // 
        // webhookText
        // 
        webhookText.BackColor = System.Drawing.SystemColors.ControlLightLight;
        webhookText.Location = new System.Drawing.Point(12, 60);
        webhookText.Name = "webhookText";
        webhookText.Size = new System.Drawing.Size(411, 28);
        webhookText.TabIndex = 1;
        webhookText.Text = "";
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label2.Location = new System.Drawing.Point(12, 91);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(397, 29);
        label2.TabIndex = 2;
        label2.Text = "Пример: https://atlant.bitrix24.by/rest/105/5xb1kzirfpdm5bcx/";
        // 
        // button1
        // 
        button1.BackColor = System.Drawing.SystemColors.Highlight;
        button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
        button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)204));
        button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
        button1.Location = new System.Drawing.Point(12, 191);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(179, 34);
        button1.TabIndex = 3;
        button1.Text = "экспорт\r\n";
        button1.UseVisualStyleBackColor = false;
        button1.Click += button1_Click;
        // 
        // label4
        // 
        label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label4.Location = new System.Drawing.Point(8, 126);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(397, 29);
        label4.TabIndex = 4;
        label4.Text = "Выберите папку для экспорта";
        // 
        // button2
        // 
        button2.BackColor = System.Drawing.SystemColors.ButtonFace;
        button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
        button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)204));
        button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
        button2.Image = ((System.Drawing.Image)resources.GetObject("button2.Image"));
        button2.Location = new System.Drawing.Point(384, 125);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(39, 32);
        button2.TabIndex = 7;
        button2.UseVisualStyleBackColor = false;
        button2.Click += button2_Click;
        // 
        // label3
        // 
        label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label3.Location = new System.Drawing.Point(12, 157);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(138, 19);
        label3.TabIndex = 8;
        label3.Text = "Выбрана папка:";
        // 
        // folderPath
        // 
        folderPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)204));
        folderPath.Location = new System.Drawing.Point(112, 157);
        folderPath.Name = "folderPath";
        folderPath.Size = new System.Drawing.Size(311, 19);
        folderPath.TabIndex = 9;
        // 
        // exception
        // 
        exception.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)204));
        exception.ForeColor = System.Drawing.Color.Red;
        exception.Location = new System.Drawing.Point(12, 241);
        exception.Name = "exception";
        exception.Size = new System.Drawing.Size(426, 630);
        exception.TabIndex = 10;
        // 
        // status
        // 
        status.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)204));
        status.Location = new System.Drawing.Point(206, 201);
        status.Name = "status";
        status.Size = new System.Drawing.Size(243, 19);
        status.TabIndex = 11;
        // 
        // Form1
        // 
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        BackColor = System.Drawing.SystemColors.ButtonHighlight;
        ClientSize = new System.Drawing.Size(450, 269);
        Controls.Add(status);
        Controls.Add(exception);
        Controls.Add(folderPath);
        Controls.Add(label3);
        Controls.Add(button2);
        Controls.Add(label4);
        Controls.Add(button1);
        Controls.Add(label2);
        Controls.Add(webhookText);
        Controls.Add(label1);
        MaximumSize = new System.Drawing.Size(466, 1000);
        MinimumSize = new System.Drawing.Size(466, 308);
        Text = "Bitrix export";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label status;

    private System.Windows.Forms.Label exception;

    private System.Windows.Forms.Label folderPath;

    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.RichTextBox webhookText;

    private System.Windows.Forms.Label label1;

    #endregion
}