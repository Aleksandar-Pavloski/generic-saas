using System.Windows;

namespace GenericSaaS
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void btnCreateJsonFile_Click(object sender, RoutedEventArgs e)
		{
			var windowo = new CreateJsonFileWindow();
			windowo.Show();
		}
	}
}
