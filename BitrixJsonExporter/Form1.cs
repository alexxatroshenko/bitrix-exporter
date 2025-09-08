using System.Text.RegularExpressions;
using Business.Interfaces;
using Data.Interfaces;

namespace BitrixJsonExporter;

public partial class Form1 : Form
{
    const string WebhookRegex = @"^https://atlant\.bitrix24\.by/rest/\d+/[^/]+/$";
    private readonly IExporter _exporter;
    private readonly IHttpService _httpService;
    public Form1(IExporter exporter, IHttpService httpService)
    {
        _exporter = exporter;
        _httpService = httpService;
        InitializeComponent();
        _exporter.OnStatusChanged += OnStatusChanged;
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

    private async void button1_Click(object sender, EventArgs e)
    {
        try
        {
            var webhook = webhookText.Text;
            var path = folderPath.Text;
            
            if (!Regex.IsMatch(webhook, WebhookRegex))
            {
                throw new Exception("webhook неверного формата");
            }

            if (string.IsNullOrEmpty(path))
            {
                throw new Exception("выберите путь для экспорта");
            }
            _httpService.ConfigureHttpClient(webhook);
            await _exporter.StartExport(webhook, path);
            status.Text = "Данные успешно экспортированы";
        }
        catch (Exception ex)
        {
            exception.Text = ex.Message;
        }
    }

    private void OnStatusChanged(string text)
    {
        status.Text = text;
    }
}