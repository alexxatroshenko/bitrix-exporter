using System.Text.RegularExpressions;
using Business.Interfaces;

namespace BitrixJsonExporter;

public partial class Form1 : Form
{
    const string WebhookRegex = @"^https://atlant\.bitrix24\.by/rest/\d+/[^/]+/$";
    private readonly IExporter _exporter;
    public Form1(IExporter exporter)
    {
        _exporter = exporter;
        InitializeComponent();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        using var folderDialog = new FolderBrowserDialog();
        
        folderDialog.Description = "Выберите папку";
        folderDialog.RootFolder = Environment.SpecialFolder.Desktop;
        folderDialog.ShowNewFolderButton = true;
            
        DialogResult result = folderDialog.ShowDialog();
            
        if (result == DialogResult.OK && !string.IsNullOrEmpty(folderDialog.SelectedPath))
        {
            var selectedFolder = folderDialog.SelectedPath;

            folderPath.Text = selectedFolder;
        }
        else
        {
            MessageBox.Show("Папка не выбрана", "Информация", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var webhook = webhookText.Text;
        var path = folderPath.Text;
        try
        {
            if (!Regex.IsMatch(webhook, WebhookRegex))
            {
                throw new Exception("webhook неверного формата");
            }

            if (string.IsNullOrEmpty(path))
            {
                throw new Exception("выберите путь для экспорта");
            }

            _exporter.StartExport(webhook, path);
        }
        catch (Exception ex)
        {
            status.Text = ex.Message;
        }
    }
}