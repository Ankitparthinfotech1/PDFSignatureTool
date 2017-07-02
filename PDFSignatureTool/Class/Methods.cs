using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PDFSignatureTool.Class{
    class Methods   {

  
        private void sign(X509Certificate2 cert, String imput, String output){
            string SourcePdfFileName = imput;
            string DestPdfFileName = output;
            string requerente = "";
            Org.BouncyCastle.X509.X509CertificateParser cp = new Org.BouncyCastle.X509.X509CertificateParser();
            Org.BouncyCastle.X509.X509Certificate[] chain = new Org.BouncyCastle.X509.X509Certificate[] { cp.ReadCertificate(cert.RawData) };
            IExternalSignature externalSignature = new X509Certificate2Signature(cert, "SHA-1");
            PdfReader pdfReader = new PdfReader(SourcePdfFileName);
            FileStream signedPdf = new FileStream(DestPdfFileName, FileMode.Create);  //the output pdf file
            PdfStamper pdfStamper = PdfStamper.CreateSignature(pdfReader, signedPdf, '\0');
            PdfSignatureAppearance signatureAppearance = pdfStamper.SignatureAppearance;

            requerente = cert.Subject.Replace("CN=", "").Replace("OU=", "").Replace("DC=", "").Replace("O=", "").Replace("C=", "");

            signatureAppearance.SetVisibleSignature( new iTextSharp.text.Rectangle(250, 30, 550, 80),1,  "Signature");
            signatureAppearance.Layer2Text = "Assinado de forma digital por " + requerente + Environment.NewLine + "Dados:" + DateTime.Now;

            string pathImage = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "assinatura.png");
            var image = iTextSharp.text.Image.GetInstance(pathImage);




            signatureAppearance.SignatureGraphic = image;





            //signatureAppearance.SignatureRenderingMode = PdfSignatureAppearance.RenderingMode.DESCRIPTION;
            signatureAppearance.SignatureRenderingMode = PdfSignatureAppearance.RenderingMode.GRAPHIC_AND_DESCRIPTION;

            //signatureAppearance.SignatureRenderingMode = PdfSignatureAppearance.RenderingMode.DESCRIPTION;
            MakeSignature.SignDetached(signatureAppearance, externalSignature, chain, null, null, null, 0, CryptoStandard.CMS);
        }


        public String signPDF(String certName, String folder){
            String result = "";
            String output = folder + "\\Assinados\\";
            DirectoryInfo dSaida = new DirectoryInfo(output);
            dSaida.Create();

            X509Certificate2 cert = this.getCert(certName);

            DirectoryInfo d = new DirectoryInfo(folder);
            FileInfo[] Files = d.GetFiles("*.pdf");

            //Lista todos os arquivos PDF da pasta e executa o procedimento para cada um deles
            foreach (FileInfo file in Files) {
                try{
                    this.sign(cert, file.FullName, output + file.Name);
                    result += file.Name + " - Assinado" + Environment.NewLine;
                }
                catch(Exception erro){
                    result += file.Name + " - Erro" + Environment.NewLine; ;
                }
            }

            return result;
        }


        public X509Certificate2 getCert(String certName) { 
            X509Certificate2Collection lcerts;
            X509Store lStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);

            // Abre o Store
            lStore.Open(OpenFlags.ReadOnly);

            // Lista os certificados
            lcerts = lStore.Certificates;

            foreach (X509Certificate2 cert in lcerts) {
                if (certName == cert.Subject){
                    return cert;
                }
            }

            lStore.Close();
            return null;
        }


        public List<String> getCertList() {
            List<String> certList = new List<String>();

            X509Certificate2Collection lcerts;
            X509Store lStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);

            // Abre o Store
            lStore.Open(OpenFlags.ReadOnly);

            // Lista os certificados
            lcerts = lStore.Certificates;

            foreach (X509Certificate2 cert in lcerts) {
                if (cert.HasPrivateKey && cert.NotAfter > DateTime.Now && cert.NotBefore < DateTime.Now) {
                    certList.Add(cert.Subject);
                }
            }
            lStore.Close();
            return certList;
        }


    }
}