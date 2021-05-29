using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TI4
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Coders.Items.Add(new STFL(256));
			Coders.Items.Add(new STFLGeffe(256));
			Coders.Items.Add(new RC4(new int[] { 19, 44, 31, 25, 7, 6, 41, 55, 24, 14, 9, 10, 11, 38, 49 }));
			CodeButton.Click += CodeMessage;
		}

		private void CodeMessage(object sender, RoutedEventArgs args)
		{
			CodedMessage.Text = ((Coder)Coders.SelectedItem).CodeMessage(Message.Text);
		}
	}
}
