using GenericSaaS.Models;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace GenericSaaS
{
	/// <summary>
	/// Interaction logic for CreateJsonFileWindow.xaml
	/// </summary>
	public partial class CreateJsonFileWindow : Window
	{
		public CreateJsonFileWindow()
		{
			InitializeComponent();
		}

		private void btnOpen_Click(object sender, RoutedEventArgs e)
		{
			using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
			{
				System.Windows.Forms.DialogResult result = dialog.ShowDialog();
				if (result == System.Windows.Forms.DialogResult.OK)
				{
					txtFolder.Text = dialog.SelectedPath;
				}
			}
		}

		private void btnCreate_Click(object sender, RoutedEventArgs e)
		{
			IsFormEnabled(false);
			if (string.IsNullOrEmpty(txtFileName.Text)
				|| string.IsNullOrEmpty(txtFolder.Text)
				|| string.IsNullOrEmpty(txtNumberOfSubscriptions.Text)
				|| string.IsNullOrEmpty(txtNumberOfUsers.Text))
			{
				MessageBox.Show("All fields are required!", "Warning");
				IsFormEnabled(true);
				return;
			}

			if (!int.TryParse(txtNumberOfSubscriptions.Text, out int x)
				|| !int.TryParse(txtNumberOfUsers.Text, out int y))
			{
				MessageBox.Show("Subscriptions and Users must be numbers!", "Warning");
				IsFormEnabled(true);
				return;
			}

			CreateFile();

			IsFormEnabled(true, true);
		}

		private void CreateFile()
		{
			var genericSaasJson = new GenericSaasFile();

			for (int i = 0; i < int.Parse(txtNumberOfSubscriptions.Text); i++)
			{
				genericSaasJson.Subscriptions.Add(new Subscription(int.Parse(txtNumberOfUsers.Text)));
			}

			foreach (var subscription in genericSaasJson.Subscriptions)
			{
				foreach (var user in subscription.UserIds)
				{
					genericSaasJson.Users.Add(new User(user));
				}
			}

			SaveFile(genericSaasJson);
		}

		private void SaveFile(GenericSaasFile saasFile)
		{
			var fileName = $"{txtFolder.Text}\\{txtFileName.Text}.json";
			var json = JsonSerializer.Serialize(saasFile);

			if (File.Exists(fileName)) File.Delete(fileName);

			using (StreamWriter sw = File.CreateText(fileName))
			{
				sw.WriteLine(json);
			}
		}

		private void IsFormEnabled(bool isEnabled, bool emptyForm = false)
		{
			mainForm.IsEnabled = isEnabled;

			if (emptyForm)
			{
				txtFileName.Text = string.Empty;
				txtFolder.Text = string.Empty;
				txtNumberOfSubscriptions.Text = string.Empty;
				txtNumberOfUsers.Text = string.Empty;
			}
		}
	}
}
