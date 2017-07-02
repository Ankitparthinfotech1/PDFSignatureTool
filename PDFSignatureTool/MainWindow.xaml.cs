using PDFSignatureTool.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PDFSignatureTool
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bAssinarDocumentos_Click(object sender, RoutedEventArgs e) {
            Methods method = new Methods();
            ComboboxItem item = (ComboboxItem)cCertificado.SelectedItem;
            String result = "Local dos arquivos assinados: " + tPasta.Text + "\\Assinados" + Environment.NewLine + Environment.NewLine;

            try {
                result += method.signPDF(item.Value.ToString(), tPasta.Text);
            }
            catch{}

            tRestuldado.Text = result;
        }

        private void bLocalizarPasta_Click(object sender, RoutedEventArgs e) {
            FolderBrowserDialog navegarPasta = new FolderBrowserDialog();
            DialogResult response = navegarPasta.ShowDialog();

            if (response.ToString() == "OK") {
                tPasta.Text = navegarPasta.SelectedPath;
            }

        }


         private void loadCert(object sender, RoutedEventArgs e){
            Methods method = new Methods();
            foreach (String certificado in method.getCertList()) {
                ComboboxItem item = new ComboboxItem();
                item.Text = certificado.Replace("CN=", "").Replace("OU=", "").Replace("DC=", "").Replace("O=", "").Replace("C=", "");
                item.Value = certificado;
                cCertificado.Items.Add(item);
            }
        }
    }

    public class ComboboxItem {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString() {
            return Text;
        }
    }
}
