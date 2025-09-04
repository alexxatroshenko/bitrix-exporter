namespace BitrixJsonExporter;

public partial class Form1 : Form
{
    public Form1()
    {
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

            label5.Text = selectedFolder;
        }
        else
        {
            MessageBox.Show("Папка не выбрана", "Информация", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}